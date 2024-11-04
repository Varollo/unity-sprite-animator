using System.IO;
using UnityEngine;

namespace Varollo.SpriteAnimator
{
    public class SpriteAnimatorConfigSO : ScriptableObject
    {
        private static SpriteAnimatorConfigSO _instance;

        [SerializeField, Min(float.Epsilon)] private float globalFrameDuration = .1f;

        private float? _cachedGlobalFrameDuration;

        public float GlobalFrameDuration 
        { 
            get => Application.isPlaying ? (_cachedGlobalFrameDuration ??= globalFrameDuration) : globalFrameDuration; 
            set
            {
                if (Application.isPlaying)
                    _cachedGlobalFrameDuration = value;
                else
                    globalFrameDuration = value;
            }
        }

        public static SpriteAnimatorConfigSO GetInstance()
        {
            if (_instance == null)
                _instance = LoadOrCreateAsset();
            return _instance;
        }

        private static SpriteAnimatorConfigSO LoadOrCreateAsset()
        {
            const string fileName = "Sprite Animator Configuration File";

            SpriteAnimatorConfigSO asset = Resources.Load<SpriteAnimatorConfigSO>(fileName);

            if (asset != null)
                return asset;

            asset = CreateInstance<SpriteAnimatorConfigSO>();

#if UNITY_EDITOR
            string dirPath = "Plugins/Varollo/SpriteAnimator/Package/Resources";

            if (!Directory.Exists($"{Application.dataPath}/{dirPath}"))
            {
                dirPath = "Resources/Varollo/SpriteAnimator";

                if (!Directory.Exists(dirPath))
                    Directory.CreateDirectory($"{Application.dataPath}/{dirPath}");
            }

            UnityEditor.AssetDatabase.CreateAsset(asset, $"Assets/{dirPath}/{fileName}.asset");

            UnityEditor.AssetDatabase.SaveAssets();
#endif

            return asset;
        }
    }
}
