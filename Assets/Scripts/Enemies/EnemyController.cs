using System.Collections;
using System.Collections.Generic;
using ScriptableObject.Enemies;
using UnityEngine;
using static UnityEngine.Random;

namespace Enemies
{
	public class EnemyController : MonoBehaviour
	{
		[SerializeField] private EnemySpawner enemySpawner;
		public readonly List<BaseEnemy> EnemiesList = new List<BaseEnemy>();
		[SerializeField] private int enemyCount = 100;

		private void Start()
		{
			StartCoroutine(SpawningEnemies());
		}

		private IEnumerator SpawningEnemies()
		{
			while (enemyCount > 0)
			{
				CreateRandomEnemy();
				yield return new WaitForSeconds(Range(0.5f, 1f));
			}
		}

		private void CreateRandomEnemy()
		{
			var baseEnemy =
				enemySpawner.SpawnEnemy(Range(0, 2) == 0 ? Enemy.EnemyType.CreepEnemy : Enemy.EnemyType.TankEnemy,
					DestroyEnemy);

			enemyCount--;
			EnemiesList.Add(baseEnemy);
		}

		private void DestroyEnemy(BaseEnemy baseEnemy)
		{
			EnemiesList.Remove(baseEnemy);
			Destroy(baseEnemy.gameObject);
		}
	}
}
