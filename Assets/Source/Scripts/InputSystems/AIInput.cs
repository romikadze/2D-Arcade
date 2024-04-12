using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Source.Scripts.InputSystems
{
    public class AIInput : BaseInput
    {
        [SerializeField] private float _shootCooldown;
        [SerializeField] private float _directionChangeCooldown;
        [SerializeField] private float _verticalInput;

        private void Awake()
        {
            StartCoroutine(ShootTick());
            StartCoroutine(MoveTick());
        }

        private IEnumerator ShootTick()
        {
            yield return new WaitForSeconds(_shootCooldown);
            OnFire?.Invoke();
            StartCoroutine(ShootTick());
        }

        private IEnumerator MoveTick()
        {
            yield return new WaitForSeconds(_directionChangeCooldown);
            float horizontalInput = Random.Range(-1f, 1f);
            OnMove?.Invoke(new Vector2(horizontalInput, _verticalInput));
            StartCoroutine(MoveTick());
        }
    }
}