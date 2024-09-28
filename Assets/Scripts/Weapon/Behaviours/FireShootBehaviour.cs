using PlayerWeapon.Weapon.Bullet;
using UnityEngine;
using Utils;

namespace Weapon
{
    public class FireShootBehaviour : IShootBehaviour
    {
        private Bullet _bulletPrefab;
        private Transform _firePoint;
        private FireWeapon.FireWeapon.FireWeaponData _weaponData;

        public FireShootBehaviour(Bullet bulletPrefab, Transform firePoint, FireWeapon.FireWeapon.FireWeaponData weaponData)
        {
            InvariantChecker.CheckObjectInvariant(bulletPrefab, firePoint, weaponData);
            _bulletPrefab = bulletPrefab;
            _firePoint = firePoint;
            _weaponData = weaponData;
        }
        
        public void Shoot()
        {
           var bullet = GameObject.Instantiate(_bulletPrefab, _firePoint.position, Quaternion.identity, null);
           
           Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));

           Vector3 direction = ray.direction;

           bullet.Initialize(direction, _weaponData.ConfigData.Range);
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