using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.ModOptions;
using MelonLoader;
using CustomizableTower;
using System;
using System.Reflection;
using System.IO;
using Il2CppAssets.Scripts.Unity.UI_New.Popups;
using System.Linq;
using UnityEngine;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;

[assembly: MelonInfo(typeof(CustomizableTower.CustomizableTower), ModHelperData.Name, ModHelperData.Version, ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace CustomizableTower;

public class CustomizableTower : BloonsTD6Mod
{

    static bool CreatedExportedDataFolder = false;

    static string ConfigFile = Path.Combine(ModHelper.ModHelperDirectory, "Mod Settings", "CustomizableTower.json");

    public override void OnApplicationStart()
    { 

        CreatedExportedDataFolder = false;

        if (!Directory.Exists(DataPath))
        {
            Directory.CreateDirectory(DataPath);
        }
        if (!Directory.Exists(ExportedDataPath))
        {
            Directory.CreateDirectory(ExportedDataPath);
            CreatedExportedDataFolder = true;
        }

        CustomizableTowerClass.TotalDamage = Damage;

        ModHelper.Log<CustomizableTower>(ModHelper.ModHelperDirectory);
    }

    Assembly assembly = Assembly.GetExecutingAssembly();

    public override void OnMainMenu()
    {
        if (PopupScreen.instance != null)
        {
            if(CreatedExportedDataFolder)
            {
                PopupScreen.instance.ShowOkPopup("Created Exported Data Path!");
                CreatedExportedDataFolder = false;
            }
        }
    }

    private static void ExportData()
    {
        if (!Directory.Exists(DataPath))
        {
            Directory.CreateDirectory(DataPath);
        }

        if (!Directory.Exists(ExportedDataPath))
        {
            Directory.CreateDirectory(ExportedDataPath);
        }
        if (Directory.Exists(ExportedDataPath))
        {
            string ExportFile;

            if (IncludeExportTime)
            {
                ExportFile = Path.Combine(ExportedDataPath, ExportName + "_" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + " " + DateTime.Now.Hour + "_" + DateTime.Now.Minute + "_" + DateTime.Now.Second + ".json");
            }
            else
            {
                ExportFile = Path.Combine(ExportedDataPath, ExportName + ".json");
            }

            File.Copy(ConfigFile, ExportFile, true);

            if(PopupScreen.instance != null)
            {
                PopupScreen.instance.ShowOkPopup("Exported settings to " + ExportFile);
            }
        }
        ModHelper.Log<CustomizableTower>(ExportedDataPath);
    }

    private static void ImportData()
    {
        if (!Directory.Exists(DataPath))
        {
            Directory.CreateDirectory(DataPath);
        }

        if (!Directory.Exists(ExportedDataPath))
        {
            Directory.CreateDirectory(ExportedDataPath);
        }
        if (Directory.Exists(ExportedDataPath))
        {
            string ImportFile = Path.Combine(ExportedDataPath, ImportName + ".json");

            try
            {
                File.Copy(ImportFile, ConfigFile, true);
            }
            catch(Exception exception)
            {
                ModHelper.Error<CustomizableTower>("File " + ImportFile + " Doesn't Exist!");
                ModHelper.Error<CustomizableTower>("Stacktrace: " + exception.StackTrace);

                if (PopupScreen.instance != null)
                {
                    PopupScreen.instance.ShowOkPopup("Failed to import settings. Check console for more info.");
                }
            }

            if(!File.Exists(ImportFile))
            {
                ModHelper.Error<CustomizableTower>("File " + ImportFile + " Doesn't Exist!");

                if (PopupScreen.instance != null)
                {
                    PopupScreen.instance.ShowOkPopup("Failed to import settings. Check console for more info.");
                }

                return;
            }
            else
            {

            }

            if (PopupScreen.instance != null)
            {
                Action<string> quit = restart => Application.Quit(-1);
                Action<string> idk = action => PopupScreen.instance.ShowSetNamePopup("Imported Settings!",
                    "For changes to take place, you'll need to restart the game. Press OK to close BTD6", quit, "OK");

                PopupScreen.instance.ShowSetNamePopup("Import Settings?",
                    "Doing this will replace your current settings.", idk, "Import");
            }
        }
        ModHelper.Log<CustomizableTower>(ExportedDataPath);
    }

    public override void OnUpdate()
    {
        if (ExportSettings.JustPressed())
        {
            ExportData();
        }
        if (ImportSettings.JustPressed())
        {
            ImportData();
        }
    }

    public static string DataPath = Path.Combine(ModHelper.ModHelperDirectory, "Customizable Mods", "CustomizableTower", "Data");
    public static string ExportedDataPath = Path.Combine(DataPath, "Exported Data");


    internal static readonly ModSettingCategory ExportnImport = new("Exporting and Importing");

    internal static readonly ModSettingHotkey ExportSettings = new(KeyCode.Keypad1) 
    {
        category = ExportnImport
    };

    internal static readonly ModSettingHotkey ImportSettings = new(KeyCode.Keypad0)
    {
        category = ExportnImport,
    };

    internal static readonly ModSettingString ExportName = new("CustomizableTower") 
    {
        displayName = "Export Name (No Spaces!)",
        category= ExportnImport,
        description = "What to call the exported settings file (without .json) NO SPACES!!"
    };

    internal static readonly ModSettingString ImportName = new("CustomizableTower")
    {
        category = ExportnImport,
        description = "Which file to import (without .json)"
    };

    internal static readonly ModSettingBool IncludeExportTime = new(false)
    {
        category= ExportnImport,
        description = "Wether or not the include the time of the export in the name. This does make it so that the name is longer."
    };

    internal static readonly ModSettingCategory BaseTower = new("Base Tower Customization");

    internal static readonly ModSettingBool TowerExpires = new(false)
    {
        requiresRestart = true,
        category = BaseTower,
        description = "Adds/Keeps TowerExpireModel on your tower, allowing your tower to expire like a sub tower"
    };
    internal static readonly ModSettingInt TowerExpireTime = new(30)
    {
        requiresRestart = true,
        category = BaseTower,
        description = "How many seconds it takes for the tower to expire (if this number is reached first then the tower will destroy itself)"
    };
    internal static readonly ModSettingInt TowerExpireRounds = new(5)
    {
        requiresRestart = true,
        category = BaseTower,
        description = "How many rounds until the tower expires (if this number is reached first then the tower will destroy itself)"
    };
    internal static readonly ModSettingBool TowerExpiresOnDefeatScreen = new(false)
    {
        requiresRestart = true,
        category = BaseTower,
        description = "If you lose the tower expires"
    };
    internal static readonly ModSettingBool TowerExpiresOnRoundEnd = new(false)
    {
        requiresRestart = true,
        category = BaseTower,
        description = "Does the same thing as if you set "
    };

    internal static readonly ModSettingInt Cost = new(0)
    {
        category = BaseTower,
        min = 0,
        max = 999999999,
        requiresRestart = true
    };
    internal static readonly ModSettingDouble Range = new(10.0)
    {
        category = BaseTower,
        min = 1.0,
        max = 9999999999,
        requiresRestart = true
    };
    internal static readonly ModSettingInt Damage = new(1)
    {
        category = BaseTower,
        
        max = 999999999,
        requiresRestart = true
    };
    internal static readonly ModSettingDouble Speed = new(1)
    {
        category = BaseTower,
        displayName = "Attack Speed (In Seconds)",
        min = 0,
        requiresRestart = true
    };
    internal static readonly ModSettingBool GenerateMoney = new(false)
    {
        category = BaseTower,
        requiresRestart = true
    };
    internal static readonly ModSettingBool AutoCollectBananas = new(false)
    {
        category = BaseTower,
        requiresRestart = true
    };
    internal static readonly ModSettingInt MaxBananaValue = new(13)
    {
        category = BaseTower,
        requiresRestart = true
    };
    internal static readonly ModSettingInt MinBananaValue = new(13)
    {
        category = BaseTower,
        requiresRestart = true
    };
    internal static readonly ModSettingInt BananasPerRound = new(5)
    {
        category = BaseTower,
        requiresRestart = true
    };
    public static readonly ModSettingString BaseTowerId = new("DartMonkey")
    {
        category = BaseTower,
        requiresRestart = true,
        description = "Tower Id for this tower's base ID. An Example for this is Druid or SuperMonkey-050"
    }; 
    internal static readonly ModSettingDouble ProjectileSpeed = new(300)
    {
        category = BaseTower,
        description = "How fast the projectile travels. Dart Monkey's Dart is 300",
        min = 0,
        requiresRestart = true
    };
    internal static readonly ModSettingDouble ProjectileLifespan = new(0.25)
    {
        category = BaseTower,
        description = "How fast the projectile lasts. Dart Monkey's Dart is 0.25",
        min = 0,
        requiresRestart = true
    };

    internal static readonly ModSettingCategory BaseTowerDamageModifiers = new("Base Tower Damage Modifiers");

    internal static readonly ModSettingBool Moabs = new(false)
    {
        category = BaseTowerDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingDouble MoabsDamageMulti = new(1)
    {
        category= BaseTowerDamageModifiers,
        requiresRestart=true
    };

    internal static readonly ModSettingDouble MoabsDamageAdditive = new(1)
    {
        category = BaseTowerDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingBool Ceramics = new(false)
    {
        category = BaseTowerDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingDouble CeramicDamageMulti = new(1)
    {
        category = BaseTowerDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingDouble CeramicDamageAdditive = new(1)
    {
        category = BaseTowerDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingBool Fortified = new(false)
    {
        category = BaseTowerDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingDouble FortifiedDamageMulti = new(1)
    {
        category = BaseTowerDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingDouble FortifiedDamageAdditive = new(1)
    {
        category = BaseTowerDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingCategory TopPathDamageModifiers = new("Top Path Damage Modifiers");

    internal static readonly ModSettingBool T1Moabs = new(false)
    {
        category = TopPathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingDouble T1MoabsDamageMulti = new(1)
    {
        category = TopPathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingDouble T1MoabsDamageAdditive = new(1)
    {
        category = TopPathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingBool T1Ceramics = new(false)
    {
        category = TopPathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingDouble T1CeramicDamageMulti = new(1)
    {
        category = TopPathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingDouble T1CeramicDamageAdditive = new(1)
    {
        category = TopPathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingBool T1Fortified = new(false)
    {
        category = TopPathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingDouble T1FortifiedDamageMulti = new(1)
    {
        category = TopPathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingDouble T1FortifiedDamageAdditive = new(1)
    {
        category = TopPathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingBool T2Moabs = new(false)
    {
        category = TopPathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingDouble T2MoabsDamageMulti = new(1)
    {
        category = TopPathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingDouble T2MoabsDamageAdditive = new(1)
    {
        category = TopPathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingBool T2Ceramics = new(false)
    {
        category = TopPathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingDouble T2CeramicDamageMulti = new(1)
    {
        category = TopPathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingDouble T2CeramicDamageAdditive = new(1)
    {
        category = TopPathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingBool T2Fortified = new(false)
    {
        category = TopPathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingDouble T2FortifiedDamageMulti = new(1)
    {
        category = TopPathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingDouble T2FortifiedDamageAdditive = new(1)
    {
        category = TopPathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingBool T3Moabs = new(false)
    {
        category = TopPathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingDouble T3MoabsDamageMulti = new(1)
    {
        category = TopPathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingDouble T3MoabsDamageAdditive = new(1)
    {
        category = TopPathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingBool T3Ceramics = new(false)
    {
        category = TopPathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingDouble T3CeramicDamageMulti = new(1)
    {
        category = TopPathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingDouble T3CeramicDamageAdditive = new(1)
    {
        category = TopPathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingBool T3Fortified = new(false)
    {
        category = TopPathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingDouble T3FortifiedDamageMulti = new(1)
    {
        category = TopPathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingDouble T3FortifiedDamageAdditive = new(1)
    {
        category = TopPathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingBool T4Moabs = new(false)
    {
        category = TopPathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingDouble T4MoabsDamageMulti = new(1)
    {
        category = TopPathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingDouble T4MoabsDamageAdditive = new(1)
    {
        category = TopPathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingBool T4Ceramics = new(false)
    {
        category = TopPathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingDouble T4CeramicDamageMulti = new(1)
    {
        category = TopPathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingDouble T4CeramicDamageAdditive = new(1)
    {
        category = TopPathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingBool T4Fortified = new(false)
    {
        category = TopPathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingDouble T4FortifiedDamageMulti = new(1)
    {
        category = TopPathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingDouble T4FortifiedDamageAdditive = new(1)
    {
        category = TopPathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingBool T5Moabs = new(false)
    {
        category = TopPathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingDouble T5MoabsDamageMulti = new(1)
    {
        category = TopPathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingDouble T5MoabsDamageAdditive = new(1)
    {
        category = TopPathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingBool T5Ceramics = new(false)
    {
        category = TopPathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingDouble T5CeramicDamageMulti = new(1)
    {
        category = TopPathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingDouble T5CeramicDamageAdditive = new(1)
    {
        category = TopPathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingBool T5Fortified = new(false)
    {
        category = TopPathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingDouble T5FortifiedDamageMulti = new(1)
    {
        category = TopPathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingDouble T5FortifiedDamageAdditive = new(1)
    {
        category = TopPathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingCategory MiddlePathDamageModifiers = new("Middle Path Damage Modifiers");

    internal static readonly ModSettingBool M1Moabs = new(false)
    {
        category = MiddlePathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingDouble M1MoabsDamageMulti = new(1)
    {
        category = MiddlePathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingDouble M1MoabsDamageAdditive = new(1)
    {
        category = MiddlePathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingBool M1Ceramics = new(false)
    {
        category = MiddlePathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingDouble M1CeramicDamageMulti = new(1)
    {
        category = MiddlePathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingDouble M1CeramicDamageAdditive = new(1)
    {
        category = MiddlePathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingBool M1Fortified = new(false)
    {
        category = MiddlePathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingDouble M1FortifiedDamageMulti = new(1)
    {
        category = MiddlePathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingDouble M1FortifiedDamageAdditive = new(1)
    {
        category = MiddlePathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingBool M2Moabs = new(false)
    {
        category = MiddlePathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingDouble M2MoabsDamageMulti = new(1)
    {
        category = MiddlePathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingDouble M2MoabsDamageAdditive = new(1)
    {
        category = MiddlePathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingBool M2Ceramics = new(false)
    {
        category = MiddlePathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingDouble M2CeramicDamageMulti = new(1)
    {
        category = MiddlePathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingDouble M2CeramicDamageAdditive = new(1)
    {
        category = MiddlePathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingBool M2Fortified = new(false)
    {
        category = MiddlePathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingDouble M2FortifiedDamageMulti = new(1)
    {
        category = MiddlePathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingDouble M2FortifiedDamageAdditive = new(1)
    {
        category = MiddlePathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingBool M3Moabs = new(false)
    {
        category = MiddlePathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingDouble M3MoabsDamageMulti = new(1)
    {
        category = MiddlePathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingDouble M3MoabsDamageAdditive = new(1)
    {
        category = MiddlePathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingBool M3Ceramics = new(false)
    {
        category = MiddlePathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingDouble M3CeramicDamageMulti = new(1)
    {
        category = MiddlePathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingDouble M3CeramicDamageAdditive = new(1)
    {
        category = MiddlePathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingBool M3Fortified = new(false)
    {
        category = MiddlePathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingDouble M3FortifiedDamageMulti = new(1)
    {
        category = MiddlePathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingDouble M3FortifiedDamageAdditive = new(1)
    {
        category = MiddlePathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingBool M4Moabs = new(false)
    {
        category = MiddlePathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingDouble M4MoabsDamageMulti = new(1)
    {
        category = MiddlePathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingDouble M4MoabsDamageAdditive = new(1)
    {
        category = MiddlePathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingBool M4Ceramics = new(false)
    {
        category = MiddlePathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingDouble M4CeramicDamageMulti = new(1)
    {
        category = MiddlePathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingDouble M4CeramicDamageAdditive = new(1)
    {
        category = MiddlePathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingBool M4Fortified = new(false)
    {
        category = MiddlePathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingDouble M4FortifiedDamageMulti = new(1)
    {
        category = MiddlePathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingDouble M4FortifiedDamageAdditive = new(1)
    {
        category = MiddlePathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingBool M5Moabs = new(false)
    {
        category = MiddlePathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingDouble M5MoabsDamageMulti = new(1)
    {
        category = MiddlePathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingDouble M5MoabsDamageAdditive = new(1)
    {
        category = MiddlePathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingBool M5Ceramics = new(false)
    {
        category = MiddlePathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingDouble M5CeramicDamageMulti = new(1)
    {
        category = MiddlePathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingDouble M5CeramicDamageAdditive = new(1)
    {
        category = MiddlePathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingBool M5Fortified = new(false)
    {
        category = MiddlePathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingDouble M5FortifiedDamageMulti = new(1)
    {
        category = MiddlePathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingDouble M5FortifiedDamageAdditive = new(1)
    {
        category = MiddlePathDamageModifiers,
        requiresRestart = true
    };
    internal static readonly ModSettingCategory BottomPathDamageModifiers = new("Bottom Path Damage Modifiers");

    internal static readonly ModSettingBool B1Moabs = new(false)
    {
        category = BottomPathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingDouble B1MoabsDamageMulti = new(1)
    {
        category = BottomPathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingDouble B1MoabsDamageAdditive = new(1)
    {
        category = BottomPathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingBool B1Ceramics = new(false)
    {
        category = BottomPathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingDouble B1CeramicDamageMulti = new(1)
    {
        category = BottomPathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingDouble B1CeramicDamageAdditive = new(1)
    {
        category = BottomPathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingBool B1Fortified = new(false)
    {
        category = BottomPathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingDouble B1FortifiedDamageMulti = new(1)
    {
        category = BottomPathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingDouble B1FortifiedDamageAdditive = new(1)
    {
        category = BottomPathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingBool B2Moabs = new(false)
    {
        category = BottomPathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingDouble B2MoabsDamageMulti = new(1)
    {
        category = BottomPathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingDouble B2MoabsDamageAdditive = new(1)
    {
        category = BottomPathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingBool B2Ceramics = new(false)
    {
        category = BottomPathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingDouble B2CeramicDamageMulti = new(1)
    {
        category = BottomPathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingDouble B2CeramicDamageAdditive = new(1)
    {
        category = BottomPathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingBool B2Fortified = new(false)
    {
        category = BottomPathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingDouble B2FortifiedDamageMulti = new(1)
    {
        category = BottomPathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingDouble B2FortifiedDamageAdditive = new(1)
    {
        category = BottomPathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingBool B3Moabs = new(false)
    {
        category = BottomPathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingDouble B3MoabsDamageMulti = new(1)
    {
        category = BottomPathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingDouble B3MoabsDamageAdditive = new(1)
    {
        category = BottomPathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingBool B3Ceramics = new(false)
    {
        category = BottomPathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingDouble B3CeramicDamageMulti = new(1)
    {
        category = BottomPathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingDouble B3CeramicDamageAdditive = new(1)
    {
        category = BottomPathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingBool B3Fortified = new(false)
    {
        category = BottomPathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingDouble B3FortifiedDamageMulti = new(1)
    {
        category = BottomPathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingDouble B3FortifiedDamageAdditive = new(1)
    {
        category = BottomPathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingBool B4Moabs = new(false)
    {
        category = BottomPathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingDouble B4MoabsDamageMulti = new(1)
    {
        category = BottomPathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingDouble B4MoabsDamageAdditive = new(1)
    {
        category = BottomPathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingBool B4Ceramics = new(false)
    {
        category = BottomPathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingDouble B4CeramicDamageMulti = new(1)
    {
        category = BottomPathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingDouble B4CeramicDamageAdditive = new(1)
    {
        category = BottomPathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingBool B4Fortified = new(false)
    {
        category = BottomPathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingDouble B4FortifiedDamageMulti = new(1)
    {
        category = BottomPathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingDouble B4FortifiedDamageAdditive = new(1)
    {
        category = BottomPathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingBool B5Moabs = new(false)
    {
        category = BottomPathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingDouble B5MoabsDamageMulti = new(1)
    {
        category = BottomPathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingDouble B5MoabsDamageAdditive = new(1)
    {
        category = BottomPathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingBool B5Ceramics = new(false)
    {
        category = BottomPathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingDouble B5CeramicDamageMulti = new(1)
    {
        category = BottomPathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingDouble B5CeramicDamageAdditive = new(1)
    {
        category = BottomPathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingBool B5Fortified = new(false)
    {
        category = BottomPathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingDouble B5FortifiedDamageMulti = new(1)
    {
        category = BottomPathDamageModifiers,
        requiresRestart = true
    };

    internal static readonly ModSettingDouble B5FortifiedDamageAdditive = new(1)
    {
        category = BottomPathDamageModifiers,
        requiresRestart = true
    };


    internal static readonly ModSettingCategory ProjectileType = new("Projectile Type");

    internal static readonly ModSettingBool Dart = new(true)
    {
        category = ProjectileType,
        requiresRestart = true
    };

    internal static readonly ModSettingBool Bomb = new(false)
    {
        category = ProjectileType,
        requiresRestart = true
    };

    internal static readonly ModSettingBool Mortar = new(false)
    {
        category = ProjectileType,
        requiresRestart = true
    };

    internal static readonly ModSettingBool Tack = new(false)
    {
        category = ProjectileType,
        requiresRestart = true
    };

    internal static readonly ModSettingBool Laser = new(false)
    {
        category = ProjectileType,
        requiresRestart = true
    };

    internal static readonly ModSettingBool LaserShock = new(false)
    {
        category = ProjectileType,
        requiresRestart=true
    };

    internal static readonly ModSettingBool Rocket = new(false)
    {
        category = ProjectileType,
        requiresRestart = true
    };

    internal static readonly ModSettingBool Plasma = new(false)
    {
        category = ProjectileType,
        requiresRestart = true
    };

    internal static readonly ModSettingBool MonkeyRang = new(false)
    {
        category = ProjectileType,
        requiresRestart = true
    };

    internal static readonly ModSettingBool SunAvatarBeam = new(false)
    {
        category = ProjectileType,
        requiresRestart = true
    };

    internal static readonly ModSettingBool SunGod = new(false)
    {
        category = ProjectileType,
        requiresRestart = true
    };

    internal static readonly ModSettingBool TrueSunGod = new(false)
    {
        category = ProjectileType,
        requiresRestart = true
    };

    internal static readonly ModSettingBool Glue = new(false)
    {
        category = ProjectileType,
        requiresRestart = true
    };

    internal static readonly ModSettingBool Sniper = new(false)
    {
        category = ProjectileType,
        requiresRestart = true
    };

    internal static readonly ModSettingBool Magic = new(false)
    {
        category = ProjectileType,
        requiresRestart = true
    };

    internal static readonly ModSettingBool Shurikan = new(false)
    {
        category = ProjectileType,
        requiresRestart = true
    };

    internal static readonly ModSettingBool Potion = new(false)
    {
        category = ProjectileType,
        requiresRestart = true
    };

    internal static readonly ModSettingBool Thorn = new(false)
    {
        category = ProjectileType,
        requiresRestart = true
    };

    internal static readonly ModSettingBool Spikes = new(false)
    {
        category = ProjectileType,
        requiresRestart = true
    };

    internal static readonly ModSettingBool SpikedMines = new(false)
    {
        category = ProjectileType,
        requiresRestart = true
    };


    internal static readonly ModSettingBool Nail = new(false)
    {
        category = ProjectileType,
        requiresRestart = true
    };

    internal static readonly ModSettingBool Boomerangs = new(false)
    {
        category = ProjectileType,
        requiresRestart = true 
    };

    internal static readonly ModSettingBool Ice = new(false)
    {
        category = ProjectileType,
        requiresRestart = true
    };

    internal static readonly ModSettingBool TechTerror = new(false)
    {
        category = ProjectileType,
        requiresRestart = true
    };
    internal static readonly ModSettingBool AntiBloon = new(false)
    {
        category = ProjectileType,
        requiresRestart = true
    };

    internal static readonly ModSettingCategory TopPath = new("Top Path Customization");

    internal static readonly ModSettingInt TopPathUpgrades = new(5)
    {
        category = TopPath,
        min = 0,
        max = 5,
        requiresRestart = true
    };

    internal static readonly ModSettingInt TU1Damage = new(1)
    {
        category = TopPath,
        displayName = "Upgrade 1 Damage",
        requiresRestart = true
    };
    internal static readonly ModSettingInt TU2Damage = new(1)
    {
        category = TopPath,
        displayName = "Upgrade 2 Damage",
        requiresRestart = true
    };
    internal static readonly ModSettingInt TU3Damage = new(1)
    {
        category = TopPath,
        displayName = "Upgrade 3 Damage",
        requiresRestart = true
    };
    internal static readonly ModSettingInt TU4Damage = new(1)
    {
        category = TopPath,
        displayName = "Upgrade 4 Damage",
        requiresRestart = true
    };
    internal static readonly ModSettingInt TU5Damage = new(1)
    {
        category = TopPath,
        displayName = "Upgrade 5 Damage",
        requiresRestart = true
    };
    internal static readonly ModSettingDouble TU1Range = new(1)
    {
        category = TopPath,
        displayName = "Upgrade 1 Range",
        requiresRestart = true
    };
    internal static readonly ModSettingDouble TU2Range = new(1)
    {category = TopPath,
        displayName = "Upgrade 2 Range",
        requiresRestart = true
    };  
    internal static readonly ModSettingDouble TU3Range = new(1)
    {category = TopPath,
        displayName = "Upgrade 3 Range",
        requiresRestart = true
    };
    internal static readonly ModSettingDouble TU4Range = new(1)
    {category = TopPath,
        displayName = "Upgrade 4 Range",
        requiresRestart = true
    };
    internal static readonly ModSettingDouble TU5Range = new(1)
    {category = TopPath,
        displayName = "Upgrade 5 Range",
        requiresRestart = true
    };
    internal static readonly ModSettingInt TU1Pierce = new(1)
    {category = TopPath,    
        displayName = "Upgrade 1 Pierce",
        requiresRestart = true
    };
    internal static readonly ModSettingInt TU2Pierce = new(1)
    {category = TopPath,    
        displayName = "Upgrade 2 Pierce",
        requiresRestart = true
    };
    internal static readonly ModSettingInt TU3Pierce = new(1)
    {category = TopPath,
        displayName = "Upgrade 3 Pierce",
        requiresRestart = true
    };
    internal static readonly ModSettingInt TU4Pierce = new(1)
    {category = TopPath,
        displayName = "Upgrade 4 Pierce",
        requiresRestart = true
    };
    internal static readonly ModSettingInt TU5Pierce = new(1)
    {category = TopPath,
        displayName = "Upgrade 5 Pierce",
        requiresRestart = true
    };
    internal static readonly ModSettingDouble TU1Speed = new(1)
    {category = TopPath,
        displayName = "Upgrade 1 Attack Speed Modifier",
        requiresRestart = true
    };
    internal static readonly ModSettingDouble TU2Speed = new(1)
    {category = TopPath,
        displayName = "Upgrade 2 Attack Speed Modifier",
        requiresRestart = true
    };
    internal static readonly ModSettingDouble TU3Speed = new(1)
    {category = TopPath,
        displayName = "Upgrade 3 Attack Speed Modifier",
        requiresRestart = true
    };
    internal static readonly ModSettingDouble TU4Speed = new(1)
    {category = TopPath,
        displayName = "Upgrade 4 Attack Speed Modifier",
        requiresRestart = true
    };
    internal static readonly ModSettingDouble TU5Speed = new(1)
    {category = TopPath,
        displayName = "Upgrade 5 Attack Speed Modifier",
        requiresRestart = true
    };
    internal static readonly ModSettingInt TU1Cost = new(1)
    {category = TopPath,
        displayName = "Upgrade 1 Cost",
        requiresRestart = true
    };
    internal static readonly ModSettingInt TU2Cost = new(1)
    {category = TopPath,
        displayName = "Upgrade 2 Cost",
        requiresRestart = true
    };
    internal static readonly ModSettingInt TU3Cost = new(1)
    {category = TopPath,
        displayName = "Upgrade 3 Cost",
        requiresRestart = true
    };
    internal static readonly ModSettingInt TU4Cost = new(1)
    {category = TopPath,
        displayName = "Upgrade 4 Cost",
        requiresRestart = true
    };
    internal static readonly ModSettingInt TU5Cost = new(1)
    {category = TopPath,    
        displayName = "Upgrade 5 Cost",
        requiresRestart = true
    };
    internal static readonly ModSettingString TU1Name = new("Upgrade")
    {
        category = TopPath,
        displayName = "Upgrade 1 Name",
        requiresRestart = true
    };
    internal static readonly ModSettingString TU2Name = new("Upgrade")
    {
        category = TopPath,
        displayName = "Upgrade 2 Name",
        requiresRestart = true
    };
    internal static readonly ModSettingString TU3Name = new("Upgrade")
    {
        category = TopPath,
        displayName = "Upgrade 3 Name",
        requiresRestart = true
    };
    internal static readonly ModSettingString TU4Name = new("Upgrade")
    {
        category = TopPath,
        displayName = "Upgrade 4 Name",
        requiresRestart = true
    };
    internal static readonly ModSettingString TU5Name = new("Upgrade")
    {
        category = TopPath,
        displayName = "Upgrade 5 Name",
        requiresRestart = true
    };
    internal static readonly ModSettingString TU1Desc = new("This is an Upgrade.")
    {
        category= TopPath,
        displayName="Upgrade 1 Description",
        requiresRestart = true
    };
    internal static readonly ModSettingString TU2Desc = new("This is an Upgrade.")
    {
        category = TopPath,
        displayName = "Upgrade 2 Description",
        requiresRestart = true
    };
    internal static readonly ModSettingString TU3Desc = new("This is an Upgrade.")
    {
        category = TopPath,
        displayName = "Upgrade 3 Description",
        requiresRestart = true
    };
    internal static readonly ModSettingString TU4Desc = new("This is an Upgrade.")
    {
        category = TopPath,
        displayName = "Upgrade 4 Description",
        requiresRestart = true
    };
    internal static readonly ModSettingString TU5Desc = new("This is an Upgrade.")
    {
        category = TopPath,
        displayName = "Upgrade 5 Description",
        requiresRestart = true
    };
    internal static readonly ModSettingCategory MiddlePath = new("Middle Path Customization");

    internal static readonly ModSettingInt MiddlePathUpgrades = new(5)
    {
        category = MiddlePath,
        min = 0,
        max = 5,
        requiresRestart = true
    };

    internal static readonly ModSettingInt MU1Damage = new(1)
    {
        category = MiddlePath,
        displayName = "Upgrade 1 Damage",
        requiresRestart = true
    };
    internal static readonly ModSettingInt MU2Damage = new(1)
    {
        category = MiddlePath,
        displayName = "Upgrade 2 Damage",
        requiresRestart = true
    };
    internal static readonly ModSettingInt MU3Damage = new(1)
    {
        category = MiddlePath,
        displayName = "Upgrade 3 Damage",
        requiresRestart = true
    };
    internal static readonly ModSettingInt MU4Damage = new(1)
    {
        category = MiddlePath,
        displayName = "Upgrade 4 Damage",
        requiresRestart = true
    };
    internal static readonly ModSettingInt MU5Damage = new(1)
    {
        category = MiddlePath,
        displayName = "Upgrade 5 Damage",
        requiresRestart = true
    };
    internal static readonly ModSettingDouble MU1Range = new(1)
    {
        category = MiddlePath,
        displayName = "Upgrade 1 Range",
        requiresRestart = true
    };
    internal static readonly ModSettingDouble MU2Range = new(1)
    {
        category = MiddlePath,
        displayName = "Upgrade 2 Range",
        requiresRestart = true
    };
    internal static readonly ModSettingDouble MU3Range = new(1)
    {
        category = MiddlePath,
        displayName = "Upgrade 3 Range",
        requiresRestart = true
    };
    internal static readonly ModSettingDouble MU4Range = new(1)
    {
        category = MiddlePath,
        displayName = "Upgrade 4 Range",
        requiresRestart = true
    };
    internal static readonly ModSettingDouble MU5Range = new(1)
    {
        category = MiddlePath,
        displayName = "Upgrade 5 Range",
        requiresRestart = true
    };
    internal static readonly ModSettingInt MU1Pierce = new(1)
    {
        category = MiddlePath,
        displayName = "Upgrade 1 Pierce",
        requiresRestart = true
    };
    internal static readonly ModSettingInt MU2Pierce = new(1)
    {
        category = MiddlePath,
        displayName = "Upgrade 2 Pierce",
        requiresRestart = true
    };
    internal static readonly ModSettingInt MU3Pierce = new(1)
    {
        category = MiddlePath,
        displayName = "Upgrade 3 Pierce",
        requiresRestart = true
    };
    internal static readonly ModSettingInt MU4Pierce = new(1)
    {
        category = MiddlePath,
        displayName = "Upgrade 4 Pierce",
        requiresRestart = true
    };
    internal static readonly ModSettingInt MU5Pierce = new(1)
    {
        category = MiddlePath,
        displayName = "Upgrade 5 Pierce",
        requiresRestart = true
    };
    internal static readonly ModSettingDouble MU1Speed = new(1)
    {
        category = MiddlePath,
        displayName = "Upgrade 1 Attack Speed Modifier",
        requiresRestart = true
    };
    internal static readonly ModSettingDouble MU2Speed = new(1)
    {
        category = MiddlePath,
        displayName = "Upgrade 2 Attack Speed Modifier",
        requiresRestart = true
    };
    internal static readonly ModSettingDouble MU3Speed = new(1)
    {
        category = MiddlePath,
        displayName = "Upgrade 3 Attack Speed Modifier",
        requiresRestart = true
    };
    internal static readonly ModSettingDouble MU4Speed = new(1)
    {
        category = MiddlePath,
        displayName = "Upgrade 4 Attack Speed Modifier",
        requiresRestart = true
    };
    internal static readonly ModSettingDouble MU5Speed = new(1)
    {
        category = MiddlePath,
        displayName = "Upgrade 5 Attack Speed Modifier",
        requiresRestart = true
    };
    internal static readonly ModSettingInt MU1Cost = new(1)
    {
        category = MiddlePath,
        displayName = "Upgrade 1 Cost",
        requiresRestart = true
    };
    internal static readonly ModSettingInt MU2Cost = new(1)
    {
        category = MiddlePath,
        displayName = "Upgrade 2 Cost",
        requiresRestart = true
    };
    internal static readonly ModSettingInt MU3Cost = new(1)
    {
        category = MiddlePath,
        displayName = "Upgrade 3 Cost",
        requiresRestart = true
    };
    internal static readonly ModSettingInt MU4Cost = new(1)
    {
        category = MiddlePath,
        displayName = "Upgrade 4 Cost",
        requiresRestart = true
    };
    internal static readonly ModSettingInt MU5Cost = new(1)
    {
        category = MiddlePath,
        displayName = "Upgrade 5 Cost",
        requiresRestart = true
    };
    internal static readonly ModSettingString MU1Name = new("Upgrade")
    {
        category = MiddlePath,
        displayName = "Upgrade 1 Name",
        requiresRestart = true
    };
    internal static readonly ModSettingString MU2Name = new("Upgrade")
    {
        category = MiddlePath,
        displayName = "Upgrade 2 Name",
        requiresRestart = true
    };
    internal static readonly ModSettingString MU3Name = new("Upgrade")
    {
        category = MiddlePath,
        displayName = "Upgrade 3 Name",
        requiresRestart = true
    };
    internal static readonly ModSettingString MU4Name = new("Upgrade")
    {
        category = MiddlePath,
        displayName = "Upgrade 4 Name",
        requiresRestart = true
    };
    internal static readonly ModSettingString MU5Name = new("Upgrade")
    {
        category = MiddlePath,
        displayName = "Upgrade 5 Name",
        requiresRestart = true
    };
    internal static readonly ModSettingString MU1Desc = new("This is an Upgrade.")
    {
        category = MiddlePath,
        displayName = "Upgrade 1 Description",
        requiresRestart = true
    };
    internal static readonly ModSettingString MU2Desc = new("This is an Upgrade.")
    {
        category = MiddlePath,
        displayName = "Upgrade 2 Description",
        requiresRestart = true
    };
    internal static readonly ModSettingString MU3Desc = new("This is an Upgrade.")
    {
        category = MiddlePath,
        displayName = "Upgrade 3 Description",
        requiresRestart = true
    };
    internal static readonly ModSettingString MU4Desc = new("This is an Upgrade.")
    {
        category = MiddlePath,
        displayName = "Upgrade 4 Description",
        requiresRestart = true
    };
    internal static readonly ModSettingString MU5Desc = new("This is an Upgrade.")
    {
        category = MiddlePath,
        displayName = "Upgrade 5 Description",
        requiresRestart = true
    };
    internal static readonly ModSettingCategory BottomPath = new("Bottom Path Customization");

    internal static readonly ModSettingInt BottomPathUpgrades = new(5)
    {
        category = BottomPath,
        min = 0,
        max = 5,
        requiresRestart = true
    };

    internal static readonly ModSettingInt BU1Damage = new(1)
    {
        category = BottomPath,
        displayName = "Upgrade 1 Damage",
        requiresRestart = true
    };
    internal static readonly ModSettingInt BU2Damage = new(1)
    {
        category = BottomPath,
        displayName = "Upgrade 2 Damage",
        requiresRestart = true
    };
    internal static readonly ModSettingInt BU3Damage = new(1)
    {
        category = BottomPath,
        displayName = "Upgrade 3 Damage",
        requiresRestart = true
    };
    internal static readonly ModSettingInt BU4Damage = new(1)
    {
        category = BottomPath,
        displayName = "Upgrade 4 Damage",
        requiresRestart = true
    };
    internal static readonly ModSettingInt BU5Damage = new(1)
    {
        category = BottomPath,
        displayName = "Upgrade 5 Damage",
        requiresRestart = true
    };
    internal static readonly ModSettingDouble BU1Range = new(1)
    {
        category = BottomPath,
        displayName = "Upgrade 1 Range",
        requiresRestart = true
    };
    internal static readonly ModSettingDouble BU2Range = new(1)
    {
        category = BottomPath,
        displayName = "Upgrade 2 Range",
        requiresRestart = true
    };
    internal static readonly ModSettingDouble BU3Range = new(1)
    {
        category = BottomPath,
        displayName = "Upgrade 3 Range",
        requiresRestart = true
    };
    internal static readonly ModSettingDouble BU4Range = new(1)
    {
        category = BottomPath,
        displayName = "Upgrade 4 Range",
        requiresRestart = true
    };
    internal static readonly ModSettingDouble BU5Range = new(1)
    {
        category = BottomPath,
        displayName = "Upgrade 5 Range",
        requiresRestart = true
    };
    internal static readonly ModSettingInt BU1Pierce = new(1)
    {
        category = BottomPath,
        displayName = "Upgrade 1 Pierce",
        requiresRestart = true
    };
    internal static readonly ModSettingInt BU2Pierce = new(1)
    {
        category = BottomPath,
        displayName = "Upgrade 2 Pierce",
        requiresRestart = true
    };
    internal static readonly ModSettingInt BU3Pierce = new(1)
    {
        category = BottomPath,
        displayName = "Upgrade 3 Pierce",
        requiresRestart = true
    };
    internal static readonly ModSettingInt BU4Pierce = new(1)
    {
        category = BottomPath,
        displayName = "Upgrade 4 Pierce",
        requiresRestart = true
    };
    internal static readonly ModSettingInt BU5Pierce = new(1)
    {
        category = BottomPath,
        displayName = "Upgrade 5 Pierce",
        requiresRestart = true
    };
    internal static readonly ModSettingDouble BU1Speed = new(1)
    {
        category = BottomPath,
        displayName = "Upgrade 1 Attack Speed Modifier",
        requiresRestart = true
    };
    internal static readonly ModSettingDouble BU2Speed = new(1)
    {
        category = BottomPath,
        displayName = "Upgrade 2 Attack Speed Modifier",
        requiresRestart = true
    };
    internal static readonly ModSettingDouble BU3Speed = new(1)
    {
        category = BottomPath,
        displayName = "Upgrade 3 Attack Speed Modifier",
        requiresRestart = true
    };
    internal static readonly ModSettingDouble BU4Speed = new(1)
    {
        category = BottomPath,
        displayName = "Upgrade 4 Attack Speed Modifier",
        requiresRestart = true
    };
    internal static readonly ModSettingDouble BU5Speed = new(1)
    {
        category = BottomPath,
        displayName = "Upgrade 5 Attack Speed Modifier",
        requiresRestart = true
    };
    internal static readonly ModSettingInt BU1Cost = new(1)
    {
        category = BottomPath,
        displayName = "Upgrade 1 Cost",
        requiresRestart = true
    };
    internal static readonly ModSettingInt BU2Cost = new(1)
    {
        category = BottomPath,
        displayName = "Upgrade 2 Cost",
        requiresRestart = true
    };
    internal static readonly ModSettingInt BU3Cost = new(1)
    {
        category = BottomPath,
        displayName = "Upgrade 3 Cost",
        requiresRestart = true
    };
    internal static readonly ModSettingInt BU4Cost = new(1)
    {
        category = BottomPath,
        displayName = "Upgrade 4 Cost",
        requiresRestart = true
    };
    internal static readonly ModSettingInt BU5Cost = new(1)
    {
        category = BottomPath,
        displayName = "Upgrade 5 Cost",
        requiresRestart = true
    };
    internal static readonly ModSettingString BU1Name = new("Upgrade")
    {
        category = BottomPath,
        displayName = "Upgrade 1 Name",
        requiresRestart = true
    };
    internal static readonly ModSettingString BU2Name = new("Upgrade")
    {
        category = BottomPath,
        displayName = "Upgrade 2 Name",
        requiresRestart = true
    };
    internal static readonly ModSettingString BU3Name = new("Upgrade")
    {
        category = BottomPath,
        displayName = "Upgrade 3 Name",
        requiresRestart = true
    };
    internal static readonly ModSettingString BU4Name = new("Upgrade")
    {
        category = BottomPath,
        displayName = "Upgrade 4 Name",
        requiresRestart = true
    };
    internal static readonly ModSettingString BU5Name = new("Upgrade")
    {
        category = BottomPath,
        displayName = "Upgrade 5 Name",
        requiresRestart = true
    };
    internal static readonly ModSettingString BU1Desc = new("This is an Upgrade.")
    {
        category = BottomPath,
        displayName = "Upgrade 1 Description",
        requiresRestart = true
    };
    internal static readonly ModSettingString BU2Desc = new("This is an Upgrade.")
    {
        category = BottomPath,
        displayName = "Upgrade 2 Description",
        requiresRestart = true
    };
    internal static readonly ModSettingString BU3Desc = new("This is an Upgrade.")
    {
        category = BottomPath,
        displayName = "Upgrade 3 Description",
        requiresRestart = true
    };
    internal static readonly ModSettingString BU4Desc = new("This is an Upgrade.")
    {
        category = BottomPath,
        displayName = "Upgrade 4 Description",
        requiresRestart = true
    };
    internal static readonly ModSettingString BU5Desc = new("This is an Upgrade.")
    {
        category = BottomPath,
        displayName = "Upgrade 5 Description",
        requiresRestart = true
    };
    internal static readonly ModSettingCategory Hits = new("Hit Options");

    internal static readonly ModSettingInt Pierce = new(1)
    {
        category = Hits,
        requiresRestart = true
    };
    internal static readonly ModSettingBool HitAll = new(false)
    {
        category = Hits,
        displayName = "Can Hit All Bloons",
        requiresRestart = true
    };
    internal static readonly ModSettingBool HitLead = new(false)
    {
        category= Hits,
        displayName = "Can Hit Leads",
        requiresRestart = true
    };
    internal static readonly ModSettingBool HitPurple = new(false)
    {
        category = Hits,
        displayName = "Can Hit Purple",
        requiresRestart = true
    };
    internal static readonly ModSettingBool HitFrozen = new(false)
    {
        category = Hits,
        displayName = "Can Pop Frozen Bloons",
        requiresRestart = true
    };
    internal static readonly ModSettingBool SeeCamo = new(true)
    {
        category = Hits,
        displayName = "Can See Camo (Not Affected by Can Hit All Bloons)",
        requiresRestart = true
    };
    internal static readonly ModSettingCategory TopHits = new("Top Path Hit Customization");
    internal static readonly ModSettingBool T1HitAll = new(false)
    {
        category = TopHits,
        displayName = "Top Path Upgrade 1 Hit All",
        requiresRestart = true
    };
    internal static readonly ModSettingBool T1HitPurple = new(false)
    {
        category = TopHits,
        displayName = "Top Path Upgrade 1 Hit Purple",
        requiresRestart = true
    };
    internal static readonly ModSettingBool T1HitLead = new(false)
    {
        category = TopHits,
        displayName = "Top Path Upgrade 1 Hit Lead",
        requiresRestart = true
    };
    internal static readonly ModSettingBool T1HitFrozen = new(false)
    {
        category = TopHits,
        displayName = "Top Path Upgrade 1 Hit Frozen",
        requiresRestart = true
    };
    internal static readonly ModSettingBool T2HitAll = new(false)
    {
        category = TopHits,
        displayName = "Top Path Upgrade 2 Hit All",
        requiresRestart = true
    };
    internal static readonly ModSettingBool T2HitPurple = new(false)
    {
        category = TopHits,
        displayName = "Top Path Upgrade 2 Hit Purple",
        requiresRestart = true
    };
    internal static readonly ModSettingBool T2HitLead = new(false)
    {
        category = TopHits,
        displayName = "Top Path Upgrade 2 Hit Lead",
        requiresRestart = true
    };
    internal static readonly ModSettingBool T2HitFrozen = new(false)
    {
        category = TopHits,
        displayName = "Top Path Upgrade 2 Hit Frozen",
        requiresRestart = true
    };
    internal static readonly ModSettingBool T3HitAll = new(false)
    {
        category = TopHits,
        displayName = "Top Path Upgrade 3 Hit All",
        requiresRestart = true
    };
    internal static readonly ModSettingBool T3HitPurple = new(false)
    {
        category = TopHits,
        displayName = "Top Path Upgrade 3 Hit Purple",
        requiresRestart = true
    };
    internal static readonly ModSettingBool T3HitLead = new(false)
    {
        category = TopHits,
        displayName = "Top Path Upgrade 3 Hit Lead",
        requiresRestart = true
    };
    internal static readonly ModSettingBool T3HitFrozen = new(false)
    {
        category = TopHits,
        displayName = "Top Path Upgrade 3 Hit Frozen",
        requiresRestart = true
    };
    internal static readonly ModSettingBool T4HitAll = new(false)
    {
        category = TopHits,
        displayName = "Top Path Upgrade 4 Hit All",
        requiresRestart = true
    };
    internal static readonly ModSettingBool T4HitPurple = new(false)
    {
        category = TopHits,
        displayName = "Top Path Upgrade 4 Hit Purple",
        requiresRestart = true
    };
    internal static readonly ModSettingBool T4HitLead = new(false)
    {
        category = TopHits,
        displayName = "Top Path Upgrade 4 Hit Lead",
        requiresRestart = true
    };
    internal static readonly ModSettingBool T4HitFrozen = new(false)
    {
        category = TopHits,
        displayName = "Top Path Upgrade 4 Hit Frozen",
        requiresRestart = true
    };
    internal static readonly ModSettingBool T5HitAll = new(false)
    {
        category = TopHits,
        displayName = "Top Path Upgrade 5 Hit All",
        requiresRestart = true
    };
    internal static readonly ModSettingBool T5HitPurple = new(false)
    {
        category = TopHits,
        displayName = "Top Path Upgrade 5 Hit Purple",
        requiresRestart = true
    };
    internal static readonly ModSettingBool T5HitLead = new(false)
    {
        category = TopHits,
        displayName = "Top Path Upgrade 5 Hit Lead",
        requiresRestart = true
    };
    internal static readonly ModSettingBool T5HitFrozen = new(false)
    {
        category = TopHits,
        displayName = "Top Path Upgrade 5 Hit Frozen",
        requiresRestart = true
    };
    internal static readonly ModSettingCategory MiddleHits = new("Middle Path Hit Customization");
    internal static readonly ModSettingBool M1HitAll = new(false)
    {
        category = MiddleHits,
        displayName = "Middle Path Upgrade 1 Hit All",
        requiresRestart = true
    };
    internal static readonly ModSettingBool M1HitPurple = new(false)
    {
        category = MiddleHits,
        displayName = "Middle Path Upgrade 1 Hit Purple",
        requiresRestart = true
    };
    internal static readonly ModSettingBool M1HitLead = new(false)
    {
        category = MiddleHits,
        displayName = "Middle Path Upgrade 1 Hit Lead",
        requiresRestart = true
    };
    internal static readonly ModSettingBool M1HitFrozen = new(false)
    {
        category = MiddleHits,
        displayName = "Middle Path Upgrade 1 Hit Frozen",
        requiresRestart = true
    };
    internal static readonly ModSettingBool M2HitAll = new(false)
    {
        category = MiddleHits,
        displayName = "Middle Path Upgrade 2 Hit All",
        requiresRestart = true
    };
    internal static readonly ModSettingBool M2HitPurple = new(false)
    {
        category = MiddleHits,
        displayName = "Middle Path Upgrade 2 Hit Purple",
        requiresRestart = true
    };
    internal static readonly ModSettingBool M2HitLead = new(false)
    {
        category = MiddleHits,
        displayName = "Middle Path Upgrade 2 Hit Lead",
        requiresRestart = true
    };
    internal static readonly ModSettingBool M2HitFrozen = new(false)
    {
        category = MiddleHits,
        displayName = "Middle Path Upgrade 2 Hit Frozen",
        requiresRestart = true
    };
    internal static readonly ModSettingBool M3HitAll = new(false)
    {
        category = MiddleHits,
        displayName = "Middle Path Upgrade 3 Hit All",
        requiresRestart = true
    };
    internal static readonly ModSettingBool M3HitPurple = new(false)
    {
        category = MiddleHits,
        displayName = "Middle Path Upgrade 3 Hit Purple",
        requiresRestart = true
    };
    internal static readonly ModSettingBool M3HitLead = new(false)
    {
        category = MiddleHits,
        displayName = "Middle Path Upgrade 3 Hit Lead",
        requiresRestart = true
    };
    internal static readonly ModSettingBool M3HitFrozen = new(false)
    {
        category = MiddleHits,
        displayName = "Middle Path Upgrade 3 Hit Frozen",
        requiresRestart = true
    };
    internal static readonly ModSettingBool M4HitAll = new(false)
    {
        category = MiddleHits,
        displayName = "Middle Path Upgrade 4 Hit All",
        requiresRestart = true
    };
    internal static readonly ModSettingBool M4HitPurple = new(false)
    {
        category = MiddleHits,
        displayName = "Middle Path Upgrade 4 Hit Purple",
        requiresRestart = true
    };
    internal static readonly ModSettingBool M4HitLead = new(false)
    {
        category = MiddleHits,
        displayName = "Middle Path Upgrade 4 Hit Lead",
        requiresRestart = true
    };
    internal static readonly ModSettingBool M4HitFrozen = new(false)
    {
        category = MiddleHits,
        displayName = "Middle Path Upgrade 4 Hit Frozen",
        requiresRestart = true
    };
    internal static readonly ModSettingBool M5HitAll = new(false)
    {
        category = MiddleHits,
        displayName = "Middle Path Upgrade 5 Hit All",
        requiresRestart = true
    };
    internal static readonly ModSettingBool M5HitPurple = new(false)
    {
        category = MiddleHits,
        displayName = "Middle Path Upgrade 5 Hit Purple",
        requiresRestart = true
    };
    internal static readonly ModSettingBool M5HitLead = new(false)
    {
        category = MiddleHits,
        displayName = "Middle Path Upgrade 5 Hit Lead",
        requiresRestart = true
    };
    internal static readonly ModSettingBool M5HitFrozen = new(false)
    {
        category = MiddleHits,
        displayName = "Middle Path Upgrade 5 Hit Frozen",
        requiresRestart = true
    };
    internal static readonly ModSettingCategory BottomHits = new("Bottom Path Hit Customization");
    internal static readonly ModSettingBool B1HitAll = new(false)
    {
        category = BottomHits,
        displayName = "Bottom Path Upgrade 1 Hit All",
        requiresRestart = true
    };
    internal static readonly ModSettingBool B1HitPurple = new(false)
    {
        category = BottomHits,
        displayName = "Bottom Path Upgrade 1 Hit Purple",
        requiresRestart = true
    };
    internal static readonly ModSettingBool B1HitLead = new(false)
    {
        category = BottomHits,
        displayName = "Bottom Path Upgrade 1 Hit Lead",
        requiresRestart = true
    };
    internal static readonly ModSettingBool B1HitFrozen = new(false)
    {
        category = BottomHits,
        displayName = "Bottom Path Upgrade 1 Hit Frozen",
        requiresRestart = true
    };
    internal static readonly ModSettingBool B2HitAll = new(false)
    {
        category = BottomHits,
        displayName = "Bottom Path Upgrade 2 Hit All",
        requiresRestart = true
    };
    internal static readonly ModSettingBool B2HitPurple = new(false)
    {
        category = BottomHits,
        displayName = "Bottom Path Upgrade 2 Hit Purple",
        requiresRestart = true
    };
    internal static readonly ModSettingBool B2HitLead = new(false)
    {
        category = BottomHits,
        displayName = "Bottom Path Upgrade 2 Hit Lead",
        requiresRestart = true
    };
    internal static readonly ModSettingBool B2HitFrozen = new(false)
    {
        category = BottomHits,
        displayName = "Bottom Path Upgrade 2 Hit Frozen",
        requiresRestart = true
    };
    internal static readonly ModSettingBool B3HitAll = new(false)
    {
        category = BottomHits,
        displayName = "Bottom Path Upgrade 3 Hit All",
        requiresRestart = true
    };
    internal static readonly ModSettingBool B3HitPurple = new(false)
    {
        category = BottomHits,
        displayName = "Bottom Path Upgrade 3 Hit Purple",
        requiresRestart = true
    };
    internal static readonly ModSettingBool B3HitLead = new(false)
    {
        category = BottomHits,
        displayName = "Bottom Path Upgrade 3 Hit Lead",
        requiresRestart = true
    };
    internal static readonly ModSettingBool B3HitFrozen = new(false)
    {
        category = BottomHits,
        displayName = "Bottom Path Upgrade 3 Hit Frozen",
        requiresRestart = true
    };
    internal static readonly ModSettingBool B4HitAll = new(false)
    {
        category = BottomHits,
        displayName = "Bottom Path Upgrade 4 Hit All",
        requiresRestart = true
    };
    internal static readonly ModSettingBool B4HitPurple = new(false)
    {
        category = BottomHits,
        displayName = "Bottom Path Upgrade 4 Hit Purple",
        requiresRestart = true
    };
    internal static readonly ModSettingBool B4HitLead = new(false)
    {
        category = BottomHits,
        displayName = "Bottom Path Upgrade 4 Hit Lead",
        requiresRestart = true
    };
    internal static readonly ModSettingBool B4HitFrozen = new(false)
    {
        category = BottomHits,
        displayName = "Bottom Path Upgrade 4 Hit Frozen",
        requiresRestart = true
    };
    internal static readonly ModSettingBool B5HitAll = new(false)
    {
        category = BottomHits,
        displayName = "Bottom Path Upgrade 5 Hit All",
        requiresRestart = true
    };
    internal static readonly ModSettingBool B5HitPurple = new(false)
    {
        category = BottomHits,
        displayName = "Bottom Path Upgrade 5 Hit Purple",
        requiresRestart = true
    };
    internal static readonly ModSettingBool B5HitLead = new(false)
    {
        category = BottomHits,
        displayName = "Bottom Path Upgrade 5 Hit Lead",
        requiresRestart = true
    };
    internal static readonly ModSettingBool B5HitFrozen = new(false)
    {
        category = BottomHits,
        displayName = "Bottom Path Upgrade 5 Hit Frozen",
        requiresRestart = true
    };
    internal static readonly ModSettingCategory UpgradeCamoOptions = new("Upgrade Camo Options");
    internal static readonly ModSettingBool T1Camo = new(false)
    {
        category = UpgradeCamoOptions,
        displayName = "Top Path Upgrade 1 Camo",
        requiresRestart = true
    };
    internal static readonly ModSettingBool T2Camo = new(false)
    {
        category = UpgradeCamoOptions,
        displayName = "Top Path Upgrade 2 Camo",
        requiresRestart = true
    };
    internal static readonly ModSettingBool T3Camo = new(false)
    {
        category = UpgradeCamoOptions,
        displayName = "Top Path Upgrade 3 Camo",
        requiresRestart = true
    };
    internal static readonly ModSettingBool T4Camo = new(false)
    {
        category = UpgradeCamoOptions,
        displayName = "Top Path Upgrade 4 Camo",
        requiresRestart = true
    };
    internal static readonly ModSettingBool T5Camo = new(false)
    {
        category = UpgradeCamoOptions,
        displayName = "Top Path Upgrade 5 Camo",
        requiresRestart = true
    };
    internal static readonly ModSettingBool M1Camo = new(false)
    {
        category = UpgradeCamoOptions,
        displayName = "Middle Path Upgrade 1 Camo",
        requiresRestart = true
    };
    internal static readonly ModSettingBool M2Camo = new(false)
    {
        category = UpgradeCamoOptions,
        displayName = "Middle Path Upgrade 2 Camo",
        requiresRestart = true
    };
    internal static readonly ModSettingBool M3Camo = new(false)
    {
        category = UpgradeCamoOptions,
        displayName = "Middle Path Upgrade 3 Camo",
        requiresRestart = true
    };
    internal static readonly ModSettingBool M4Camo = new(false)
    {
        category = UpgradeCamoOptions,
        displayName = "Middle Path Upgrade 4 Camo",
        requiresRestart = true
    };
    internal static readonly ModSettingBool M5Camo = new(false)
    {
        category = UpgradeCamoOptions,
        displayName = "Middle Path Upgrade 5 Camo",
        requiresRestart = true
    };
    internal static readonly ModSettingBool B1Camo = new(false)
    {
        category = UpgradeCamoOptions,
        displayName = "Bottom Path Upgrade 1 Camo",
        requiresRestart = true
    };
    internal static readonly ModSettingBool B2Camo = new(false)
    {
        category = UpgradeCamoOptions,
        displayName = "Bottom Path Upgrade 2 Camo",
        requiresRestart = true
    };
    internal static readonly ModSettingBool B3Camo = new(false)
    {
        category = UpgradeCamoOptions,
        displayName = "Bottom Path Upgrade 3 Camo",
        requiresRestart = true
    };
    internal static readonly ModSettingBool B4Camo = new(false)
    {
        category = UpgradeCamoOptions,
        displayName = "Bottom Path Upgrade 4 Camo",
        requiresRestart = true
    };
    internal static readonly ModSettingBool B5Camo = new(false)
    {
        category = UpgradeCamoOptions,
        displayName = "Bottom Path Upgrade 5 Camo",
        requiresRestart = true
    };
    internal static readonly ModSettingCategory MultiShot = new("Multi Shot Config");
    internal static readonly ModSettingInt MultishotNumber = new(1)
    {
        category = MultiShot,
        displayName = "Number of Darts",
        description = "The Number of Darts Shot in The Multishot, Default 1", 
        requiresRestart = true
    };
    internal static readonly ModSettingInt MultiShotOffset = new(0)
    {
        category = MultiShot,
        displayName = "Multishot Offset",
        description = "The Time Offset of the Multishot, Default 0",
        requiresRestart = true
    };
    internal static readonly ModSettingInt MultiShotRotation = new(0)
    {
        category = MultiShot,
        displayName = "Multishot Rotation",
        description = "The Rotation/Spread of the Multishot, Default 0",
        requiresRestart = true
    };
    internal static readonly ModSettingCategory TopPathMultiShot = new("Top Path Multishot");
    internal static readonly ModSettingInt T1MultiShotNumber = new(1)
    {
        category = TopPathMultiShot,
        displayName = "Top Path Upgrade 1 Number of Darts",
        description = "How Many More Darts the 1-0-0 Tower Shoots, Default 1", 
        requiresRestart = true
    };
    internal static readonly ModSettingInt T1MultiShotOffset = new(0)
    {
        category = TopPathMultiShot,
        displayName = "Top Path Upgrade 1 Multishot Offset",
        description = "The Offset For The Multishot, Default 0",
        requiresRestart = true
    };
    internal static readonly ModSettingInt T1MultiShotRotation = new(0)
    {
        category = TopPathMultiShot,
        displayName = "Top Path Upgrade 1 Multishot Rotation",
        description = "The Rotation/Spread For The Multishot, Default 0",
        requiresRestart = true
    };
    internal static readonly ModSettingInt T2MultiShotNumber = new(1)
    {
        category = TopPathMultiShot,
        displayName = "Top Path Upgrade 2 Number of Darts",
        description = "How Many More Darts the 2-0-0 Tower Shoots, Default 1", 
        requiresRestart = true
    };
    internal static readonly ModSettingInt T2MultiShotOffset = new(0)
    {
        category = TopPathMultiShot,
        displayName = "Top Path Upgrade 2 Multishot Offset",
        description = "The Offset For The Multishot, Default 0",
        requiresRestart = true
    };
    internal static readonly ModSettingInt T2MultiShotRotation = new(0)
    {
        category = TopPathMultiShot,
        displayName = "Top Path Upgrade 2 Multishot Rotation",
        description = "The Rotation/Spread For The Multishot, Default 0",
        requiresRestart = true
    };
    internal static readonly ModSettingInt T3MultiShotNumber = new(1)
    {
        category = TopPathMultiShot,
        displayName = "Top Path Upgrade 3 Number of Darts",
        description = "How Many More Darts the 3-0-0 Tower Shoots, Default 1", 
        requiresRestart = true
    };
    internal static readonly ModSettingInt T3MultiShotOffset = new(0)
    {
        category = TopPathMultiShot,
        displayName = "Top Path Upgrade 3 Multishot Offset",
        description = "The Offset For The Multishot, Default 0",
        requiresRestart = true
    };
    internal static readonly ModSettingInt T3MultiShotRotation = new(0)
    {
        category = TopPathMultiShot,
        displayName = "Top Path Upgrade 3 Multishot Rotation",
        description = "The Rotation/Spread For The Multishot, Default 0",
        requiresRestart = true
    };
    internal static readonly ModSettingInt T4MultiShotNumber = new(1)
    {
        category = TopPathMultiShot,
        displayName = "Top Path Upgrade 4 Number of Darts",
        description = "How Many More Darts the 4-0-0 Tower Shoots, Default 1", 
        requiresRestart = true
    };
    internal static readonly ModSettingInt T4MultiShotOffset = new(0)
    {
        category = TopPathMultiShot,
        displayName = "Top Path Upgrade 4 Multishot Offset",
        description = "The Offset For The Multishot, Default 0",
        requiresRestart = true
    };
    internal static readonly ModSettingInt T4MultiShotRotation = new(0)
    {
        category = TopPathMultiShot,
        displayName = "Top Path Upgrade 4 Multishot Rotation",
        description = "The Rotation/Spread For The Multishot, Default 0",
        requiresRestart = true
    };
    internal static readonly ModSettingInt T5MultiShotNumber = new(1)
    {
        category = TopPathMultiShot,
        displayName = "Top Path Upgrade 5 Number of Darts",
        description = "How Many More Darts the 5-0-0 Tower Shoots, Default 1", 
        requiresRestart = true
    };
    internal static readonly ModSettingInt T5MultiShotOffset = new(0)
    {
        category = TopPathMultiShot,
        displayName = "Top Path Upgrade 5 Multishot Offset",
        description = "The Offset For The Multishot, Default 0",
        requiresRestart = true
    };
    internal static readonly ModSettingInt T5MultiShotRotation = new(0)
    {
        category = TopPathMultiShot,
        displayName = "Top Path Upgrade 5 Multishot Rotation",
        description = "The Rotation/Spread For The Multishot, Default 0",
        requiresRestart = true
    };
    internal static readonly ModSettingCategory MiddlePathMultiShot = new("Middle Path Multishot");
    internal static readonly ModSettingInt M1MultiShotNumber = new(1)
    {
        category = MiddlePathMultiShot,
        displayName = "Middle Path Upgrade 1 Number of Darts",
        description = "How Many More Darts the 0-1-0 Tower Shoots, Default 1", 
        requiresRestart = true
    };
    internal static readonly ModSettingInt M1MultiShotOffset = new(0)
    {
        category = MiddlePathMultiShot,
        displayName = "Middle Path Upgrade 1 Multishot Offset",
        description = "The Offset For The Multishot, Default 0",
        requiresRestart = true
    };
    internal static readonly ModSettingInt M1MultiShotRotation = new(0)
    {
        category = MiddlePathMultiShot,
        displayName = "Middle Path Upgrade 1 Multishot Rotation",
        description = "The Rotation/Spread For The Multishot, Default 0",
        requiresRestart = true
    };
    internal static readonly ModSettingInt M2MultiShotNumber = new(1)
    {
        category = MiddlePathMultiShot,
        displayName = "Middle Path Upgrade 2 Number of Darts",
        description = "How Many More Darts the 0-2-0 Tower Shoots, Default 1", 
        requiresRestart = true
    };
    internal static readonly ModSettingInt M2MultiShotOffset = new(0)
    {
        category = MiddlePathMultiShot,
        displayName = "Middle Path Upgrade 2 Multishot Offset",
        description = "The Offset For The Multishot, Default 0",
        requiresRestart = true
    };
    internal static readonly ModSettingInt M2MultiShotRotation = new(0)
    {
        category = MiddlePathMultiShot,
        displayName = "Middle Path Upgrade 2 Multishot Rotation",
        description = "The Rotation/Spread For The Multishot, Default 0",
        requiresRestart = true
    };
    internal static readonly ModSettingInt M3MultiShotNumber = new(1)
    {
        category = MiddlePathMultiShot,
        displayName = "Middle Path Upgrade 3 Number of Darts",
        description = "How Many More Darts the 0-3-0 Tower Shoots, Default 1", 
        requiresRestart = true
    };
    internal static readonly ModSettingInt M3MultiShotOffset = new(0)
    {
        category = MiddlePathMultiShot,
        displayName = "Middle Path Upgrade 3 Multishot Offset",
        description = "The Offset For The Multishot, Default 0",
        requiresRestart = true
    };
    internal static readonly ModSettingInt M3MultiShotRotation = new(0)
    {
        category = MiddlePathMultiShot,
        displayName = "Middle Path Upgrade 3 Multishot Rotation",
        description = "The Rotation/Spread For The Multishot, Default 0",
        requiresRestart = true
    };
    internal static readonly ModSettingInt M4MultiShotNumber = new(1)
    {
        category = MiddlePathMultiShot,
        displayName = "Middle Path Upgrade 4 Number of Darts",
        description = "How Many More Darts the 0-5-0 Tower Shoots, Default 1", 
        requiresRestart = true
    };
    internal static readonly ModSettingInt M4MultiShotOffset = new(0)
    {
        category = MiddlePathMultiShot,
        displayName = "Middle Path Upgrade 4 Multishot Offset",
        description = "The Offset For The Multishot, Default 0",
        requiresRestart = true
    };
    internal static readonly ModSettingInt M4MultiShotRotation = new(0)
    {
        category = MiddlePathMultiShot,
        displayName = "Middle Path Upgrade 4 Multishot Rotation",
        description = "The Rotation/Spread For The Multishot, Default 0",
        requiresRestart = true
    };
    internal static readonly ModSettingInt M5MultiShotNumber = new(1)
    {
        category = MiddlePathMultiShot,
        displayName = "Middle Path Upgrade 5 Number of Darts",
        description = "How Many More Darts the 0-5-0 Tower Shoots, Default 1", 
        requiresRestart = true
    };
    internal static readonly ModSettingInt M5MultiShotOffset = new(0)
    {
        category = MiddlePathMultiShot,
        displayName = "Middle Path Upgrade 5 Multishot Offset",
        description = "The Offset For The Multishot, Default 0",
        requiresRestart = true
    };
    internal static readonly ModSettingInt M5MultiShotRotation = new(0)
    {
        category = MiddlePathMultiShot,
        displayName = "Middle Path Upgrade 5 Multishot Rotation",
        description = "The Rotation/Spread For The Multishot, Default 0",
        requiresRestart = true
    };
    internal static readonly ModSettingCategory BottomPathMultiShot = new("Bottom Path Multishot");
    internal static readonly ModSettingInt B1MultiShotNumber = new(1)
    {
        category = BottomPathMultiShot,
        displayName = "Bottom Path Upgrade 1 Number of Darts",
        description = "How Many More Darts the 0-0-1 Tower Shoots, Default 1", 
        requiresRestart = true
    };
    internal static readonly ModSettingInt B1MultiShotOffset = new(0)
    {
        category = BottomPathMultiShot,
        displayName = "Bottom Path Upgrade 1 Multishot Offset",
        description = "The Offset For The Multishot, Default 0",
        requiresRestart = true
    };
    internal static readonly ModSettingInt B1MultiShotRotation = new(0)
    {
        category = BottomPathMultiShot,
        displayName = "Bottom Path Upgrade 1 Multishot Rotation",
        description = "The Rotation/Spread For The Multishot, Default 0",
        requiresRestart = true
    };
    internal static readonly ModSettingInt B2MultiShotNumber = new(1)
    {
        category = BottomPathMultiShot,
        displayName = "Bottom Path Upgrade 2 Number of Darts",
        description = "How Many More Darts the 0-0-2 Tower Shoots, Default 1", 
        requiresRestart = true
    };
    internal static readonly ModSettingInt B2MultiShotOffset = new(0)
    {
        category = BottomPathMultiShot,
        displayName = "Bottom Path Upgrade 2 Multishot Offset",
        description = "The Offset For The Multishot, Default 0",
        requiresRestart = true
    };
    internal static readonly ModSettingInt B2MultiShotRotation = new(0)
    {
        category = BottomPathMultiShot,
        displayName = "Bottom Path Upgrade 2 Multishot Rotation",
        description = "The Rotation/Spread For The Multishot, Default 0",
        requiresRestart = true
    };
    internal static readonly ModSettingInt B3MultiShotNumber = new(1)
    {
        category = BottomPathMultiShot,
        displayName = "Bottom Path Upgrade 3 Number of Darts",
        description = "How Many More Darts the 0-0-3 Tower Shoots, Default 1", 
        requiresRestart = true
    };
    internal static readonly ModSettingInt B3MultiShotOffset = new(0)
    {
        category = BottomPathMultiShot,
        displayName = "Bottom Path Upgrade 3 Multishot Offset",
        description = "The Offset For The Multishot, Default 0",
        requiresRestart = true
    };
    internal static readonly ModSettingInt B3MultiShotRotation = new(0)
    {
        category = BottomPathMultiShot,
        displayName = "Bottom Path Upgrade 3 Multishot Rotation",
        description = "The Rotation/Spread For The Multishot, Default 0",
        requiresRestart = true
    };
    internal static readonly ModSettingInt B4MultiShotNumber = new(1)
    {
        category = BottomPathMultiShot,
        displayName = "Bottom Path Upgrade 4 Number of Darts",
        description = "How Many More Darts the 0-0-4 Tower Shoots, Default 1", 
        requiresRestart = true
    };
    internal static readonly ModSettingInt B4MultiShotOffset = new(0)
    {
        category = BottomPathMultiShot,
        displayName = "Bottom Path Upgrade 4 Multishot Offset",
        description = "The Offset For The Multishot, Default 0",
        requiresRestart = true
    };
    internal static readonly ModSettingInt B4MultiShotRotation = new(0)
    {
        category = BottomPathMultiShot,
        displayName = "Bottom Path Upgrade 4 Multishot Rotation",
        description = "The Rotation/Spread For The Multishot, Default 0",
        requiresRestart = true
    };
    internal static readonly ModSettingInt B5MultiShotNumber = new(1)
    {
        category = BottomPathMultiShot,
        displayName = "Bottom Path Upgrade 5 Number of Darts",
        description = "How Many More Darts the 0-0-5 Tower Shoots, Default 1", 
        requiresRestart = true
    };
    internal static readonly ModSettingInt B5MultiShotOffset = new(0)
    {
        category = BottomPathMultiShot,
        displayName = "Bottom Path Upgrade 5 Multishot Offset",
        description = "The Offset For The Multishot, Default 0",
        requiresRestart = true
    };
    internal static readonly ModSettingInt B5MultiShotRotation = new(0)
    {
        category = BottomPathMultiShot,
        displayName = "Bottom Path Upgrade 5 Multishot Rotation",
        description = "The Rotation/Spread For The Multishot, Default 0",
        requiresRestart = true
    };
    internal static ModSettingCategory ParagonSettings = new("Paragon Customization");
    internal static ModSettingInt ParagonCost = new(0) 
    {
        category = ParagonSettings,
        requiresRestart = true
    };
    internal static ModSettingString ParagonName = new("Paragon")
    {
        category = ParagonSettings,
        requiresRestart = true
    };
    internal static ModSettingInt ParagonDamageBuff = new(1) 
    { 
        category = ParagonSettings,
        requiresRestart = true
    };
    internal static ModSettingDouble ParagonSpeed = new(1)
    {
        category = ParagonSettings,
        requiresRestart = true
    };
    internal static ModSettingDouble ParagonRange = new(1)
    {
        category = ParagonSettings,
        requiresRestart = true
    };
    internal static ModSettingInt ParagonPierce = new(1)
    {
        category = ParagonSettings,
        requiresRestart = true
    };
    internal static readonly ModSettingString ParagonDescription = new("This is a Paragon")
    {
        category = ParagonSettings,
        requiresRestart = true
    };
    internal static ModSettingInt ParagonMultiShotNumber = new(1)
    {
        category = ParagonSettings,
        requiresRestart = true
    };
    internal static ModSettingDouble ParagonMultiShotOffset = new(0)
    {
        category = ParagonSettings,
        requiresRestart = true
    };
    internal static ModSettingDouble ParagonMultiShotAngle = new(0)
    {
        category = ParagonSettings,
        min = 0,
        requiresRestart = true
    };
}