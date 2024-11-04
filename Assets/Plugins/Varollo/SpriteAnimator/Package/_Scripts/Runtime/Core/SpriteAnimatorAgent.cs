using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Varollo.SpriteAnimator
{
    public class SpriteAnimatorAgent : MonoBehaviour, ISpriteAnimatorAgent
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private SpriteAnimationSO[] animations;

        private Dictionary<string, SpriteAnimationSO> _animKeyMap;

        public virtual void UpdateSprite(string animKey, int frameCounter)
        {
            if (_animKeyMap.TryGetValue(animKey, out var anim))
                spriteRenderer.sprite = anim.GetFrame(frameCounter);

            else
                Debug.LogWarning($"[Sprite Animator <Warning>]: Couldn't play Animation of key \"{animKey}\" on Animator \"{name}\".", this);
        }

        private void Awake()
        {
            _animKeyMap = animations.ToDictionary(anim => anim.GetKey());
        }

        #region Unity Editor

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (_animKeyMap != null)
                _animKeyMap = animations.ToDictionary(anim => anim.GetKey());
        }

        private void Reset()
        {
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        }
#endif
        #endregion
    }
}