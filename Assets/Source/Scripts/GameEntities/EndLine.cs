using System;
using UnityEngine;

namespace Source.Scripts.GameEntities
{
    public class EndLine : MonoBehaviour
    {
        public Action OnEndLineReached;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out IHitable hitable))
            {
                OnEndLineReached?.Invoke();
                hitable.Die();
            }
            else
            {
                Destroy(other.gameObject);
            }
        }
    }
}