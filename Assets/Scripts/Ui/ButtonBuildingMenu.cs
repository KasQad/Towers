using System;
using ScriptableObject.Towers;
using Towers;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Ui
{
	public class ButtonBuildingMenu : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
	{
		private Action<Tower> _showInfoTower;
		private Tower _baseTower;

		public void Initialize(Tower.TowerType towerType, TowerPoint towerPoint, TowerController towerController,
			Action closeBuildingMenu, Action<Tower> showInfoTower)
		{
			var baseTower = towerController.GetDataTower(towerType);
			if (baseTower == null) return;

			_baseTower = baseTower.tower;
			_showInfoTower = showInfoTower;

			GetComponent<Button>().onClick.AddListener(() =>
			{
				towerController.BuildTower(baseTower, towerPoint);
				closeBuildingMenu();
			});
		}

		public void OnPointerEnter(PointerEventData eventData) => _showInfoTower(_baseTower);

		public void OnPointerExit(PointerEventData eventData) => _showInfoTower(null);
	}
}
