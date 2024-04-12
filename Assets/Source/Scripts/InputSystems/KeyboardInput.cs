using UnityEngine;

namespace Source.Scripts.InputSystems
{
    public class KeyboardInput : BaseInput
    {
        [SerializeField] private KeyCode _fireKey;

        private void Update()
        {
            if (Input.GetKeyDown(_fireKey))
                OnFire?.Invoke();
            OnMove?.Invoke(Vector2.right * Input.GetAxis("Horizontal"));
        }
    }
}