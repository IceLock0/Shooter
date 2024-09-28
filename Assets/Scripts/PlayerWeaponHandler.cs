using System.Collections.Generic;
using System.Linq;
using Enum;
using UnityEngine;
using UnityEngine.InputSystem;
using Weapon;
using Weapon.FireWeapon;
using Zenject;

namespace PlayerWeapon
{
    public class PlayerWeaponHandler : MonoBehaviour
    {
        private List<FireWeapon> _fireWeapons = new();
        private FireWeapon _currentWeapon;
        
        private WeaponChanger _weaponChanger;
        
        private bool _isShooting;

        private InputService _inputService;
        
        [Inject]
        public void Initialize(InputService inputService, List<FireWeapon> fireWeaponPrefabs, FireWeaponFactory fireWeaponFactory, WeaponChanger weaponChanger)
        {
            _inputService = inputService;
            
            foreach (var prefab in fireWeaponPrefabs)
            {
                var weapon = fireWeaponFactory.CreateWeapon(new FireShootBehaviour(_bulletPrefab, prefab.WeaponData), prefab,
                    _weaponHolderTransform.position, Quaternion.identity, _weaponHolderTransform);

                weapons.Add(weapon);
                
            }
            
            _inputService.Enable();

            _inputService.Gameplay.Shoot.performed += ShootPerformed;
            _inputService.Gameplay.Shoot.canceled += ShootCanceled;

            _weaponChanger = weaponChanger;
            
            _weaponChanger.WeaponChanged += SetCurrentWeapon;
        }

        private void SetCurrentWeapon(WeaponType weaponType)
        {
            foreach (var weapon in _fireWeapons.Where(weapon => weapon.IsWeaponTypeMatch(weaponType)))
                _currentWeapon = weapon;
        }
        
        private void Update()
        {
            if (_isShooting)
            {
                if(_currentWeapon != null)
                    _currentWeapon.Shoot();
            }
        }
        
        private void ShootPerformed(InputAction.CallbackContext context)
        {
            _isShooting = true;
        }
        
        private void ShootCanceled(InputAction.CallbackContext context)
        {
            _isShooting = false;
        }
        

        private void OnDisable()
        {
            _inputService.Disable();
            
            _inputService.Gameplay.Shoot.performed -= ShootPerformed;
            _inputService.Gameplay.Shoot.canceled -= ShootCanceled;
            
            _weaponChanger.WeaponChanged -= SetCurrentWeapon;
        }
    }
}