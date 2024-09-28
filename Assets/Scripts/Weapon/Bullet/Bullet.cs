using System;
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
        
        public void Initialize(Vector3 direction, float range)
        {
            _direction = direction;
            _startPosition = transform.position;
            _range = range;
        }

        private void Update()
        {
            Move();

            TryToDestroy();
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log($"Collide with = {other.name}");
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