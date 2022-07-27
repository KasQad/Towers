using ScriptableObject.Towers;
using UnityEngine;

namespace Towers
{
    public abstract class BaseTower : MonoBehaviour
    {
        public float damage;
        public float speedAttack;
        public float radiusAttack;
        public Tower tower;
        public TowerAi towerAi;
        
        public void Initialize()
        {
            damage = tower.damage;
            speedAttack = tower.speedAttack;
            radiusAttack = tower.radiusAttack;
        }
    }
}
