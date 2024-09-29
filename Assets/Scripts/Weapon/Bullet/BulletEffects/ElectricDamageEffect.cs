using System.Collections;
using Characters;
using Services.Coroutine;
using UnityEngine;
using Utils;

namespace PlayerWeapon.Weapon.Bullet.BulletEffects
{
    public class ElectricDamageEffect : IAfterHitEffect
    {
        private float _damagePerSecond;
        private float _duration;
        private float _damageInterval;

        private ICoroutineService _coroutineService;
        
        public ElectricDamageEffect(float damagePerSecond, float duration, float damageInterval, ICoroutineService coroutineService)
        {
            InvariantChecker.CheckObjectInvariant(coroutineService);
            
            _damagePerSecond = damagePerSecond;
            _duration = duration;
            _damageInterval = damageInterval;

            _coroutineService = coroutineService;
        }
        
        public void ApplyEffect(IDamageable target)
        {
            _coroutineService.StartRoutine(ApplyElectricDamageOverTime(target));
        }

        private IEnumerator ApplyElectricDamageOverTime(IDamageable target)
        {
            float timeElapsed = 0f;

            while (timeElapsed < _duration && target.IsAlive())
            {
                target.TakeDamage(_damagePerSecond);
                timeElapsed += _damageInterval;
                yield return new WaitForSeconds(_damageInterval);
            }
        }
    }
}