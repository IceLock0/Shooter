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

        private Camera _camera;
        
        public FireShootBehaviour(Bullet bulletPrefab, FireWeapon.FireWeapon.FireWeaponData weaponData)
        {
            InvariantChecker.CheckObjectInvariant(bulletPrefab, weaponData);
            _bulletPrefab = bulletPrefab;
            _weaponData = weaponData;
            
            _camera = Camera.main;
            if (!_camera)
                throw new NullReferenceException("Main camera not founded");
        }
        
        public void Shoot()
        {
            Ray ray = _camera.ScreenPointToRay(new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0));
            
            Vector3 direction = ray.direction;

            var origin = ray.origin + direction * 0.5f;
            
            var bulletsToSpawn = _weaponData.ConfigData.BulletPerShoot;

           float bulletSpacing = 0.2f;
           
           float startOffset = -(bulletsToSpawn - 1) * bulletSpacing / 2;
           
           for (int i = 0; i < bulletsToSpawn; i++)
           {
               var offset = Vector3.right * (startOffset + i * bulletSpacing);
               
               var spawnPosition = origin + offset;
               
               var bullet = GameObject.Instantiate(_bulletPrefab, spawnPosition, Quaternion.identity, null);

               Debug.Log($"Direction Before = {direction}");
               
               direction = ApplySpread(direction, _weaponData.ConfigData.FireSpread);
               
               Debug.Log($"Direction After = {direction}");
               
               bullet.Initialize(direction, _weaponData.ConfigData.Range);
           }
        }

        private Vector3 ApplySpread(Vector3 direction, float spread)
        {
            var minValue = spread - spread * 0.2f;
            var maxValue = spread + spread * 0.2f;

            Debug.Log($"MIN VALUE = {minValue}");
            Debug.Log($"MAX VALUE = {maxValue}");
            
            float rndSpreadX = Random.Range(minValue, maxValue);
            float rndSpreadY = Random.Range(minValue, maxValue);
            
            Debug.Log($"rndX= {rndSpreadX}");
            Debug.Log($"rndY = {rndSpreadY}");
            
            Quaternion spreadRotation = Quaternion.Euler(rndSpreadX, rndSpreadY, 0);

            return spreadRotation * direction;
        }
    }
}