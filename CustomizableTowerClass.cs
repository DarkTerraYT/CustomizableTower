using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.TowerSets;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Weapons.Behaviors;

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
        public override ParagonMode ParagonMode => ParagonMode.Base555;
        public override string Icon => "CustomizedTower-Portrait";
        public override string Portrait => "CustomizedTower-Portrait";
        public override string DisplayName => "Customizable Tower";
        public override string Description => "Please don't use this in competitive modes, one: it could get your account flagged, and two: it ruins the fun for others.";

        public override void ModifyBaseTowerModel(TowerModel towerModel)
        {
            if(CustomizableTower.CopyAttackModel)
            {
                towerModel.GetWeapon(0).rate = 9999999999999999999;
                towerModel.AddBehavior(Game.instance.model.GetTowerFromId(CustomizableTower.CopyAttackModelString));
                towerModel.ApplyDisplay<CustomizedTowerDisplay>();
                towerModel.range = CustomizableTower.Range;
                towerModel.GetWeapon(1).projectile.pierce = CustomizableTower.Pierce;
                towerModel.GetWeapon(1).rate = CustomizableTower.Speed;
                towerModel.GetAttackModel(1).range = CustomizableTower.Range;
                var proj = towerModel.GetWeapon(1).projectile;
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
                towerModel.GetWeapon(1).emission = new ArcEmissionModel("Emission", CustomizableTower.MultishotNumber + CustomizableTower.MultishotNumber, CustomizableTower.MultiShotOffset, CustomizableTower.MultiShotRotation, null, false, false);
            }
            else if (!CustomizableTower.CopyAttackModel)
            {
                towerModel.ApplyDisplay<CustomizedTowerDisplay>();
                towerModel.range = CustomizableTower.Range;
                towerModel.GetWeapon().projectile.pierce = CustomizableTower.Pierce;
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
                CustomizableTower.MultiShotTotal += CustomizableTower.MultishotNumber;
                towerModel.GetWeapon().emission = new ArcEmissionModel("Emission", CustomizableTower.MultiShotTotal, CustomizableTower.MultiShotOffset, CustomizableTower.MultiShotRotation, null, false, false);
            }
            if(CustomizableTower.SeeCamo)
            {
                towerModel.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
            }
            if (!CustomizableTower.SeeCamo)
            {
                towerModel.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = true);
            }
            if (CustomizableTower.GenerateMoney)
            {
                if (CustomizableTower.AutoCollectBananas)
                {
                    var generateCashModel = Game.instance.model.GetTowerFromId("BananaFarm003").GetAttackModel().Duplicate();
                    var cashModel = generateCashModel.GetBehavior<CashModel>();
                    cashModel.maximum = CustomizableTower.MaxBananaValue;
                    cashModel.minimum = CustomizableTower.MinBananaValue;
                    generateCashModel.weapons[0].GetBehavior<EmissionsPerRoundFilterModel>().count = CustomizableTower.BananasPerRound;
                    towerModel.AddBehavior(generateCashModel);
                }
                else
                {
                    var generateCashModel = Game.instance.model.GetTowerFromId("BananaFarm000").GetAttackModel().Duplicate();
                    var cashModel = generateCashModel.GetBehavior<CashModel>();
                    cashModel.maximum = CustomizableTower.MaxBananaValue;
                    cashModel.minimum = CustomizableTower.MinBananaValue;
                    generateCashModel.weapons[0].GetBehavior<EmissionsPerRoundFilterModel>().count = CustomizableTower.BananasPerRound;
                    towerModel.AddBehavior(generateCashModel);
                }
                
            }
        }
        public override bool IsValidCrosspath(int[] tiers) =>
            ModHelper.HasMod("UltimateCrosspathing") ? true : base.IsValidCrosspath(tiers);
    }
}
