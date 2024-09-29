using System.Collections.Generic;
using PlayerWeapon.Weapon.Bullet.BulletEffects;
using Weapon.FireWeapon;

namespace Services.Factories.Weapon.DamageEffect
{
    public interface IDamageEffectFactory
    {
        List<IDamageEffect> CreateEffectsForWeapon(FireWeapon weaponPrefab);
    }
}