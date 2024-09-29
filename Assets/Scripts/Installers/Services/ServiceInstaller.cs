using Services.Coroutine;
using UnityEngine;
using Zenject;

namespace Installers.Services
{
    public class ServiceInstaller : MonoInstaller
    {
        [SerializeField] private CoroutineService _coroutineService;
        
        public override void InstallBindings()
        {
            BindInputService();
            BindCoroutineService();
        }

        private void BindInputService()
        {
            Container.Bind<InputService>().AsSingle().NonLazy();
        }

        private void BindCoroutineService()
        {
            Container.Bind<ICoroutineService>().FromInstance(_coroutineService).AsSingle().NonLazy();
        }
    }
    
}