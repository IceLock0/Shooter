using System;
using System.Collections.Generic;
using Characters;
using PlayerWeapon.Weapon.Bullet.BulletEffects;
using UnityEngine;

namespace PlayerWeapon.Weapon.Bullet
{
    public class Bullet : MonoBehaviour
    {
        [Range(0.1f, 20.0f)]
        [SerializeField] private float _speed;

        private Vector3 _direction;
        private Vector3 _startPosition;
        private float _range;
        
        private float _damage;

        private List<IDamageEffect> _damageEffects;

        public void Initialize(Vector3 direction, float range, float damage, List<IDamageEffect> damageEffects)
        {
            _direction = direction;
            _startPosition = transform.position;
            _range = range;

            _damage = damage;

            _damageEffects = damageEffects;
        }

        private void Update()
        {
            Move();

            TryToDestroy();
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("Trigger");
            
            var damageable = other.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.TakeDamage(_damage);
                ApplyDamageEffects(damageable);
            }
            
            Destroy(gameObject);
        }
        
        private void ApplyDamageEffects(IDamageable target)
        {
            foreach (var effect in _damageEffects)
            {
                effect.ApplyEffect(target);
            }
        }
        
        private void Move()
        {
            transform.position += _direction * _speed * Time.deltaTime;
        }
        
        private void TryToDestroy()
        {
            if (Vector3.Distance(_startPosition, transform.position) >= _range)
                Destroy(gameObject);
        }
    }
}