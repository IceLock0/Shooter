﻿using System.Collections.Generic;
using PlayerWeapon.Weapon.Bullet;
using PlayerWeapon.Weapon.Bullet.BulletEffects;
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

        private List<IDamageEffect> _damageEffects;

        private GameObject _senderGO;
        public FireShootBehaviour(Bullet bulletPrefab, FireWeapon.FireWeapon.FireWeaponData weaponData,
            IShootDirectionProvider shootDirectionProvider, Transform firePointTransform, List<IDamageEffect> damageEffects, GameObject senderGO)
        {
            InvariantChecker.CheckObjectInvariant(bulletPrefab, weaponData, shootDirectionProvider, damageEffects);
            _bulletPrefab = bulletPrefab;
            _weaponData = weaponData;

            _shootDirectionProvider = shootDirectionProvider;
            _firePointTransform = firePointTransform;

            _damageEffects = damageEffects;

            _senderGO = senderGO;
        }

        public void Shoot()
        {
            Vector3 direction = _shootDirectionProvider.GetShootDirection();

            if (direction == Vector3.zero)
                return;
            
            var origin = _firePointTransform.position;

            var bulletsToSpawn = _weaponData.ConfigData.BulletPerShoot;
            float bulletSpacing = 0.2f;
            float startOffset = -(bulletsToSpawn - 1) * bulletSpacing / 2;

            for (int i = 0; i < bulletsToSpawn; i++)
            {
                var offset = Vector3.right * (startOffset + i * bulletSpacing);
                var spawnPosition = origin + offset;

                var spreadAngle = ApplySpread();
                
                var bullet = GameObject.Instantiate(_bulletPrefab, spawnPosition, Quaternion.Euler(spreadAngle), null);

                Debug.Log($"Bullet = {bullet.transform.position}, Rotation = {bullet.transform.rotation}");
                
                bullet.Initialize(direction, _weaponData.ConfigData.Range, _weaponData.ConfigData.Damage, _damageEffects, _senderGO);
            }
        }

        private Vector3 ApplySpread()
        {
            Vector3 angle = _firePointTransform.eulerAngles;

            float spreadX = Random.Range(-_weaponData.ConfigData.FireSpread, _weaponData.ConfigData.FireSpread);
            float spreadY = Random.Range(-_weaponData.ConfigData.FireSpread, _weaponData.ConfigData.FireSpread);
            
            angle.x += spreadX;
            angle.y += spreadY;

            return angle;
        }

    }
}