using System;
using System.Collections;
using Configs.Weapon;
using Enum;
using Unity.VisualScripting;
using UnityEngine;

namespace Weapon.FireWeapon
{
    public class FireWeapon : MonoBehaviour, IShooter, IReloadble, IWeapon
    {
        [SerializeField] private FireWeaponData _weaponData;

        private IShootBehaviour _shootBehaviour;

        private bool _isReloading;

        public FireWeaponData WeaponData => _weaponData;
        private float _fireTimer;
        
        public void Initialize(IShootBehaviour shootBehaviour)
        {
            _shootBehaviour = shootBehaviour;

            _weaponData.CurrentAmmo = _weaponData.ConfigData.MagazineCapacity;

            _fireTimer = _weaponData.ConfigData.FireRate;
        }

        private void Update()
        {
            _fireTimer += Time.deltaTime;
        }

        public void Shoot()
        {
            if (_isReloading || _weaponData.CurrentAmmo <= 0) return;
            if (_fireTimer < _weaponData.ConfigData.FireRate) return;

            _weaponData.CurrentAmmo--;

            if (_weaponData.CurrentAmmo == 0)
                StartCoroutine(Reload());
            
            _shootBehaviour.Shoot();

            _fireTimer = 0.0f;
        }

        public IEnumerator Reload()
        {
            _isReloading = true;
            yield return new WaitForSeconds(_weaponData.ConfigData.ReloadTime);
            _weaponData.CurrentAmmo = _weaponData.ConfigData.MagazineCapacity;
            _isReloading = false;
        }

        public bool IsWeaponTypeMatch(WeaponType weaponType) => weaponType == _weaponData.ConfigData.WeaponType;

        [Serializable]
        public class FireWeaponData
        {
            [SerializeField] 
            private FireWeaponConfig _configData;

            public int CurrentAmmo { get; set; } 

            public FireWeaponConfig ConfigData => _configData;
        }
    }
}