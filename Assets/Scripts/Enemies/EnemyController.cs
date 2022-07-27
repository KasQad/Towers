using System.Collections;
using System.Collections.Generic;
using ScriptableObject.Enemies;
using UnityEngine;
using static UnityEngine.Random;

namespace Enemies
{
	public class EnemyController : MonoBehaviour
	{
		[SerializeField] private Transform enemiesContainer;
		
		[SerializeField] private List<Transform> pathPointsList;
		public readonly List<BaseEnemy> EnemiesList = new List<BaseEnemy>();
		[SerializeField] private int enemyCount = 100;

		private readonly Dictionary<Enemy.EnemyType, BaseEnemy> _prefabEnemiesList =
			new Dictionary<Enemy.EnemyType, BaseEnemy>();

		private void Awake()
		{
			_prefabEnemiesList.Add(Enemy.EnemyType.CreepEnemy, Resources.Load<BaseEnemy>("Prefabs/Enemies/CreepEnemy"));
			_prefabEnemiesList.Add(Enemy.EnemyType.TankEnemy, Resources.Load<BaseEnemy>("Prefabs/Enemies/TankEnemy"));
		}

		private void Start()
		{
			StartCoroutine(SpawningEnemies());
			BaseEnemy.GetHit += ShowHit;
			BaseEnemy.DestroyEnemy += DestroyEnemy0;
		}

		private IEnumerator SpawningEnemies()
		{
			while (enemyCount > 0)
			{
				CreateRandomEnemy();
				yield return new WaitForSeconds(Range(0.5f, 1f));
			}
		}

		private void ShowHit(BaseEnemy baseEnemy, float damage)
		{
			print($"{baseEnemy.name} get hit: {damage}");
		}

		private BaseEnemy SpawnEnemy(Enemy.EnemyType enemyType)
		{
			_prefabEnemiesList.TryGetValue(enemyType, out var baseEnemyValue);
			var baseEnemy = Instantiate(baseEnemyValue, enemiesContainer);
			baseEnemy.Initialize(pathPointsList);
			return baseEnemy;
		}

		private void CreateRandomEnemy()
		{
			var baseEnemy = SpawnEnemy(Range(0, 2) == 0 ? Enemy.EnemyType.CreepEnemy : Enemy.EnemyType.TankEnemy);
			if (!baseEnemy) return;
			enemyCount--;
			EnemiesList.Add(baseEnemy);
		}

		private void DestroyEnemy0(BaseEnemy baseEnemy)
		{
			
			EnemiesList.Remove(baseEnemy);
			Destroy(baseEnemy.gameObject);
		}
	}
}
