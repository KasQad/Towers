	namespace ScriptableObject.Towers
	{
		[UnityEngine.CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Tower", order = 0)]
		public class Tower : UnityEngine.ScriptableObject
		{
			public enum TowerType
			{
				LightTower,
				MiddleTower,
				HighTower
			}

			public string title;
			public string description;
			public float damage;
			public float speedAttack;
			public float radiusAttack;
		}
	}
