using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.ModOptions;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using Il2CppAssets.Scripts.Models.TowerSets;
using MelonLoader;
using CustomizableTower;

[assembly: MelonInfo(typeof(CustomizableTower.CustomizableTower), ModHelperData.Name, ModHelperData.Version, ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace CustomizableTower;

public class CustomizableTower : BloonsTD6Mod
{
    internal static readonly ModSettingCategory BaseTower = new("Base Tower Customization");

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
        min = 1,
        max = 999999999,
        requiresRestart = true
    };
    internal static readonly ModSettingDouble Speed = new(1)
    {
        category = BaseTower,
        displayName = "Attack Speed (In Seconds)",
        min = 0,
        max = 15,
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
        displayName = "Top Path Upgrade 1 Hit All"
    };
    internal static readonly ModSettingBool T1HitPurple = new(false)
    {
        category = TopHits,
        displayName = "Top Path Upgrade 1 Hit Purple"
    };
    internal static readonly ModSettingBool T1HitLead = new(false)
    {
        category = TopHits,
        displayName = "Top Path Upgrade 1 Hit Lead"
    };
    internal static readonly ModSettingBool T1HitFrozen = new(false)
    {
        category = TopHits,
        displayName = "Top Path Upgrade 1 Hit Frozen"
    };
    internal static readonly ModSettingBool T2HitAll = new(false)
    {
        category = TopHits,
        displayName = "Top Path Upgrade 2 Hit All"
    };
    internal static readonly ModSettingBool T2HitPurple = new(false)
    {
        category = TopHits,
        displayName = "Top Path Upgrade 2 Hit Purple"
    };
    internal static readonly ModSettingBool T2HitLead = new(false)
    {
        category = TopHits,
        displayName = "Top Path Upgrade 2 Hit Lead"
    };
    internal static readonly ModSettingBool T2HitFrozen = new(false)
    {
        category = TopHits,
        displayName = "Top Path Upgrade 2 Hit Frozen"
    };
    internal static readonly ModSettingBool T3HitAll = new(false)
    {
        category = TopHits,
        displayName = "Top Path Upgrade 3 Hit All"
    };
    internal static readonly ModSettingBool T3HitPurple = new(false)
    {
        category = TopHits,
        displayName = "Top Path Upgrade 3 Hit Purple"
    };
    internal static readonly ModSettingBool T3HitLead = new(false)
    {
        category = TopHits,
        displayName = "Top Path Upgrade 3 Hit Lead"
    };
    internal static readonly ModSettingBool T3HitFrozen = new(false)
    {
        category = TopHits,
        displayName = "Top Path Upgrade 3 Hit Frozen"
    };
    internal static readonly ModSettingBool T4HitAll = new(false)
    {
        category = TopHits,
        displayName = "Top Path Upgrade 4 Hit All"
    };
    internal static readonly ModSettingBool T4HitPurple = new(false)
    {
        category = TopHits,
        displayName = "Top Path Upgrade 4 Hit Purple"
    };
    internal static readonly ModSettingBool T4HitLead = new(false)
    {
        category = TopHits,
        displayName = "Top Path Upgrade 4 Hit Lead"
    };
    internal static readonly ModSettingBool T4HitFrozen = new(false)
    {
        category = TopHits,
        displayName = "Top Path Upgrade 4 Hit Frozen"
    };
    internal static readonly ModSettingBool T5HitAll = new(false)
    {
        category = TopHits,
        displayName = "Top Path Upgrade 5 Hit All"
    };
    internal static readonly ModSettingBool T5HitPurple = new(false)
    {
        category = TopHits,
        displayName = "Top Path Upgrade 5 Hit Purple"
    };
    internal static readonly ModSettingBool T5HitLead = new(false)
    {
        category = TopHits,
        displayName = "Top Path Upgrade 5 Hit Lead"
    };
    internal static readonly ModSettingBool T5HitFrozen = new(false)
    {
        category = TopHits,
        displayName = "Top Path Upgrade 5 Hit Frozen"
    };
    internal static readonly ModSettingCategory MiddleHits = new("Middle Path Hit Customization");
    internal static readonly ModSettingBool M1HitAll = new(false)
    {
        category = MiddleHits,
        displayName = "Middle Path Upgrade 1 Hit All"
    };
    internal static readonly ModSettingBool M1HitPurple = new(false)
    {
        category = MiddleHits,
        displayName = "Middle Path Upgrade 1 Hit Purple"
    };
    internal static readonly ModSettingBool M1HitLead = new(false)
    {
        category = MiddleHits,
        displayName = "Middle Path Upgrade 1 Hit Lead"
    };
    internal static readonly ModSettingBool M1HitFrozen = new(false)
    {
        category = MiddleHits,
        displayName = "Middle Path Upgrade 1 Hit Frozen"
    };
    internal static readonly ModSettingBool M2HitAll = new(false)
    {
        category = MiddleHits,
        displayName = "Middle Path Upgrade 2 Hit All"
    };
    internal static readonly ModSettingBool M2HitPurple = new(false)
    {
        category = MiddleHits,
        displayName = "Middle Path Upgrade 2 Hit Purple"
    };
    internal static readonly ModSettingBool M2HitLead = new(false)
    {
        category = MiddleHits,
        displayName = "Middle Path Upgrade 2 Hit Lead"
    };
    internal static readonly ModSettingBool M2HitFrozen = new(false)
    {
        category = MiddleHits,
        displayName = "Middle Path Upgrade 2 Hit Frozen"
    };
    internal static readonly ModSettingBool M3HitAll = new(false)
    {
        category = MiddleHits,
        displayName = "Middle Path Upgrade 3 Hit All"
    };
    internal static readonly ModSettingBool M3HitPurple = new(false)
    {
        category = MiddleHits,
        displayName = "Middle Path Upgrade 3 Hit Purple"
    };
    internal static readonly ModSettingBool M3HitLead = new(false)
    {
        category = MiddleHits,
        displayName = "Middle Path Upgrade 3 Hit Lead"
    };
    internal static readonly ModSettingBool M3HitFrozen = new(false)
    {
        category = MiddleHits,
        displayName = "Middle Path Upgrade 3 Hit Frozen"
    };
    internal static readonly ModSettingBool M4HitAll = new(false)
    {
        category = MiddleHits,
        displayName = "Middle Path Upgrade 4 Hit All"
    };
    internal static readonly ModSettingBool M4HitPurple = new(false)
    {
        category = MiddleHits,
        displayName = "Middle Path Upgrade 4 Hit Purple"
    };
    internal static readonly ModSettingBool M4HitLead = new(false)
    {
        category = MiddleHits,
        displayName = "Middle Path Upgrade 4 Hit Lead"
    };
    internal static readonly ModSettingBool M4HitFrozen = new(false)
    {
        category = MiddleHits,
        displayName = "Middle Path Upgrade 4 Hit Frozen"
    };
    internal static readonly ModSettingBool M5HitAll = new(false)
    {
        category = MiddleHits,
        displayName = "Middle Path Upgrade 5 Hit All"
    };
    internal static readonly ModSettingBool M5HitPurple = new(false)
    {
        category = MiddleHits,
        displayName = "Middle Path Upgrade 5 Hit Purple"
    };
    internal static readonly ModSettingBool M5HitLead = new(false)
    {
        category = MiddleHits,
        displayName = "Middle Path Upgrade 5 Hit Lead"
    };
    internal static readonly ModSettingBool M5HitFrozen = new(false)
    {
        category = MiddleHits,
        displayName = "Middle Path Upgrade 5 Hit Frozen"
    };
    internal static readonly ModSettingCategory BottomHits = new("Bottom Path Hit Customization");
    internal static readonly ModSettingBool B1HitAll = new(false)
    {
        category = BottomHits,
        displayName = "Bottom Path Upgrade 1 Hit All"
    };
    internal static readonly ModSettingBool B1HitPurple = new(false)
    {
        category = BottomHits,
        displayName = "Bottom Path Upgrade 1 Hit Purple"
    };
    internal static readonly ModSettingBool B1HitLead = new(false)
    {
        category = BottomHits,
        displayName = "Bottom Path Upgrade 1 Hit Lead"
    };
    internal static readonly ModSettingBool B1HitFrozen = new(false)
    {
        category = BottomHits,
        displayName = "Bottom Path Upgrade 1 Hit Frozen"
    };
    internal static readonly ModSettingBool B2HitAll = new(false)
    {
        category = BottomHits,
        displayName = "Bottom Path Upgrade 2 Hit All"
    };
    internal static readonly ModSettingBool B2HitPurple = new(false)
    {
        category = BottomHits,
        displayName = "Bottom Path Upgrade 2 Hit Purple"
    };
    internal static readonly ModSettingBool B2HitLead = new(false)
    {
        category = BottomHits,
        displayName = "Bottom Path Upgrade 2 Hit Lead"
    };
    internal static readonly ModSettingBool B2HitFrozen = new(false)
    {
        category = BottomHits,
        displayName = "Bottom Path Upgrade 2 Hit Frozen"
    };
    internal static readonly ModSettingBool B3HitAll = new(false)
    {
        category = BottomHits,
        displayName = "Bottom Path Upgrade 3 Hit All"
    };
    internal static readonly ModSettingBool B3HitPurple = new(false)
    {
        category = BottomHits,
        displayName = "Bottom Path Upgrade 3 Hit Purple"
    };
    internal static readonly ModSettingBool B3HitLead = new(false)
    {
        category = BottomHits,
        displayName = "Bottom Path Upgrade 3 Hit Lead"
    };
    internal static readonly ModSettingBool B3HitFrozen = new(false)
    {
        category = BottomHits,
        displayName = "Bottom Path Upgrade 3 Hit Frozen"
    };
    internal static readonly ModSettingBool B4HitAll = new(false)
    {
        category = BottomHits,
        displayName = "Bottom Path Upgrade 4 Hit All"
    };
    internal static readonly ModSettingBool B4HitPurple = new(false)
    {
        category = BottomHits,
        displayName = "Bottom Path Upgrade 4 Hit Purple"
    };
    internal static readonly ModSettingBool B4HitLead = new(false)
    {
        category = BottomHits,
        displayName = "Bottom Path Upgrade 4 Hit Lead"
    };
    internal static readonly ModSettingBool B4HitFrozen = new(false)
    {
        category = BottomHits,
        displayName = "Bottom Path Upgrade 4 Hit Frozen"
    };
    internal static readonly ModSettingBool B5HitAll = new(false)
    {
        category = BottomHits,
        displayName = "Bottom Path Upgrade 5 Hit All"
    };
    internal static readonly ModSettingBool B5HitPurple = new(false)
    {
        category = BottomHits,
        displayName = "Bottom Path Upgrade 5 Hit Purple"
    };
    internal static readonly ModSettingBool B5HitLead = new(false)
    {
        category = BottomHits,
        displayName = "Bottom Path Upgrade 5 Hit Lead"
    };
    internal static readonly ModSettingBool B5HitFrozen = new(false)
    {
        category = BottomHits,
        displayName = "Bottom Path Upgrade 5 Hit Frozen"
    };
}
internal class CustomizableTowerClass : ModTower
{
    public override TowerSet TowerSet => TowerSet.Primary;

    public override string BaseTower => TowerType.NinjaMonkey;

    public override int Cost => CustomizableTower.Cost;

    public override int TopPathUpgrades => CustomizableTower.TopPathUpgrades;

    public override int MiddlePathUpgrades => CustomizableTower.MiddlePathUpgrades;

    public override int BottomPathUpgrades => CustomizableTower.BottomPathUpgrades;
    public override string Icon => "CustomizedTower-Portrait";
    public override string Portrait => "CustomizedTower-Portrait";
    public override string DisplayName => "Customizable Tower";
    public override string Description => "Please don't use this in competitive modes, one: it could get your account flagged, and two: it ruins the fun for others.";

    public override void ModifyBaseTowerModel(TowerModel towerModel)
    {
        towerModel.ApplyDisplay<CustomizedTowerDisplay>();
        towerModel.range = CustomizableTower.Range;
        towerModel.GetWeapon().rate = CustomizableTower.Speed;
        towerModel.GetAttackModel().range =CustomizableTower.Range;
        var proj = towerModel.GetWeapon().projectile;
        proj.ApplyDisplay<CustomizedProjectileDisplay>();
        proj.GetDamageModel().damage = CustomizableTower.Damage;
        var DamageModel = proj.GetDamageModel();
        if (CustomizableTower.HitAll)
        {
            proj.GetDamageModel().immuneBloonProperties = Il2Cpp.BloonProperties.None;
        }
        else if (!CustomizableTower.HitLead && !CustomizableTower.HitPurple && !CustomizableTower.HitFrozen)
        {
            DamageModel.immuneBloonProperties = Il2Cpp.BloonProperties.Lead | Il2Cpp.BloonProperties.Purple | Il2Cpp.BloonProperties.Frozen; 
        }
        else if (!CustomizableTower.HitLead && !CustomizableTower.HitPurple && CustomizableTower.HitFrozen)
        {
            DamageModel.immuneBloonProperties = Il2Cpp.BloonProperties.Purple | Il2Cpp.BloonProperties.Lead;
        }
        else if (CustomizableTower.HitLead && !CustomizableTower.HitPurple && !CustomizableTower.HitFrozen)
        {
            DamageModel.immuneBloonProperties = Il2Cpp.BloonProperties.Purple | Il2Cpp.BloonProperties.Frozen;
        }
        else if (!CustomizableTower.HitLead && CustomizableTower.HitPurple && !CustomizableTower.HitFrozen)
        {
            DamageModel.immuneBloonProperties = Il2Cpp.BloonProperties.Lead | Il2Cpp.BloonProperties.Frozen;
        }
        else if (CustomizableTower.HitLead && !CustomizableTower.HitPurple && CustomizableTower.HitFrozen)
        {
            DamageModel.immuneBloonProperties = Il2Cpp.BloonProperties.Purple;
        }
        else if (CustomizableTower.HitLead && CustomizableTower.HitPurple && !CustomizableTower.HitFrozen)
        {
            DamageModel.immuneBloonProperties = Il2Cpp.BloonProperties.Frozen;
        }
        else if (!CustomizableTower.HitLead && CustomizableTower.HitPurple && CustomizableTower.HitFrozen)
        {
            DamageModel.immuneBloonProperties = Il2Cpp.BloonProperties.Lead;
        }
        else if (CustomizableTower.HitLead && CustomizableTower.HitPurple && CustomizableTower.HitFrozen)
        {
            DamageModel.immuneBloonProperties = Il2Cpp.BloonProperties.None;
        }
        if (CustomizableTower.SeeCamo)
        {
            towerModel.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
        }
        else if (!CustomizableTower.SeeCamo)
        {
            towerModel.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = true);
        }
    }
    public override bool IsValidCrosspath(int[] tiers) =>
        ModHelper.HasMod("UltimateCrosspathing") ? true : base.IsValidCrosspath(tiers);
}

