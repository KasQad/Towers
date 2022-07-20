namespace ScriptableObject.Enemies
{
	[UnityEngine.CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Enemy", order = 0)]
	public class Enemy : UnityEngine.ScriptableObject
	{
		public enum EnemyType
		{
			CreepEnemy,
			TankEnemy
		}

		public string title;
		public float health;
		public float speed;
	}
}
