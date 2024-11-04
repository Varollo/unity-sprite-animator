using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Varollo.SpriteAnimator.Editor
{
    internal partial class SpriteAnimatorSettings : SettingsProvider
    {
        public SpriteAnimatorSettings(string path, SettingsScope scopes, IEnumerable<string> keywords = null) 
            : base(path, scopes, keywords) { }

        public override void OnGUI(string searchContext)
        {
            SpriteAnimatorConfigSO instance = SpriteAnimatorConfigSO.GetInstance();

            DrawTitleGUI();            
            DrawFrameDurationGUI(instance);
        }

        private static void DrawTitleGUI()
        {
            EditorGUILayout.LabelField(
                label: SettingsContent.Title,
                style: SettingsStyles.Title,
                options: GUILayout.Height(
                    SettingsStyles.Title.CalcHeight(
                        SettingsContent.Title, EditorGUILayout.GetControlRect().width)));

            EditorGUILayout.LabelField("by Varollo.", new GUIStyle(EditorStyles.boldLabel) { alignment = TextAnchor.UpperRight });            
            EditorUtils.LayoutSeparator();
        }

        private void DrawFrameDurationGUI(SpriteAnimatorConfigSO instance)
        {
            instance.GlobalFrameDuration = EditorGUILayout.FloatField(SettingsContent.GlobalFrameDuration, instance.GlobalFrameDuration, SettingsStyles.GlobalFrameDuration);
        }

        [SettingsProvider]
        public static SettingsProvider CreateSettingsProvider()
        {
            return new SpriteAnimatorSettings("Project/Sprite Animator", SettingsScope.Project, GetSearchKeywordsFromGUIContentProperties<UnityEditor.Graphs.Styles>());
        }
    }
}
