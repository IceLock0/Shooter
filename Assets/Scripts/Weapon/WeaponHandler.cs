using UnityEngine;
using Weapon.FireWeapon;
using Zenject;
using System.Collections.Generic;
using Weapon;
using Weapon.View;

namespace PlayerWeapon.Weapon
{
    public abstract class WeaponHandler : MonoBehaviour
    {
        [SerializeField] protected List<FireWeapon> FireWeaponPrefabs;
        
        [SerializeField] private Transform _weaponHolderTransform;
        [SerializeField] private Bullet.Bullet _bulletPrefab;

        protected FireWeapon CurrentWeapon;

        private FireWeaponFactory _fireWeaponFactory;

        [Inject]
        public void Initialize(FireWeaponFactory fireWeaponFactory)
        {
            _fireWeaponFactory = fireWeaponFactory;
        }

        protected FireWeapon CreateWeapon(FireWeapon weaponPrefab)
        {
            return
                _fireWeaponFactory.CreateWeaponFromPrefab(
                    new FireShootBehaviour(_bulletPrefab, weaponPrefab.WeaponData),
                    weaponPrefab, _weaponHolderTransform.position, Quaternion.identity, _weaponHolderTransform);
        }

        protected abstract bool IsCanShoot();

        private void Update()
        {
            if (IsCanShoot())
            {
                if (CurrentWeapon == null)
                    return;
                
                CurrentWeapon.Shoot();
            }
        }
    }
}