using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.Display;
using BTD_Mod_Helper.Extensions;
using HarmonyLib;
using Il2CppAssets.Scripts.Unity.Display;
using System;
using UnityEngine;

namespace CustomizableTower.Api.Display
{
    public class CustomModelDisplay : ModCustomDisplay
    {
        public sealed override string AssetBundleName => "";

        public override string PrefabName => prefabName;

        readonly string prefabName;

        public readonly AssetBundle Bundle;

        public override string MaterialName => materialName;

        readonly string materialName;

        public CustomModelDisplay(string prefabName, byte[] bundleBytes, string materialName = null!)
        {
            this.prefabName = prefabName;
            this.materialName = materialName;

            Bundle = AssetBundle.LoadFromMemory(new(bundleBytes));
            mod = ModHelper.GetMod<Main>();
        }

        [HarmonyPatch(typeof(ModCustomDisplay), "GetBasePrototype")]
        private static class ModCustomDisplay_GetBasePrototype
        {
            [HarmonyPrefix]
            public static bool Prefix(ModCustomDisplay __instance, BloonsMod mod, Action<UnityDisplayNode> onComplete)
            {
                if (__instance is CustomModelDisplay display)
                {
                    var assetBundle = display.Bundle;
                    if (display.LoadAsync)
                    {
                        assetBundle.LoadAssetAsync(display.PrefabName).add_completed(new Action<AsyncOperation>(operation =>
                        {
                            var request = operation.Cast<AssetBundleRequest>();
                            var result = request.GetResult();
                            if (result == null)
                            {
                                mod.LoggerInstance.Warning($"{display.Id}'s prefab doesn't exist at all! Prehaps you referenced the wrong bundle?");
                            }
                            else
                            {
                                var gameObject = result.TryCast<GameObject>();
                                if (gameObject != null)
                                {
                                    CompletePrototype(display, gameObject, assetBundle, onComplete);
                                }
                                else
                                {
                                    mod.LoggerInstance.Warning($"{display.PrefabName} isn't a game object but rather a {result.TypeName()}! Prehaps there's an overlap between names?");
                                }
                            }
                        }));
                    }
                    else
                    {
                        var result = assetBundle.LoadAsset(display.PrefabName); if (result == null)
                        {
                            mod.LoggerInstance.Warning($"{display.Id}'s prefab doesn't exist at all! Prehaps you referenced the wrong bundle?");
                        }
                        else
                        {
                            var gameObject = result.TryCast<GameObject>();
                            if (gameObject != null)
                            {
                                CompletePrototype(display, gameObject, assetBundle, onComplete);
                            }
                            else
                            {
                                mod.LoggerInstance.Warning($"{display.PrefabName} isn't a game object but rather a {result.TypeName()}! Prehaps there's an overlap between names?");
                            }
                        }
                    }
                    return false;
                }

                return true;
            }

            internal static void CompletePrototype(ModCustomDisplay display, GameObject gameObject, AssetBundle assetBundle,
                Action<UnityDisplayNode> onComplete)
            {
                gameObject.transform.position = new Vector3(Factory.kOffscreenPosition.x, 0, 0);
                gameObject.SetActive(false);
                var baseNode = gameObject.AddComponent<UnityDisplayNode>();
                if (!string.IsNullOrEmpty(display.MaterialName))
                {
                    try
                    {
                        var result = assetBundle.LoadAsset(display.MaterialName);
                        if (result)
                        {
                            if (result.Cast<GameObject>() != null)
                            {
                                var material = assetBundle.LoadAsset(display.MaterialName).Cast<Material>();
                                baseNode.genericRenderers[0].SetMaterial(material);
                            }
                            else
                            {
                                display.mod.LoggerInstance.Warning($"{display.MaterialName} isn't a material but rather a {result.TypeName()}");
                            }
                        }
                        else
                        {
                            display.mod.LoggerInstance.Warning($"{display.MaterialName} doesn't exist!");
                        }
                    }
                    catch (Exception e)
                    {
                        display.mod.LoggerInstance.Warning("Failed to apply material to display " + display.Id);
                    }
                }

                onComplete(baseNode);
            }
        }
    }
}
