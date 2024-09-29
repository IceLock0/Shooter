using System.Collections;

namespace Services.Coroutine
{
    public interface ICoroutineService
    {
        public UnityEngine.Coroutine StartRoutine(IEnumerator enumerator);
        public void StopRoutine(UnityEngine.Coroutine coroutine);
    }
}