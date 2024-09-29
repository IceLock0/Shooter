using UnityEngine;

namespace Weapon.Weapon
{
    public interface IFireWeaponFactory
    {
        public FireWeapon.FireWeapon CreateWeaponFromPrefab(IShootBehaviour shootBehaviour,
            FireWeapon.FireWeapon prefab, Vector3 at, Quaternion rotation, Transform parent);
    }
}