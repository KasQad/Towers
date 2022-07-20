using ScriptableObject.Towers;
using UnityEngine;

namespace Towers
{
    public abstract class BaseTower : MonoBehaviour
    {
        public string title;
        public string description;
        public float damage;
        public float speedAttack;
        public float radiusAttack;
        public Tower tower;
        public TowerAi towerAi;
        
        public void Initialize()
        {
            title = tower.title;
            description = tower.description;
            damage = tower.damage;
            speedAttack = tower.speedAttack;
            radiusAttack = tower.radiusAttack;
        }
    }
}
