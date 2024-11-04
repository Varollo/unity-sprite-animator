using UnityEditor;
using UnityEngine;

namespace Varollo.SpriteAnimator.Editor
{
    internal partial class SpriteAnimatorSettings
    {
        private static class SettingsStyles
        {
            public static GUIStyle Title { get; }
                = new(EditorStyles.boldLabel)
                {
                    fontSize = EditorStyles.boldLabel.fontSize * 5
                };

            public static GUIStyle GlobalFrameDuration { get; }
                = new(EditorStyles.numberField);
        }

        private static class SettingsContent
        {
            public static GUIContent Title { get; }
                = new("Sprite Animator");

            public static GUIContent GlobalFrameDuration { get; }
                = new("Global Frame Duration");
        }
    }
}
