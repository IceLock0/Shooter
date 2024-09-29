using System.Collections;
using UnityEngine;
using Utils;

namespace Services.Coroutine
{
    public class CoroutineService : MonoBehaviour, ICoroutineService
    {
        public UnityEngine.Coroutine StartRoutine(IEnumerator enumerator)
        {
            InvariantChecker.CheckObjectInvariant(enumerator);
            return StartCoroutine(enumerator);
        }

        public void StopRoutine(UnityEngine.Coroutine coroutine)
        {
            InvariantChecker.CheckObjectInvariant(coroutine);
            StopCoroutine(coroutine);
        }
    }
}