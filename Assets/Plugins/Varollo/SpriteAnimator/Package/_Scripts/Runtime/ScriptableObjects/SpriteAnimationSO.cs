using System;
using System.Collections.Generic;
using UnityEngine;

namespace Varollo.SpriteAnimator
{
    [CreateAssetMenu(fileName = "New Sprite Animation", menuName = "Sprite Animator/Animation")]
    public class SpriteAnimationSO : ScriptableObject
    {
        [SerializeField] private string key;
        [SerializeField] private WrapMode wrapMode;
        [SerializeField] private FrameInfo[] frames;

        private List<int> _spriteIDs;

        public string GetKey()
        {
            return key;
        }

        public Sprite GetFrame(int index)
        {
            _spriteIDs ??= CreateIDList(frames);

            return frames[_spriteIDs[Mathf.Abs(wrapMode switch
            {
                WrapMode.Loop => index % _spriteIDs.Count,
                WrapMode.PingPong => Oscillate(_spriteIDs.Count - 1, index),
                WrapMode.ClampForever => Mathf.Min(index, _spriteIDs.Count - 1),
                _ => index >= _spriteIDs.Count ? 0 : index,
            })]].Sprite;
        }

        private void Reset()
        {
            key = name;
        }

        private void OnValidate()
        {
            if (Application.isPlaying || _spriteIDs != null)
                _spriteIDs = null;

            for (int i = 0; i < frames.Length; i++)
                if (frames[i].FrameLength <= 0)
                    frames[i] = new() { Sprite = frames[i].Sprite, FrameLength = 1 };
        }

        private static List<int> CreateIDList(FrameInfo[] frames)
        {
            List<int> idList = new();
            
            // There's probably a better way to do this, but who cares?
            for(int i = 0; i < frames.Length; i++)
                for (int j = 0; j < frames[i].FrameLength; j++)
                    idList.Add(i);

            return idList;
        }

        private static int Oscillate(int max, int k) => (k + max) % (2 * max) - max;

        [System.Serializable]
        private struct FrameInfo
        {
            public Sprite Sprite;
            [Min(1)] public int FrameLength;

            public FrameInfo(int frameLength = 1) : this() => FrameLength = frameLength;

            public static implicit operator FrameInfo(Sprite sprite) => new() { Sprite = sprite };
        }
    }
}
