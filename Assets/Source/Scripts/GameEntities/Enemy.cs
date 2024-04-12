using System;
using Source.Scripts.InputSystems;
using UnityEngine;

namespace Source.Scripts.GameEntities
{
    [RequireComponent(typeof(AIInput))]
    public class Enemy : MonoBehaviour, IHitable
    {
        public Action<Enemy> OnDie;
        
        [SerializeField] private float _hitPoints;

        public void Hit(float damage)
        {
            if (damage <= 0)
            {
                Debug.LogError("Damage must be positive");
                return;
            }

            _hitPoints -= damage;

            if (_hitPoints <= 0)
                Die();
        }

        public void Die()
        {
            OnDie?.Invoke(this);
            Destroy(gameObject);
        }
    }
}