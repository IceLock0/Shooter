using System;
using System.Collections.Generic;
using System.Linq;
using PlayerWeapon.Enum;
using UnityEngine.InputSystem;

namespace Weapon
{
    public class PlayerWeaponChanger : IDisposable
    {
        private List<FireWeapon.FireWeapon> _fireWeapons;
        
        private InputService _inputService;
        
        public PlayerWeaponChanger(List<FireWeapon.FireWeapon> fireWeapons)
        {
            _inputService = new InputService();

            _fireWeapons = fireWeapons;
            
            _inputService.Enable();

            _inputService.Gameplay.Weapon.performed += TryToGetWeapon;
        }

        public Action<FireWeapon.FireWeapon> WeaponChanged;
        
        private void TryToGetWeapon(InputAction.CallbackContext context)
        {
            var isParsed = int.TryParse(context.control.name, out var value);

            if (!isParsed)
                throw new FormatException($"Failed to convert {context.control.name}.");

            var isExisted = Enum.IsDefined(typeof(FireWeaponType), value);

            if (!isExisted)
                throw new ArgumentException($"Unknown weapon");

            foreach (var weapon in _fireWeapons.Where(weapon => weapon.WeaponData.ConfigData.WeaponType == (FireWeaponType) value))
                WeaponChanged?.Invoke(weapon);
        }

        public void Dispose()
        {
            _inputService.Disable();
            
            _inputService.Gameplay.Weapon.performed -= TryToGetWeapon;
        }
    }
}