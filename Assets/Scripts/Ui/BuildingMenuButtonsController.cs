using ScriptableObject.Towers;
using TMPro;
using Towers;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildingMenuButtonsController : MonoBehaviour, IPointerExitHandler
{
	[SerializeField] private ButtonBuildingMenu button1;
	[SerializeField] private ButtonBuildingMenu button2;
	[SerializeField] private ButtonBuildingMenu button3;
	[SerializeField] private TextMeshProUGUI textInfo;

	public void Initialize(TowerController towerController, TowerPoint towerPoint)
	{
		button1.Initialize(Tower.TowerType.LightTower, towerPoint, towerController, CloseMenu, ShowInfoTower);
		button2.Initialize(Tower.TowerType.MiddleTower, towerPoint, towerController, CloseMenu, ShowInfoTower);
		button3.Initialize(Tower.TowerType.HighTower, towerPoint, towerController, CloseMenu, ShowInfoTower);
	}

	private void ShowInfoTower(Tower baseTower)
	{
		textInfo.text = baseTower == null
			? ""
			: $"Title: {baseTower.title}\n" +
			  $"Description: {baseTower.description}\n" +
			  $"Damage: {baseTower.damage}\n" +
			  $"SpeedAttack: {baseTower.speedAttack}\n" +
			  $"RadiusAttack: {baseTower.radiusAttack}";
	}

	private void CloseMenu() => Destroy(gameObject);

	public void OnPointerExit(PointerEventData eventData) => CloseMenu();
}
