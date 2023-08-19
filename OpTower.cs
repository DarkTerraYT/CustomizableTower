using MelonLoader;
using BTD_Mod_Helper;
using OpTower;
using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Models.TowerSets;
using Il2CppAssets.Scripts.Models.Towers;
using BTD_Mod_Helper.Extensions;
using BTD_Mod_Helper.Api.ModOptions;
using Il2CppAssets.Scripts.Models.Towers.Filters;

[assembly: MelonInfo(typeof(OpTower.OpTower), ModHelperData.Name, ModHelperData.Version, ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace OpTower;

public class OpTower : BloonsTD6Mod
{
    public override void OnApplicationStart()
    {
        ModHelper.Msg<OpTower>("OpTower loaded!");
    }
    public static readonly ModSettingInt Cost = new(0)
    {
        minValue = 0,
        maxValue = 9999999
    };
    public static readonly ModSettingDouble Range = new(1.0)
    {
        minValue = 1.0,
        maxValue = 99999999.9,
        isSlider = true
    };
    public static readonly ModSettingInt Damage = new(1)
    {
        minValue = 1,
        maxValue = 999999999,
        isSlider = true
    };
    public static readonly ModSettingDouble Speed = new(1)
    {
        displayName = "Attack Speed",
        minValue = 0.00000000001,
        maxValue = 15,
        isSlider = true
    };
    public static readonly ModSettingBool None = new(false)
    {
        displayName = "Can Hit All Bloons"
    };
    public static readonly ModSettingBool Lead = new(false)
    {
        displayName = "Can Hit Leads"
    };
    public static readonly ModSettingBool Purple = new(false)
    {
        displayName = "Can Hit Purple"
    };
    public static readonly ModSettingBool Frozen = new(false)
    {
        displayName = "Can Pop Frozen Bloons"
    };
    public static readonly ModSettingBool Camo = new(true)
    {
        displayName = "Can See Camo (Not Affected by Can Hit All Bloons)"
    };
}
public class OpTowerClass : ModTower
{
    public override TowerSet TowerSet => TowerSet.Primary;

    public override string BaseTower => TowerType.NinjaMonkey;

    public override int Cost => OpTower.Cost;

    public override int TopPathUpgrades => 0 ;

    public override int MiddlePathUpgrades => 0;

    public override int BottomPathUpgrades => 0;
    public override string DisplayName => "Customizable Tower";
    public override string Description => "Please don't use this in competitive modes, one: it could get your account flagged, and two: it ruins the fun for others.";

    public override void ModifyBaseTowerModel(TowerModel towerModel)
    {
        towerModel.ApplyDisplay<CustomizedTowerDisplay>();
        towerModel.range += OpTower.Range;
        towerModel.GetWeapon().rate *= OpTower.Speed;
        towerModel.GetAttackModel().range +=OpTower.Range;
        var proj = towerModel.GetWeapon().projectile;
        proj.ApplyDisplay<CustomizedProjectileDisplay>();
        proj.GetDamageModel().damage = OpTower.Damage;
        var DamageModel = proj.GetDamageModel();
        if(OpTower.None == true) 
        {
            proj.GetDamageModel().immuneBloonProperties = Il2Cpp.BloonProperties.None;
        }
        else
        {
            if(!OpTower.Lead && !OpTower.Purple && !OpTower.Frozen)
            { 
                DamageModel.immuneBloonProperties = Il2Cpp.BloonProperties.Purple;
            }
            else if (OpTower.Lead && !OpTower.Purple && OpTower.Frozen)
            {
                DamageModel.immuneBloonProperties = Il2Cpp.BloonProperties.None;
                DamageModel.immuneBloonProperties = Il2Cpp.BloonProperties.Purple;
                DamageModel.immuneBloonProperties = Il2Cpp.BloonProperties.Lead;
            }
            else if (OpTower.Lead && !OpTower.Purple && OpTower.Frozen)
            {
                DamageModel.immuneBloonProperties = Il2Cpp.BloonProperties.None;
                DamageModel.immuneBloonProperties = Il2Cpp.BloonProperties.Purple;
            }
            else if (OpTower.Lead && OpTower.Purple && !OpTower.Frozen)
            {
                DamageModel.immuneBloonProperties = Il2Cpp.BloonProperties.None;
                DamageModel.immuneBloonProperties = Il2Cpp.BloonProperties.Frozen;
            }
            else if (!OpTower.Lead && OpTower.Purple && OpTower.Frozen)
            {
                DamageModel.immuneBloonProperties = Il2Cpp.BloonProperties.None;
                DamageModel.immuneBloonProperties = Il2Cpp.BloonProperties.Lead;
            }
            else if (OpTower.Lead && OpTower.Purple && OpTower.Frozen)
            {
                DamageModel.immuneBloonProperties = Il2Cpp.BloonProperties.None;
            }
        }
        if (OpTower.Camo)
        {
            towerModel.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
        }
        else if (!OpTower.Camo)
        {
            towerModel.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = true);
        }
    }
}