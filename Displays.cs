﻿using BTD_Mod_Helper.Api.Display;
using Il2CppAssets.Scripts.Unity.Display;

namespace CustomizableTower
{
    internal class CustomizedTowerDisplay : ModDisplay2D
    {
        protected override string TextureName => "CustomizedTowerDisplay";
    }

    internal class CustomizedProjectileDisplay : ModDisplay
    {
        public override string BaseDisplay => Generic2dDisplay;

        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            Set2DTexture(node, Name);
        }
    }
    internal class CustomizableParagonDisplay : ModDisplay2D
    {
        protected override string TextureName => "CustomizedTowerParagonDisplay";
    }
}
