using System;
using PlayerWeapon.Weapon.Bullet;
using UnityEngine;
using Utils;
using Random = UnityEngine.Random;

namespace Weapon
{
    public class FireShootBehaviour : IShootBehaviour
    {
        private Bullet _bulletPrefab;
        private FireWeapon.FireWeapon.FireWeaponData _weaponData;

        private IShootDirectionProvider _shootDirectionProvider;

        private Transform _firePointTransform;

        public FireShootBehaviour(Bullet bulletPrefab, FireWeapon.FireWeapon.FireWeaponData weaponData,
            IShootDirectionProvider shootDirectionProvider, Transform firePointTransform)
        {
            InvariantChecker.CheckObjectInvariant(bulletPrefab, weaponData, shootDirectionProvider);
            _bulletPrefab = bulletPrefab;
            _weaponData = weaponData;

            _shootDirectionProvider = shootDirectionProvider;
            _firePointTransform = firePointTransform;
        }

        public void Shoot()
        {
            Vector3 direction = _shootDirectionProvider.GetShootDirection();

            var origin = _firePointTransform.position;

            var bulletsToSpawn = _weaponData.ConfigData.BulletPerShoot;
            float bulletSpacing = 0.2f;
            float startOffset = -(bulletsToSpawn - 1) * bulletSpacing / 2;

            for (int i = 0; i < bulletsToSpawn; i++)
            {
                var offset = Vector3.right * (startOffset + i * bulletSpacing);
                var spawnPosition = origin + offset;

                var bullet = GameObject.Instantiate(_bulletPrefab, spawnPosition, Quaternion.identity, null);

                direction = ApplySpread(direction, _weaponData.ConfigData.FireSpread);
                ;
                bullet.Initialize(direction, _weaponData.ConfigData.Range, _weaponData.ConfigData.Damage);
            }
        }

        private Vector3 ApplySpread(Vector3 direction, float spread)
        {
            var minValue = spread - spread * 0.2f;
            var maxValue = spread + spread * 0.2f;
            
            float rndSpreadX = Random.Range(minValue, maxValue);
            float rndSpreadY = Random.Range(minValue, maxValue);
            
            Quaternion spreadRotation = Quaternion.Euler(rndSpreadX, rndSpreadY, 0);

            return spreadRotation * direction;
        }
    }
}