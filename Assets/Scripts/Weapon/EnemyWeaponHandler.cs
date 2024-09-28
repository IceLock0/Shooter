using System;
using System.Collections.Generic;
using Configs.Character;
using UnityEngine;
using Weapon.FireWeapon;
using Zenject;
using Random = UnityEngine.Random;

namespace PlayerWeapon.Weapon
{
    public class EnemyWeaponHandler : MonoBehaviour
    {
        private EnemyConfig _enemyConfig;
        private float _attackTimer;

        private FireWeapon _currentWeapon;

        [Inject]
        public void Initialize(EnemyConfig enemyConfig, List<FireWeapon> fireWeapons)
        {
            _enemyConfig = enemyConfig;
            InitializeRandomWeapon(fireWeapons);

            if (_currentWeapon == null)
                throw new NullReferenceException($"Enemy`s weapon not set.");
        }
        
        private void Update()
        {
            if(IsCanShoot())
                _currentWeapon.Shoot();
        }

        private bool IsCanShoot()
        {
            var timeExpired = _attackTimer >= _enemyConfig.AttackRate;

            if (timeExpired)
                _attackTimer = 0.0f;
            else _attackTimer += Time.deltaTime;
            
            
            return timeExpired;
        } 

        private void InitializeRandomWeapon(List<FireWeapon> fireWeapons) =>
            _currentWeapon = fireWeapons[Random.Range(0, fireWeapons.Count - 1)];
    }
}