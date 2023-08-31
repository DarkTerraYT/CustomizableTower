using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.TowerSets;
using BTD_Mod_Helper.Extensions;

namespace CustomizableTower
{
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
            towerModel.GetAttackModel().range = CustomizableTower.Range;
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
}
