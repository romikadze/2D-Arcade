using System;
using UnityEngine;

namespace Source.Scripts.InputSystems
{
    public class BaseInput : MonoBehaviour
    {
        public Action<Vector2> OnMove;
        public Action OnFire;
    }
}