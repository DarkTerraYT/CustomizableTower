using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.ModOptions;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using Il2CppAssets.Scripts.Models.TowerSets;
using MelonLoader;
using OpTower;

[assembly: MelonInfo(typeof(OpTower.CustomizableTower), ModHelperData.Name, ModHelperData.Version, ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace OpTower;

public class CustomizableTower : BloonsTD6Mod
{
    public static readonly ModSettingCategory Changes = new("Customizable Things, Restart the Game After Modification of These Config Options.");
    public static readonly ModSettingInt Cost = new(0)
    {
        min = 0,
        max = 999999999,
        requiresRestart = true
    };
    public static readonly ModSettingDouble Range = new(1.0)
    {
        min = 1.0,
        max = 9999999999,
        requiresRestart = true
    };
    public static readonly ModSettingInt Damage = new(1)
    {
        min = 1,
        max = 999999999,
        requiresRestart = true
    };
    public static readonly ModSettingDouble Speed = new(1)
    {
        displayName = "Attack Speed (Lower Value = Attacks Faster)",
        min = 0.00000000001,
        max = 15,
        requiresRestart = true
    };
    public static readonly ModSettingBool HitAll = new(false)
    {
        displayName = "Can Hit All Bloons",
        requiresRestart = true
    };
    public static readonly ModSettingBool HitLead = new(false)
    {
        displayName = "Can Hit Leads",
        requiresRestart = true
    };
    public static readonly ModSettingBool HitPurple = new(false)
    {
        displayName = "Can Hit Purple",
        requiresRestart = true
    };
    public static readonly ModSettingBool HitFrozen = new(false)
    {
        displayName = "Can Pop Frozen Bloons",
        requiresRestart = true
    };
    public static readonly ModSettingBool SeeCamo = new(true)
    {
        displayName = "Can See Camo (Not Affected by Can Hit All Bloons)",
        requiresRestart = true
    };
}
public class CustomizableTowerClass : ModTower
{
    public override TowerSet TowerSet => TowerSet.Primary;

    public override string BaseTower => TowerType.NinjaMonkey;

    public override int Cost => CustomizableTower.Cost;

    public override int TopPathUpgrades => 0 ;

    public override int MiddlePathUpgrades => 0;

    public override int BottomPathUpgrades => 0;
    public override string Icon => "CustomizedTower-Portrait";
    public override string Portrait => "CustomizedTower-Portrait";
    public override string DisplayName => "Customizable Tower";
    public override string Description => "Please don't use this in competitive modes, one: it could get your account flagged, and two: it ruins the fun for others.";

    public override void ModifyBaseTowerModel(TowerModel towerModel)
    {
        towerModel.ApplyDisplay<CustomizedTowerDisplay>();
        towerModel.range += CustomizableTower.Range;
        towerModel.GetWeapon().rate *= CustomizableTower.Speed;
        towerModel.GetAttackModel().range +=CustomizableTower.Range;
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