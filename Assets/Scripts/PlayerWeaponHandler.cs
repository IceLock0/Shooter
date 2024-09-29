using System.Collections.Generic;
using PlayerWeapon.Weapon;
using UnityEngine.InputSystem;
using Weapon;
using Weapon.FireWeapon;
using Weapon.View;
using Zenject;

namespace PlayerWeapon
{
    public class PlayerWeaponHandler : WeaponHandler
    {
        private List<FireWeapon> _fireWeapons = new();

        private PlayerWeaponChanger _playerWeaponChanger;
        private WeaponView _weaponView;

        private bool _isShooting;

        private InputService _inputService;

        [Inject]
        public void Initialize(InputService inputService)
        {
            _inputService = inputService;

            foreach (var prefab in FireWeaponPrefabs)
            {
                var weapon = CreateWeapon(prefab);
                _fireWeapons.Add(weapon);
            }
            _playerWeaponChanger = new PlayerWeaponChanger(_fireWeapons);
            
            _weaponView = new WeaponView();
            
            _inputService.Enable();

            _inputService.Gameplay.Shoot.performed += ShootPerformed;
            _inputService.Gameplay.Shoot.canceled += ShootCanceled;

            _playerWeaponChanger.WeaponChanged += SetCurrentWeapon;
            _playerWeaponChanger.WeaponChanged += _weaponView.ChangeWeaponVisible;
        }

        protected override bool IsCanShoot() => _isShooting;

        private void SetCurrentWeapon(FireWeapon fireWeapon) => CurrentWeapon = fireWeapon;

        private void ShootPerformed(InputAction.CallbackContext context) => _isShooting = true;
        private void ShootCanceled(InputAction.CallbackContext context) => _isShooting = false;
        
        private void OnDisable()
        {
            _inputService.Disable();

            _inputService.Gameplay.Shoot.performed -= ShootPerformed;
            _inputService.Gameplay.Shoot.canceled -= ShootCanceled;

            _playerWeaponChanger.WeaponChanged -= SetCurrentWeapon;
            _playerWeaponChanger.WeaponChanged -= _weaponView.ChangeWeaponVisible;
        }
    }
}