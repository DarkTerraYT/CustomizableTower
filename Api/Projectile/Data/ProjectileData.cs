using BTD_Mod_Helper.Api.Display;
using BTD_Mod_Helper.Api.Enums;
using CustomizableTower.Api.Display;
using Il2CppAssets.Scripts.Models.GenericBehaviors;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomizableTower.Api.Projectile.Data
{
    public struct ProjectileData()
    {
        public string Name = "Projectile";
        public float Radius = 2;
        public int Pierce = 2;
        public int MaxPierce = -1; // Inf pierce
        public bool PassThroughWalls = false;
        public float Scale = 1;

        public DisplayType DisplayType = DisplayType.Texture2D;
        public string DisplayPath = "";
        public string BaseProjectileDisplay = "";
        public string PrefabName = "";
        public string AssetBundlePath = "";
        public string MaterialName = "";

        public List<string> Behaviors = [];

        public DisplayModel GetDisplayModel() 
        {
            switch (DisplayType)
            {
                case DisplayType.Invisible:
                    return new CustomTextureDisplay("", null!, true).GetDisplayModel();
                case DisplayType.Texture2D:
                    return new CustomTextureDisplay(ModDisplay.Generic2dDisplay, DisplayPath, true).GetDisplayModel();
                case DisplayType.Vanilla:
                    return new CustomTextureDisplay(BaseProjectileDisplay, null!, true).GetDisplayModel();
                case DisplayType.CustomModel:
                    return new CustomModelDisplay(PrefabName, File.ReadAllBytes(AssetBundlePath), MaterialName).GetDisplayModel();
                default:
                    return new CustomTextureDisplay("", null!, true).GetDisplayModel();

            }
        }
    }
}
