using System;
using System.Collections;
using UnityEngine;

namespace Varollo.SpriteAnimator
{
    internal class CoroutineController : IDisposable
    {
        private readonly MonoBehaviour _unityObject;

        private IEnumerator _enumerator;

        public CoroutineController(MonoBehaviour unityObject)
        {
            _unityObject = unityObject;
        }

        public bool IsEnabled => _unityObject.enabled;

        public void Start(IEnumerator enumerator)
        {
            Stop();
            _unityObject.StartCoroutine(_enumerator = enumerator);
        }

        public void Stop()
        {
            if (_enumerator != null && _unityObject != null)
                _unityObject.StopCoroutine(_enumerator);

            _enumerator = null;
        }

        public void Pause()
        {
            if (_unityObject == null)
                Dispose();

            else if (_enumerator != null)
                _unityObject.StopCoroutine(_enumerator);
        }

        public void Resume()
        {
            if (_unityObject == null)
                Dispose();

            else if (_enumerator != null)
                _unityObject.StartCoroutine(_enumerator);
        }

        public void Dispose()
        {
            Stop();
            GC.SuppressFinalize(this);
        }
    }
}