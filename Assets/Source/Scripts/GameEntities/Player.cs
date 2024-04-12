using System;
using UnityEngine;

namespace Source.Scripts.GameEntities
{
    [RequireComponent(typeof(Collider2D))]
    public class Player : MonoBehaviour, IHitable
    {
        public Action OnPlayerDie;
        
        [SerializeField] private float _hitPoints;
        
        private Collider2D _collider;

        private void Awake()
        {
            _collider = GetComponent<Collider2D>();
            if (!_collider.isTrigger)
                Debug.LogError("No trigger attached");
        }

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
            OnPlayerDie?.Invoke();
            Destroy(gameObject);
        }
    }
}