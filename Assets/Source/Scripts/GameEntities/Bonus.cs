using System;
using UnityEngine;

namespace Source.Scripts.GameEntities
{
    public class Bonus : MonoBehaviour
    {
        [SerializeField] private float _bonusTime;
        [SerializeField] private float _bonusScale;
        [SerializeField] private BonusType _bonusType;
        private EnemyGroup _enemyGroup;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Player player))
            {
                _enemyGroup.AffectGroupBonus(this);
            }
        }

        public void Setup(EnemyGroup enemyGroup)
        {
            _enemyGroup = enemyGroup;
        }

        public float GetBonusTime => _bonusTime;


        public float GetBonusScale => _bonusScale;

        public BonusType GetBonusType => _bonusType;

        public enum BonusType
        {
            SpeedDown
        }
    }
}