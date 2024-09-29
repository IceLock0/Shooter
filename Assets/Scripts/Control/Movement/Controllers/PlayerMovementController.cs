using System;
using UnityEngine;
using Zenject;

namespace Movement
{
    public class PlayerMovementController : MovementController
    {
        private InputService _inputService;

        [Inject]
        public void Initialize(InputService inputService)
        {
            _inputService = inputService;

            _inputService.Enable();
        }

        protected override Vector2 GetDirection() =>
            _inputService.Gameplay.Movement.ReadValue<Vector2>().normalized;
        
        private void OnDisable()
        {
            _inputService.Disable();
        }
    }
}