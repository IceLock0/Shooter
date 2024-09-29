using UnityEngine;

namespace PlayerWeapon.Weapon.Bullet
{
    public interface IShootDirectionProvider
    {
        Vector3 GetShootDirection();
    }
}