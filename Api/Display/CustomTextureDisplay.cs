using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.Display;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Unity.Display;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace CustomizableTower.Api.Display
{
    public class CustomTextureDisplay: ModDisplay
    {
        public bool is2d;
        public string directory;
        private string baseDisplay;

        public CustomTextureDisplay(string baseDisplay, string directory = null!, bool is2d = false)
        {
            this.baseDisplay = baseDisplay;
            this.directory = directory;
            this.is2d = is2d;

            mod = ModHelper.GetMod<Main>();
        }
        public override string BaseDisplay => is2d ? baseDisplay : Generic2dDisplay;

        public Texture2D[] GetTextures()
        {
            string[] files = Directory.GetFiles(directory, "*.png");

            Texture2D[] textures = new Texture2D[files.Length];

            for(int i  = 0; i < files.Length; i++)
            {
                Texture2D tex = new(2, 2);
                tex.LoadFromFile(files[i]);
                textures[i] = tex;
            }

            return textures;
        }
        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            if (string.IsNullOrEmpty(baseDisplay) || string.IsNullOrEmpty(directory))
            {
                return;
            }

            Texture2D[] textures = GetTextures();

            if (is2d)
            {
                Texture2D texture = textures[0];
                node.GetRenderer<SpriteRenderer>().sprite = Sprite.Create(new Rect(0, 0, texture.width, texture.height), Vector2.zero, 10, texture);
            }
            else
            {
                for (int i = 0; i < textures.Length; i++) 
                {
                    if(node.GetMeshRenderer(i))
                    {
                        node.GetMeshRenderer(i).SetMainTexture(textures[i]);
                    }
                }
            }
        }
    }
}
