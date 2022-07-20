using UnityEngine;

namespace Towers
{
	public class TowerPoint : MonoBehaviour
	{
		[SerializeField] private BuildingMenuButtonsController buildingMenuButtonsController;
		[SerializeField] private TowerController towerController;

		private void OnMouseDown()
		{
			var buildingMenu = Instantiate(buildingMenuButtonsController);
			buildingMenu.Initialize(towerController, this);
		}
	}
}
