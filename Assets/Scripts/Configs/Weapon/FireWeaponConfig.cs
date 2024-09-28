using System;
using Enum;
using UnityEngine;

namespace Configs.Weapon
{
    [CreateAssetMenu(fileName = "FireWeapon config", menuName = "Configs/FireWeapon", order = 0)]
    public class FireWeaponConfig : ScriptableObject
    {
        [SerializeField] private WeaponType weaponType;
        
        [SerializeField] private float _damage;
        [SerializeField] private float _fireRate;
        [SerializeField] private float _range;
        [SerializeField] private float _fireSpread;
        [SerializeField] private float _reloadTime;
        [SerializeField] private int _magazineCapacity;

        public WeaponType WeaponType => weaponType;

        public float Damage => _damage;
        public float FireRate => _fireRate;
        public float Range => _range;
        public float FireSpread => _fireSpread;
        public float ReloadTime => _reloadTime;
        public int MagazineCapacity => _magazineCapacity;
        
        private void OnValidate()
        {
            if (_damage <= 0)
                _damage = .1f;

            if (_fireRate <= 0)
                _fireRate = .1f;

            if (_range <= 0)
                _range = .1f;

            if (_fireSpread <= 0)
                _fireSpread = .0f;

            if (_reloadTime <= 0)
                _reloadTime = .1f;

            if (_magazineCapacity <= 0)
                _magazineCapacity = 1;
        }
    }
}