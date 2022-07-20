using System;
using System.Collections.Generic;
using ScriptableObject.Enemies;
using UnityEngine;

namespace Enemies
{
	public class EnemySpawner : MonoBehaviour
	{
		[SerializeField] private List<Transform> pathPointsList;
		[SerializeField] private Transform enemiesContainer;

		private readonly Dictionary<Enemy.EnemyType, BaseEnemy> _prefabEnemiesList =
			new Dictionary<Enemy.EnemyType, BaseEnemy>();

		private void Awake()
		{
			_prefabEnemiesList.Add(Enemy.EnemyType.CreepEnemy, Resources.Load<BaseEnemy>("Prefabs/Enemies/CreepEnemy"));
			_prefabEnemiesList.Add(Enemy.EnemyType.TankEnemy, Resources.Load<BaseEnemy>("Prefabs/Enemies/TankEnemy"));
		}

		public BaseEnemy SpawnEnemy(Enemy.EnemyType enemyType, Action<BaseEnemy> actionDestroyEnemy)
		{
			_prefabEnemiesList.TryGetValue(enemyType, out var baseEnemyValue);
			var baseEnemy = Instantiate(baseEnemyValue, enemiesContainer);
			baseEnemy.Initialize(pathPointsList, actionDestroyEnemy);
			baseEnemy.name = $"{baseEnemy.title}";
			return baseEnemy;
		}
	}
}
