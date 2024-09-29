using System.Collections.Generic;
using Configs.Character;
using UnityEngine;
using Weapon.FireWeapon;
using Weapon.View;
using Zenject;
using Random = UnityEngine.Random;

namespace PlayerWeapon.Weapon
{
    public class EnemyWeaponHandler : WeaponHandler
    {
        private EnemyConfig _enemyConfig;
        private float _attackTimer;

        [Inject]
        public void Initialize(EnemyConfig enemyConfig)
        {
            _enemyConfig = enemyConfig;

            CurrentWeapon = CreateWeapon(GetRandomWeaponPrefab());

            WeaponView weaponView = new WeaponView();
            
            weaponView.ChangeWeaponVisible(CurrentWeapon);
        }

        protected override bool IsCanShoot()
        {
            var timeExpired = _attackTimer >= _enemyConfig.AttackRate;

            if (timeExpired)
                _attackTimer = 0.0f;
            else _attackTimer += Time.deltaTime;
            
            return timeExpired;
        }

        private FireWeapon GetRandomWeaponPrefab() => FireWeaponPrefabs[Random.Range(0, FireWeaponPrefabs.Count - 1)];
    }
}