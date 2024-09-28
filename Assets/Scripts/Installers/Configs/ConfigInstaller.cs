using DefaultNamespace;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

namespace Installers.Configs
{
    public class ConfigInstaller : MonoInstaller
    {
        [SerializeField] private PlayerConfig _playerConfig;
        
        public override void InstallBindings()
        {
            BindPlayerConfig();
        }

        private void BindPlayerConfig()
        {
            Container.Bind<PlayerConfig>().FromInstance(_playerConfig).AsSingle().NonLazy();
        }
    }
}