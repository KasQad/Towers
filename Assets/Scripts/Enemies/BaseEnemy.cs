using System.Collections.Generic;
using ScriptableObject.Enemies;
using UnityEngine;
using UnityEngine.AI;

namespace Enemies
{
    public abstract class BaseEnemy : MonoBehaviour
    {
        [SerializeField] private EnemyMove enemyMove;
        public Enemy enemy;
        public NavMeshAgent navMeshAgent;
        public float health;

        public delegate void GetHitDelegate(BaseEnemy baseEnemy, float damage);
        public static event GetHitDelegate GetHit;

        public delegate void DestroyEnemyDelegate(BaseEnemy baseEnemy);
        public static event DestroyEnemyDelegate DestroyEnemy;

        public void Initialize(List<Transform> newPointsList)
        {
            gameObject.name = $"{enemy.title}";
            health = enemy.health;
            navMeshAgent.speed = enemy.speed;
            enemyMove.CreateNewPathPointsList(newPointsList);
        }

        public void GetDamage(float damage)
        {
            if (GetHit == null) return;
            health -= damage;
            GetHit(this, damage);
            if (health <= 0) Destroy();
        }

        public void Destroy()
        {
            DestroyEnemy?.Invoke(this);
        }
    }
}
