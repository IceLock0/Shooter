using System;
using System.Collections.Generic;
using System.Linq;
using Enum;
using UnityEngine;
using Zenject;


namespace Weapon
{
    public class WeaponView : IDisposable
    {
        private List<FireWeapon.FireWeapon> _fireWeapons;
        
        private WeaponChanger _weaponChanger;
        
        [Inject]
        public void Initialize(WeaponChanger weaponChanger, List<FireWeapon.FireWeapon> fireWeapons)
        {
            _weaponChanger = weaponChanger;
            
            _fireWeapons = fireWeapons;

            _weaponChanger.WeaponChanged += SetCurrentWeapon;
        }
        
        private void SetCurrentWeapon(WeaponType weaponType)
        {
            foreach (var weapon in _fireWeapons)
                weapon.gameObject.SetActive(weapon.IsWeaponTypeMatch(weaponType));
        }

        public void Dispose()
        {
            _weaponChanger.WeaponChanged -= SetCurrentWeapon;
        }
    }
}