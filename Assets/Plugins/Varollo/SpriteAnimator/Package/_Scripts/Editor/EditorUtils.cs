using UnityEditor;
using UnityEngine;

namespace Varollo.SpriteAnimator.Editor
{
    internal static class EditorUtils
    {
        public static void LayoutSeparator(float transparency = .5f) => LayoutSeparator(EditorGUIUtility.standardVerticalSpacing, transparency);
        public static void LayoutSeparator(float height, float transparency = .5f)
        {
            EditorGUI.DrawRect(EditorGUILayout.GetControlRect(false, height), new Color(0.5f, 0.5f, 0.5f, transparency));
            EditorGUILayout.Space(height * 2);
        }
    }
}