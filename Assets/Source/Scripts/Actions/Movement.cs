using System;
using System.Collections;
using Source.Scripts.GameEntities;
using Source.Scripts.InputSystems;
using UnityEngine;

namespace Source.Scripts.Actions
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(BaseInput))]
    public class Movement : MonoBehaviour, IBonusAffects
    {
        [SerializeField] private float _maxX;
        [SerializeField] private float _speed;
        private BaseInput _baseInput;
        private Rigidbody2D _rigidbody;

        private void Awake()
        {
            _baseInput = GetComponent<BaseInput>();
            _rigidbody = GetComponent<Rigidbody2D>();

            _baseInput.OnMove += MoveCharacter;
        }

        private void Update()
        {
            transform.position = new Vector2(Mathf.Clamp(transform.position.x, -_maxX, _maxX), transform.position.y);
        }

        private void MoveCharacter(Vector2 direction)
        {
            _rigidbody.velocity = direction * _speed;
        }

        public void StartAffect(Bonus bonus)
        {
            if (bonus.GetBonusType == Bonus.BonusType.SpeedDown)
            {
                _speed *= bonus.GetBonusScale;
                StartCoroutine(StopAffect(bonus));
            }
        }

        public IEnumerator StopAffect(Bonus bonus)
        {
            yield return new WaitForSeconds(bonus.GetBonusTime);

            if (bonus.GetBonusType == Bonus.BonusType.SpeedDown)
            {
                _speed *= 1 / bonus.GetBonusTime;
            }
        }
    }
}