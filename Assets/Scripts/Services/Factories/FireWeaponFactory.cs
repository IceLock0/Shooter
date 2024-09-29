﻿using System.Collections.Generic;
using PlayerWeapon.Weapon.Bullet;
using UnityEngine;
using Zenject;

namespace Weapon
{
    public class FireWeaponFactory
    {
        public FireWeapon.FireWeapon CreateWeaponFromPrefab(IShootBehaviour shootBehaviour, FireWeapon.FireWeapon prefab, Vector3 at, Quaternion rotation, Transform parent = null)
        {
            var weapon = Object.Instantiate(prefab, at, rotation, parent);
            weapon.Initialize(shootBehaviour);
            weapon.gameObject.SetActive(false);
            return weapon;
        }
    }
}