using Configs.Character;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

namespace Installers.Configs
{
    public class ConfigInstaller : MonoInstaller
    {
        [SerializeField] private PlayerConfig _playerConfig;
        [SerializeField] private EnemyConfig _enemyConfig;
        
        public override void InstallBindings()
        {
            BindPlayerConfig();
            BindEnemyConfig();
        }

        private void BindPlayerConfig()
        {
            Container.Bind<PlayerConfig>().FromInstance(_playerConfig).AsSingle().NonLazy();
        }
        
        private void BindEnemyConfig()
        {
            Container.Bind<EnemyConfig>().FromInstance(_enemyConfig).AsSingle().NonLazy();
        }
    }
}