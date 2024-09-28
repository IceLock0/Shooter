using System;
using Enum;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Weapon
{
    public class WeaponChanger : IDisposable
    {
        private InputService _inputService;

        [Inject]
        public void Initialize(InputService inputService)
        {
            _inputService = inputService;
            
            _inputService.Enable();

            _inputService.Gameplay.Weapon.performed += TryToGetWeapon;
        }

        public Action<WeaponType> WeaponChanged;
        
        private void TryToGetWeapon(InputAction.CallbackContext context)
        {
            var isParsed = int.TryParse(context.control.name, out var value);

            if (!isParsed)
                throw new FormatException($"Failed to convert {context.control.name}.");

            var isExisted = System.Enum.IsDefined(typeof(WeaponType), value);

            if (!isExisted)
                throw new ArgumentException($"Unknown weapon");

            WeaponChanged?.Invoke((WeaponType) value);
        }

        public void Dispose()
        {
            _inputService.Disable();
            
            _inputService.Gameplay.Weapon.performed -= TryToGetWeapon;
        }
    }
}