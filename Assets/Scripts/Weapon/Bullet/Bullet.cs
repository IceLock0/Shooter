using System;
using Characters;
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
        
        public void Initialize(Vector3 direction, float range, float damage)
        {
            _direction = direction;
            _startPosition = transform.position;
            _range = range;

            _damage = damage;
        }

        private void Update()
        {
            Move();

            TryToDestroy();
        }

        private void OnTriggerEnter(Collider other)
        {
            other.GetComponent<IDamageable>().TakeDamage(_damage);
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