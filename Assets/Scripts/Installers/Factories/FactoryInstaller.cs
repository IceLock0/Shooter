using Weapon;
using Zenject;

namespace Configs.Factories
{
    public class FactoryInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindFireWeaponFactory();
        }

        private void BindFireWeaponFactory()
        {
            Container.Bind<FireWeaponFactory>().AsSingle().NonLazy();
        }
    }
}