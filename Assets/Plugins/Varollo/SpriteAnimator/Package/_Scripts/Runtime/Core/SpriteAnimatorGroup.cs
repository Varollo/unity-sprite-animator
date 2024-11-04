using System.Collections.Generic;
using UnityEngine;

namespace Varollo.SpriteAnimator
{
    public class SpriteAnimatorGroup : MonoBehaviour, ISpriteAnimator, ISpriteAnimatorAgent
    {
        [SerializeField] private List<SpriteAnimatorAgent> _animators = new();

        private SpriteAnimatorController _controller;

        public float PlaybackSpeed { get => _controller.PlaybackSpeed; set => _controller.PlaybackSpeed = value; }
        public AnimationUpdateMode UpdateMode { get => _controller.UpdateMode; set => _controller.UpdateMode = value; }

        public void Play(string name) => _controller.Play(name);

        private void Awake() => _controller = new(this, this);

        public void UpdateSprite(string animKey, int frameCounter) => _animators.ForEach(anim => anim.UpdateSprite(animKey, frameCounter));
    }
}