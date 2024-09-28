using System;
using UnityEngine;
using Zenject;

namespace Movement
{
    public class PlayerMovementController : MonoBehaviour
    {
        private IControllable _controllable;
        private InputService _inputService;

        [Inject]
        public void Initialize(InputService inputService)
        {
            _inputService = inputService;
            
            _inputService.Enable();
        }
        
        private void Awake()
        {
            _controllable = GetComponent<IControllable>();

            if (_controllable == null)
                throw new NullReferenceException($"IControllable component is not founded");
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            var direction = ReadMovementVector();
            _controllable.Control(direction);
        }
        
        private Vector2 ReadMovementVector() => _inputService.Gameplay.Movement.ReadValue<Vector2>().normalized * Time.fixedDeltaTime;
        

        private void OnDisable()
        {
            _inputService.Disable();
        }
    }
}