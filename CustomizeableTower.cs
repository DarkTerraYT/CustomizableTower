using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.ModOptions;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using Il2CppAssets.Scripts.Models.TowerSets;
using MelonLoader;
using OpTower;

[assembly: MelonInfo(typeof(OpTower.CustomizeableTower), ModHelperData.Name, ModHelperData.Version, ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace OpTower;

public class CustomizeableTower : BloonsTD6Mod
{
    public override void OnApplicationStart()
    {
        ModHelper.Msg<CustomizeableTower>("OpTower loaded!");
    }
    public static readonly ModSettingInt Cost = new(0)
    {
        min = 0,
        max = 999999999
    };
    public static readonly ModSettingDouble Range = new(1.0)
    {
        min = 1.0,
        max = 9999999999
    };
    public static readonly ModSettingInt Damage = new(1)
    {
        min = 1,
        max = 999999999,
    };
    public static readonly ModSettingDouble Speed = new(1)
    {
        displayName = "Attack Speed (Lower Value = Attacks Faster)",
        min = 0.00000000001,
        max = 15,
    };
    public static readonly ModSettingBool HitAll = new(false)
    {
        displayName = "Can Hit All Bloons"
    };
    public static readonly ModSettingBool HitLead = new(false)
    {
        displayName = "Can Hit Leads"
    };
    public static readonly ModSettingBool HitPurple = new(false)
    {
        displayName = "Can Hit Purple"
    };
    public static readonly ModSettingBool HitFrozen = new(false)
    {
        displayName = "Can Pop Frozen Bloons"
    };
    public static readonly ModSettingBool SeeCamo = new(true)
    {
        displayName = "Can See Camo (Not Affected by Can Hit All Bloons)"
    };
}
public class CustomizeableTowerClass : ModTower
{
    public override TowerSet TowerSet => TowerSet.Primary;

    public override string BaseTower => TowerType.NinjaMonkey;

    public override int Cost => CustomizeableTower.Cost;

    public override int TopPathUpgrades => 0 ;

    public override int MiddlePathUpgrades => 0;

    public override int BottomPathUpgrades => 0;
    public override string DisplayName => "Customizable Tower";
    public override string Description => "Please don't use this in competitive modes, one: it could get your account flagged, and two: it ruins the fun for others.";

    public override void ModifyBaseTowerModel(TowerModel towerModel)
    {
        towerModel.ApplyDisplay<CustomizedTowerDisplay>();
        towerModel.range += CustomizeableTower.Range;
        towerModel.GetWeapon().rate *= CustomizeableTower.Speed;
        towerModel.GetAttackModel().range +=CustomizeableTower.Range;
        var proj = towerModel.GetWeapon().projectile;
        proj.ApplyDisplay<CustomizedProjectileDisplay>();
        proj.GetDamageModel().damage = CustomizeableTower.Damage;
        var DamageModel = proj.GetDamageModel();
        if (CustomizeableTower.HitAll)
        {
            proj.GetDamageModel().immuneBloonProperties = Il2Cpp.BloonProperties.None;
        }
        else if (!CustomizeableTower.HitLead && !CustomizeableTower.HitPurple && !CustomizeableTower.HitFrozen)
        {
            DamageModel.immuneBloonProperties = Il2Cpp.BloonProperties.Lead | Il2Cpp.BloonProperties.Purple | Il2Cpp.BloonProperties.Frozen; 
        }
        else if (!CustomizeableTower.HitLead && !CustomizeableTower.HitPurple && CustomizeableTower.HitFrozen)
        {
            DamageModel.immuneBloonProperties = Il2Cpp.BloonProperties.Purple | Il2Cpp.BloonProperties.Lead;
        }
        else if (CustomizeableTower.HitLead && !CustomizeableTower.HitPurple && !CustomizeableTower.HitFrozen)
        {
            DamageModel.immuneBloonProperties = Il2Cpp.BloonProperties.Purple | Il2Cpp.BloonProperties.Frozen;
        }
        else if (!CustomizeableTower.HitLead && CustomizeableTower.HitPurple && !CustomizeableTower.HitFrozen)
        {
            DamageModel.immuneBloonProperties = Il2Cpp.BloonProperties.Lead | Il2Cpp.BloonProperties.Frozen;
        }
        else if (CustomizeableTower.HitLead && !CustomizeableTower.HitPurple && CustomizeableTower.HitFrozen)
        {
            DamageModel.immuneBloonProperties = Il2Cpp.BloonProperties.Purple;
        }
        else if (CustomizeableTower.HitLead && CustomizeableTower.HitPurple && !CustomizeableTower.HitFrozen)
        {
            DamageModel.immuneBloonProperties = Il2Cpp.BloonProperties.Frozen;
        }
        else if (!CustomizeableTower.HitLead && CustomizeableTower.HitPurple && CustomizeableTower.HitFrozen)
        {
            DamageModel.immuneBloonProperties = Il2Cpp.BloonProperties.Lead;
        }
        else if (CustomizeableTower.HitLead && CustomizeableTower.HitPurple && CustomizeableTower.HitFrozen)
        {
            DamageModel.immuneBloonProperties = Il2Cpp.BloonProperties.None;
        }
        if (CustomizeableTower.SeeCamo)
        {
            towerModel.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
        }
        else if (!CustomizeableTower.SeeCamo)
        {
            towerModel.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = true);
        }
    }
}