using Services.Factories.Weapon.DamageEffect;
using Weapon;
using Weapon.Weapon;
using Zenject;

namespace Configs.Factories
{
    public class FactoryInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindFireWeaponFactory();
            BindDamageEffectFactory();
        }

        private void BindFireWeaponFactory()
        {
            Container.Bind<IFireWeaponFactory>().To<FireWeaponFactory>().AsSingle().NonLazy();
        }
        
        private void BindDamageEffectFactory()
        {
            Container.Bind<IDamageEffectFactory>().To<DamageEffectFactory>().AsSingle().NonLazy();
        }
    }
}