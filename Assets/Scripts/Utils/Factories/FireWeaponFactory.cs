using UnityEngine;

namespace Weapon
{
    public class FireWeaponFactory
    {
        public FireWeapon.FireWeapon CreateWeapon(IShootBehaviour shootBehaviour, FireWeapon.FireWeapon prefab,
            Vector3 at, Quaternion quaternion, Transform parent = null)
        {
            var weapon = Object.Instantiate(prefab, at, quaternion, parent);
            weapon.Initialize(shootBehaviour);
            return weapon;
        }
    }
}