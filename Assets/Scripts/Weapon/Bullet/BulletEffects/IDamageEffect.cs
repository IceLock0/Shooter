using Characters;
using Characters.Components;

namespace PlayerWeapon.Weapon.Bullet.BulletEffects
{
    public interface IDamageEffect
    {
        void ApplyEffect(IDamageable target);
    }
}