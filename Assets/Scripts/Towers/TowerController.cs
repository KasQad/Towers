using System.Collections.Generic;
using System.Linq;
using Enemies;
using ScriptableObject.Towers;
using UnityEngine;

namespace Towers
{
	public class TowerController : MonoBehaviour
	{
		[SerializeField] private EnemyController enemyController;
		private readonly Dictionary<Tower.TowerType, BaseTower> _prefabTowersList =
			new Dictionary<Tower.TowerType, BaseTower>();
		private readonly Dictionary<TowerPoint, BaseTower> _towersList = new Dictionary<TowerPoint, BaseTower>();
		[SerializeField] private bool attackNearbyEnemy = true;

		private void Awake()
		{
			_prefabTowersList.Add(Tower.TowerType.LightTower, Resources.Load<BaseTower>("Prefabs/Towers/LightTower"));
			_prefabTowersList.Add(Tower.TowerType.MiddleTower, Resources.Load<BaseTower>("Prefabs/Towers/MiddleTower"));
			_prefabTowersList.Add(Tower.TowerType.HighTower, Resources.Load<BaseTower>("Prefabs/Towers/HighTower"));
		}

		private void FixedUpdate()
		{
			FindNearbyEnemies();
		}

		private void FindNearbyEnemies()
		{
			if (_towersList.Count == 0 || enemyController.EnemiesList.Count == 0) return;

			foreach (var tower in _towersList.Values)
			{
				if (!attackNearbyEnemy)
				{
					var focusedEnemy = tower.towerAi.GetFocusedEnemy();
					if (focusedEnemy)
					{
						var distance = CalcDistance(tower.gameObject.transform.position,
							focusedEnemy.gameObject.transform.position);
						if (distance > tower.radiusAttack) tower.towerAi.DeleteEnemyFocused();
						else continue;
					}
				}

				var enemiesInRadiusTower = new Dictionary<BaseEnemy, float>();
				foreach (var enemy in enemyController.EnemiesList)
				{
					var distance = CalcDistance(tower.gameObject.transform.position,
						enemy.gameObject.transform.position);
					if (distance < tower.radiusAttack) enemiesInRadiusTower.Add(enemy, distance);
					else tower.towerAi.DeleteEnemyFocused();
				}

				if (enemiesInRadiusTower.Count == 0) continue;
				var sortedEnemyList =
					from keyValuePair in enemiesInRadiusTower
					orderby keyValuePair.Value
					select keyValuePair;
				var minDistanceEnemy = sortedEnemyList.First().Key;

				tower.towerAi.AddEnemyToFocus(minDistanceEnemy);
			}
		}

		public BaseTower GetDataTower(Tower.TowerType towerType)
		{
			_prefabTowersList.TryGetValue(towerType, out var prefabTower);
			return prefabTower;
		}

		public void BuildTower(BaseTower prefabTower, TowerPoint towerPoint)
		{
			_towersList.TryGetValue(towerPoint, out var baseTower);
			if (baseTower != null) return;

			var baseTowerGameObject = Instantiate(prefabTower, towerPoint.transform);
			_towersList.Add(towerPoint, baseTowerGameObject);
			baseTowerGameObject.Initialize();
		}

		private float CalcDistance(Vector3 pos1, Vector3 pos2) => Vector3.Distance(pos1, pos2);
	}
}
