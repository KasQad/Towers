using System;
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
        public string title;
        public float health;
        private float _speed;
        public Action<BaseEnemy> DestroyEnemy;

        public void Initialize(List<Transform> newPointsList, Action<BaseEnemy> actionDestroyEnemy)
        {
            title = enemy.title;
            health = enemy.health;
            navMeshAgent.speed = _speed = enemy.speed;
            enemyMove.CreateNewPathPointsList(newPointsList);
            DestroyEnemy = actionDestroyEnemy;
        }

        public void GetDamage(float damage)
        {
            health -= damage;
            if (health <= 0) DestroyEnemy(this);
        }
    }
}
