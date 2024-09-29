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
            if(IsPlayerInSightAndInStraight())
                return (_playerTransform.position - _enemyTransform.position).normalized;

            return Vector3.zero;
        }
        
        
        private bool IsPlayerInSightAndInStraight()
        {
            Vector3 directionToPlayer = (_playerTransform.position - _enemyTransform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(directionToPlayer);
            
            if (Physics.Raycast(_enemyTransform.position, directionToPlayer, out RaycastHit hit, Mathf.Infinity))
            {
                if (hit.transform == _playerTransform)
                {
                    if (Quaternion.Angle(_enemyTransform.rotation, lookRotation) < 7f)
                    {
                        return true;
                    }
                }
            }
            
            return false;
        }
    }
}