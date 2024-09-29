using System;
using UnityEngine;

namespace Movement
{
    public abstract class MovementController : MonoBehaviour
    {
        private IControllable _controllable;
        
        private Vector2 _direction;
        
        protected abstract Vector2 GetDirection();
        
        private void Awake()
        {
            _controllable = GetComponent<IControllable>();

            if (_controllable == null)
                throw new NullReferenceException("IControllable component not founded");
        }

        private void FixedUpdate()
        {
            _direction = GetDirection();
            
            _controllable.Control(_direction * Time.fixedDeltaTime);
        }
        
    }
}