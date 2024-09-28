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
        [SerializeField] private List<FireWeapon> _fireWeaponPrefabs;
        [SerializeField] private Bullet _bulletPrefab;

        public override void InstallBindings()
        {
            BindFireWeaponsPrefabs();
            BindWeaponChanger();
            BindWeaponView();
        }

        private void BindFireWeaponsPrefabs()
        {
            Container.Bind<List<FireWeapon>>().FromInstance(_fireWeaponPrefabs).AsSingle().NonLazy();
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