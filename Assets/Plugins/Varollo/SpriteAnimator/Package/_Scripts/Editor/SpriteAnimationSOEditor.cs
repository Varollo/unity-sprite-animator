using System;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Varollo.SpriteAnimator.Editor
{
    [CustomEditor(typeof(SpriteAnimationSO))]
    public class SpriteAnimationSOEditor : UnityEditor.Editor
    {
        private Texture2D _tex;
        private bool _enabled;

        private void OnEnable()
        {
            _enabled = true;
            _ = AnimateTexture();
        }

        private void OnDisable()
        {
            _enabled = false;
        }

        public override bool HasPreviewGUI()
        {
            return _tex != null;
        }

        public override void OnPreviewGUI(Rect r, GUIStyle background)
        {
            EditorGUI.DrawTextureTransparent(r, _tex, ScaleMode.ScaleToFit);
        }

        private async Task AnimateTexture()
        {
            for (ushort i = 0; _enabled; i++)
            {
                try { _tex = GetCroppedTexture(((SpriteAnimationSO)target).GetFrame(i)); }
                catch (IndexOutOfRangeException) { _tex = null; }

                await Task.Delay(100);
                EditorUtility.SetDirty(target);
            }            
        }

        private Texture2D GetCroppedTexture(Sprite sprite)
        {
            Texture2D croppedTex = new((int)sprite.textureRect.width, (int)sprite.textureRect.height) 
            { 
                filterMode = FilterMode.Point 
            };

            Texture2D readableTex = new(
                sprite.texture.width,
                sprite.texture.height,
                sprite.texture.format,
                sprite.texture.mipmapCount,
                linear: true, createUninitialized: true);

            Graphics.CopyTexture(sprite.texture, readableTex);

            croppedTex.SetPixels(readableTex.GetPixels(
                (int)sprite.textureRect.x, 
                (int)sprite.textureRect.y, 
                (int)sprite.textureRect.width, 
                (int)sprite.textureRect.height));
            croppedTex.Apply(true, true);
            return croppedTex;
        }
    }
}