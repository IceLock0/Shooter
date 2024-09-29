using System;
using System.Collections;
using Configs.Weapon;
using UnityEngine;
namespace Weapon.FireWeapon
{
    public class FireWeapon : MonoBehaviour, IFireWeapon
    {
        [SerializeField] private FireWeaponData _weaponData;

        private IShootBehaviour _shootBehaviour;

        private bool _isReloading;

        private float _fireTimer;
        
        public void Initialize(IShootBehaviour shootBehaviour)
        {
            _shootBehaviour = shootBehaviour;

            _weaponData.CurrentAmmo = _weaponData.ConfigData.MagazineCapacity;

            _fireTimer = _weaponData.ConfigData.FireRate;
        }
        
        public FireWeaponData WeaponData => _weaponData;

        public void Shoot()
        {
            if (!IsCanShoot()) return;

            if (_weaponData.CurrentAmmo < _weaponData.ConfigData.BulletPerShoot)
            {
                StartCoroutine(Reload());
                return;
            }

            _shootBehaviour.Shoot();
            
            _weaponData.CurrentAmmo -= _weaponData.ConfigData.BulletPerShoot;

            _fireTimer = 0.0f;
        }

        public IEnumerator Reload()
        {
            _isReloading = true;
            yield return new WaitForSeconds(_weaponData.ConfigData.ReloadTime);
            _weaponData.CurrentAmmo = _weaponData.ConfigData.MagazineCapacity;
            _isReloading = false;
        }

        private bool IsCanShoot()
        {
            return !(_isReloading || _fireTimer < _weaponData.ConfigData.FireRate);
        }
        
        private void Update()
        {
            _fireTimer += Time.deltaTime;
        }

        [Serializable]
        public class FireWeaponData
        {
            [SerializeField] private FireWeaponConfig _configData;

            public int CurrentAmmo { get; set; }

            public FireWeaponConfig ConfigData => _configData;
        }
    }
}