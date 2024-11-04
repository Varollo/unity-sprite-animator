using System;
using System.Collections;
using UnityEngine;

namespace Varollo.SpriteAnimator
{
    internal class SpriteAnimatorController : ISpriteAnimator
    {
        private readonly CoroutineController _coroutineController;
        private readonly ISpriteAnimatorAgent _animAgent;
        
        public SpriteAnimatorController(ISpriteAnimatorAgent animAgent, MonoBehaviour unityObject) : this(animAgent, new CoroutineController(unityObject)) { }
        public SpriteAnimatorController(ISpriteAnimatorAgent spriteAnimator, CoroutineController coroutineController)
        {
            _animAgent = spriteAnimator;
            _coroutineController = coroutineController;
        }

        public float PlaybackSpeed { get; set; } = 1f;
        public AnimationUpdateMode UpdateMode { get; set; } = AnimationUpdateMode.Fixed;

        public void Play(string animKey)
        {
            _coroutineController.Start(PlayCo(animKey, UpdateMode));
        }

        private IEnumerator PlayCo(string animKey, AnimationUpdateMode updateMode)
        {
            while(_coroutineController.IsEnabled)
            {
                float t = updateMode == AnimationUpdateMode.Fixed ? Time.time : Time.unscaledTime;
                _animAgent.UpdateSprite(animKey, (ushort)(t / SpriteAnimatorConfigSO.GetInstance().GlobalFrameDuration));
                yield return null;
            }
        }
    }
}