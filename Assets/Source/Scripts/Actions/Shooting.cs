using System;
using System.Collections;
using Source.Scripts.GameEntities;
using Source.Scripts.InputSystems;
using UnityEngine;

namespace Source.Scripts.Actions
{
    [RequireComponent(typeof(BaseInput))]
    public class Shooting : MonoBehaviour
    {
        [SerializeField] private Bullet _bullet;
        [SerializeField] private Transform _shootPoint;
        [SerializeField] private Vector2 _direction;
        [SerializeField] private float _shotCooldown;
        private BaseInput _input;
        private bool _isReloading;

        private void Awake()
        {
            _input = GetComponent<BaseInput>();
            _input.OnFire += Shot;
        }

        private void Shot()
        {
            if (_isReloading)
                return;
            _isReloading = true;
            Instantiate(_bullet, _shootPoint.position, Quaternion.identity).Setup(_direction);
            StartCoroutine(ReloadTick());
        }

        private IEnumerator ReloadTick()
        {
            yield return new WaitForSeconds(_shotCooldown);
            _isReloading = false;
        }
    }
}