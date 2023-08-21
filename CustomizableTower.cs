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
        max = 5
    };

    internal static readonly ModSettingInt TU1Damage = new(1)
    {
        category = TopPath,
        displayName = "Upgrade 1 Damage"
    };
    internal static readonly ModSettingInt TU2Damage = new(1)
    {
        category = TopPath,
        displayName = "Upgrade 2 Damage"
    };
    internal static readonly ModSettingInt TU3Damage = new(1)
    {
        category = TopPath,
        displayName = "Upgrade 3 Damage"
    };
    internal static readonly ModSettingInt TU4Damage = new(1)
    {
        category = TopPath,
        displayName = "Upgrade 4 Damage"
    };
    internal static readonly ModSettingInt TU5Damage = new(1)
    {
        category = TopPath,
        displayName = "Upgrade 5 Damage"
    };
    internal static readonly ModSettingDouble TU1Range = new(1)
    {
        category = TopPath,
        displayName = "Upgrade 1 Range"
    };
    internal static readonly ModSettingDouble TU2Range = new(1)
    {category = TopPath,
        displayName = "Upgrade 2 Range"
    };  
    internal static readonly ModSettingDouble TU3Range = new(1)
    {category = TopPath,
        displayName = "Upgrade 3 Range"
    };
    internal static readonly ModSettingDouble TU4Range = new(1)
    {category = TopPath,
        displayName = "Upgrade 4 Range"
    };
    internal static readonly ModSettingDouble TU5Range = new(1)
    {category = TopPath,
        displayName = "Upgrade 5 Range"
    };
    internal static readonly ModSettingInt TU1Pierce = new(1)
    {category = TopPath,    
        displayName = "Upgrade 1 Pierce"
    };
    internal static readonly ModSettingInt TU2Pierce = new(1)
    {category = TopPath,    
        displayName = "Upgrade 2 Pierce"
    };
    internal static readonly ModSettingInt TU3Pierce = new(1)
    {category = TopPath,
        displayName = "Upgrade 3 Pierce"
    };
    internal static readonly ModSettingInt TU4Pierce = new(1)
    {category = TopPath,
        displayName = "Upgrade 4 Pierce"
    };
    internal static readonly ModSettingInt TU5Pierce = new(1)
    {category = TopPath,
        displayName = "Upgrade 5 Pierce"
    };
    internal static readonly ModSettingDouble TU1Speed = new(1)
    {category = TopPath,
        displayName = "Upgrade 1 Attack Speed Modifier"
    };
    internal static readonly ModSettingDouble TU2Speed = new(1)
    {category = TopPath,
        displayName = "Upgrade 2 Attack Speed Modifier"
    };
    internal static readonly ModSettingDouble TU3Speed = new(1)
    {category = TopPath,
        displayName = "Upgrade 3 Attack Speed Modifier"
    };
    internal static readonly ModSettingDouble TU4Speed = new(1)
    {category = TopPath,
        displayName = "Upgrade 4 Attack Speed Modifier"
    };
    internal static readonly ModSettingDouble TU5Speed = new(1)
    {category = TopPath,
        displayName = "Upgrade 5 Attack Speed Modifier"
    };
    internal static readonly ModSettingInt TU1Cost = new(1)
    {category = TopPath,
        displayName = "Upgrade 1 Cost"
    };
    internal static readonly ModSettingInt TU2Cost = new(1)
    {category = TopPath,
        displayName = "Upgrade 2 Cost"
    };
    internal static readonly ModSettingInt TU3Cost = new(1)
    {category = TopPath,
        displayName = "Upgrade 3 Cost"
    };
    internal static readonly ModSettingInt TU4Cost = new(1)
    {category = TopPath,
        displayName = "Upgrade 4 Cost"
    };
    internal static readonly ModSettingInt TU5Cost = new(1)
    {category = TopPath,    
        displayName = "Upgrade 5 Cost"
    };
    internal static readonly ModSettingString TU1Name = new("Upgrade")
    {
        category = TopPath,
        displayName = "Upgrade 1 Name"
    };
    internal static readonly ModSettingString TU2Name = new("Upgrade")
    {
        category = TopPath,
        displayName = "Upgrade 2 Name"
    };
    internal static readonly ModSettingString TU3Name = new("Upgrade")
    {
        category = TopPath,
        displayName = "Upgrade 3 Name"
    };
    internal static readonly ModSettingString TU4Name = new("Upgrade")
    {
        category = TopPath,
        displayName = "Upgrade 4 Name"
    };
    internal static readonly ModSettingString TU5Name = new("Upgrade")
    {
        category = TopPath,
        displayName = "Upgrade 5 Name"
    };
    internal static readonly ModSettingString TU1Desc = new("This is an Upgrade.")
    {
        category= TopPath,
        displayName="Upgrade 1 Description"
    };
    internal static readonly ModSettingString TU2Desc = new("This is an Upgrade.")
    {
        category = TopPath,
        displayName = "Upgrade 2 Description"
    };
    internal static readonly ModSettingString TU3Desc = new("This is an Upgrade.")
    {
        category = TopPath,
        displayName = "Upgrade 3 Description"
    };
    internal static readonly ModSettingString TU4Desc = new("This is an Upgrade.")
    {
        category = TopPath,
        displayName = "Upgrade 4 Description"
    };
    internal static readonly ModSettingString TU5Desc = new("This is an Upgrade.")
    {
        category = TopPath,
        displayName = "Upgrade 5 Description"
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
}
internal class CustomizableTowerClass : ModTower
{
    public override TowerSet TowerSet => TowerSet.Primary;

    public override string BaseTower => TowerType.NinjaMonkey;

    public override int Cost => CustomizableTower.Cost;

    public override int TopPathUpgrades => CustomizableTower.TopPathUpgrades;

    public override int MiddlePathUpgrades => 0;

    public override int BottomPathUpgrades => 0;
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
}
