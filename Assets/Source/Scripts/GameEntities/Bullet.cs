using UnityEngine;

namespace Source.Scripts.GameEntities
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _damage;
        private Rigidbody2D _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            {
                if (other.gameObject.TryGetComponent(out IHitable hitable))
                {
                    hitable.Hit(_damage);
                    Destroy(gameObject);
                }
            }
        }

        public void Setup(Vector2 direction)
        {
            _rigidbody.velocity = direction * _speed;
            Destroy(gameObject, 5);
        }
    }
}