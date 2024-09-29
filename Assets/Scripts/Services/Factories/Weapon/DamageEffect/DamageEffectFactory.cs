using System.Collections.Generic;
using Configs.Weapon;
using PlayerWeapon.Enum;
using PlayerWeapon.Weapon.Bullet.BulletEffects;
using Services.Coroutine;
using UnityEngine;
using Weapon.FireWeapon;
using Zenject;

namespace Services.Factories.Weapon.DamageEffect
{
    public class DamageEffectFactory : IDamageEffectFactory
    {
        [Inject] private ICoroutineService _coroutineService;

        public List<IDamageEffect> CreateEffectsForWeapon(FireWeapon weaponPrefab)
        {
            var effects = new List<IDamageEffect>();

            switch (weaponPrefab.WeaponData.ConfigData.WeaponType)
            {
                case FireWeaponType.ELECTROGUN:
                    if (weaponPrefab.WeaponData.ConfigData is FireWeaponWithElectroEffectConfig electroConfig)
                    {
                        effects.Add(new ElectricDamageEffect(electroConfig.DamagePerInterval, electroConfig.Duration,
                            electroConfig.DamageInterval, _coroutineService));
                    }
                    break;
            }
            return effects;
        }
    }
}