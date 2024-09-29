using UnityEngine;

namespace PlayerWeapon.Weapon.Bullet
{
    public class EnemyShootDirectionProvider : IShootDirectionProvider
    {
        private Transform _enemyTransform;
        private Transform _playerTransform;

        public EnemyShootDirectionProvider(Transform enemyTransform, Transform playerTransform)
        {
            _enemyTransform = enemyTransform;
            _playerTransform = playerTransform;
        }

        public Vector3 GetShootDirection()
        {
            return (_playerTransform.position - _enemyTransform.position).normalized;
        }
    }
}