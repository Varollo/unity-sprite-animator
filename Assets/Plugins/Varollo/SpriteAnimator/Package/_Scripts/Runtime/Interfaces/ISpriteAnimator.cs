using UnityEngine;

namespace Varollo.SpriteAnimator
{
    public interface ISpriteAnimator
    {
        float PlaybackSpeed { get; set; }
        AnimationUpdateMode UpdateMode { get; set; }

        void Play(string name);
    }
}