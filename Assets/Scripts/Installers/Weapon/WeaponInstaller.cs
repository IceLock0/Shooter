using System.Collections.Generic;
using PlayerWeapon.Weapon.Bullet;
using UnityEngine;
using Weapon;
using Weapon.FireWeapon;
using Zenject;

namespace PlayerWeapon.Installers.Weapon
{
    public class WeaponInstaller : MonoInstaller
    {
        [Header("Weapon")]
        [SerializeField] private List<FireWeapon> _fireWeaponPrefabs;
        [SerializeField] private Transform _weaponHolderTransform;

        [Inject] FireWeaponFactory _fireWeaponFactory;
        
        [Header("Bullet")]
        [SerializeField] private Bullet _bulletPrefab;

        public override void InstallBindings()
        {
            BindFireWeapons();
            BindWeaponChanger();
            BindWeaponView();
        }

        private void BindFireWeapons()
        {
            List<FireWeapon> weapons = new();

            foreach (var prefab in _fireWeaponPrefabs)
            {
                var weapon = _fireWeaponFactory.CreateWeapon(new FireShootBehaviour(_bulletPrefab, prefab.WeaponData), prefab,
                    _weaponHolderTransform.position, Quaternion.identity, _weaponHolderTransform);

                weapons.Add(weapon);
                
                weapon.gameObject.SetActive(false);
            }

            Container.Bind<List<FireWeapon>>().FromInstance(weapons).AsSingle().NonLazy();
        }

        private void BindWeaponChanger()
        {
            Container.Bind<WeaponChanger>().AsSingle().NonLazy();
        }

        private void BindWeaponView()
        {
            Container.Bind<WeaponView>().AsSingle().NonLazy();
        }
    }
}