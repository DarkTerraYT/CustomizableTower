using BTD_Mod_Helper;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.ModOptions;
using CustomizableTower;
using Il2Cpp;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using Il2CppAssets.Scripts.Unity.UI_New.Popups;
using MelonLoader;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using UnityEngine;

[assembly: MelonInfo(typeof(CustomizableTower.Main), ModHelperData.Name, ModHelperData.Version, ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace CustomizableTower;

public class Main : BloonsTD6Mod
{
    public override void OnInitialize()
    {
    }
}