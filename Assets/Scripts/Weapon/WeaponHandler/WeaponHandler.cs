using UnityEngine;
using Weapon.FireWeapon;
using Zenject;
using System.Collections.Generic;
using PlayerWeapon.Weapon.Bullet;
using PlayerWeapon.Weapon.Bullet.BulletEffects;
using Services.Factories.Weapon.DamageEffect;
using Utils;
using Weapon;
using Weapon.Weapon;

namespace PlayerWeapon.Weapon
{
    public abstract class WeaponHandler : MonoBehaviour
    {
        [SerializeField] protected List<FireWeapon> FireWeaponPrefabs;
        
        [SerializeField] private Transform _firePointTransform;

        [SerializeField] private Transform _weaponHolderTransform;
        [SerializeField] private Bullet.Bullet _bulletPrefab;

        protected FireWeapon CurrentWeapon;

        private IFireWeaponFactory _fireWeaponFactory;
        private IDamageEffectFactory _damageEffectFactory;
        
        [Inject]
        public void Initialize(IFireWeaponFactory fireWeaponFactory, IDamageEffectFactory damageEffectFactory)
        {
            InvariantChecker.CheckObjectInvariant(fireWeaponFactory, damageEffectFactory);

            _fireWeaponFactory = fireWeaponFactory;
            _damageEffectFactory = damageEffectFactory;
        }

        protected FireWeapon CreateWeapon(FireWeapon weaponPrefab)
        {
            var weaponEffects = _damageEffectFactory.CreateEffectsForWeapon(weaponPrefab);
            
            var behaviour = new FireShootBehaviour(_bulletPrefab, weaponPrefab.WeaponData, GetShootDirectionProvider(), _firePointTransform,
                weaponEffects, gameObject);

            var weapon = _fireWeaponFactory.CreateWeaponFromPrefab(behaviour, weaponPrefab,
                _weaponHolderTransform.position, Quaternion.identity, _weaponHolderTransform);

            return weapon;
        }

        protected abstract bool IsCanShoot();

        protected abstract IShootDirectionProvider GetShootDirectionProvider();
        
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