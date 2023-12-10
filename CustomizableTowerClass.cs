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
using HarmonyLib.Tools;
using System.ComponentModel;
using static CustomizableTower.CustomizableTower;
using Il2CppAssets.Scripts.Models.Towers.Weapons;
using System.Linq;

namespace CustomizableTower
{
    internal class CustomizableTowerClass : ModTower
    {
        public override TowerSet TowerSet => TowerSet.Primary;

        public override string BaseTower => BaseTowerId;

        public override int Cost => CustomizableTower.Cost;

        public override int TopPathUpgrades => CustomizableTower.TopPathUpgrades;

        public override int MiddlePathUpgrades => CustomizableTower.MiddlePathUpgrades;

        public override int BottomPathUpgrades => CustomizableTower.BottomPathUpgrades;
        public override ParagonMode ParagonMode => ParagonMode.Base555;
        public override string Icon => "CustomizedTower-Portrait";
        public override string Portrait => "CustomizedTower-Portrait";
        public override string DisplayName => "Customizable Tower";
        public override string Description => "Please don't use this in competitive modes, one: it could get your account flagged, and two: it ruins the fun for others.";

        internal static int TotalDamage = Damage;

        public override void ModifyBaseTowerModel(TowerModel towerModel)
        {
            towerModel.ApplyDisplay<CustomizedTowerDisplay>();
            towerModel.GetAttackModel().RemoveWeapon(towerModel.GetAttackModel().weapons[0]);
            if (Dart)
            {
                towerModel.GetAttackModel().AddWeapon(Game.instance.model.GetTowerFromId("DartMonkey").GetWeapon().Duplicate());
            }
            if(Boomerangs)
            {
                towerModel.GetAttackModel().AddWeapon(Game.instance.model.GetTowerFromId("BoomerangMonkey").GetWeapon().Duplicate());
            }
            if (Bomb)
            {
                towerModel.GetAttackModel().AddWeapon(Game.instance.model.GetTowerFromId("BombShooter").GetWeapon().Duplicate());
            }
            if (Tack)
            {
                towerModel.GetAttackModel().AddWeapon(Game.instance.model.GetTowerFromId("TackShooter").GetWeapon().Duplicate());
            }
            if (Ice)
            {
                towerModel.GetAttackModel().AddWeapon(Game.instance.model.GetTowerFromId("IceMonkey").GetWeapon().Duplicate());
            }
            if (Glue)
            {
                towerModel.GetAttackModel().AddWeapon(Game.instance.model.GetTowerFromId("GlueGunner").GetWeapon().Duplicate());
            }
            if (Sniper)
            {
                towerModel.GetAttackModel().AddWeapon(Game.instance.model.GetTowerFromId("SniperMonkey").GetWeapon().Duplicate());
            }
            if (Mortar)
            {
                towerModel.GetAttackModel().AddWeapon(Game.instance.model.GetTowerFromId("MortarMonkey").GetWeapon().Duplicate());
            }
            if (LaserShock)
            {
                towerModel.GetAttackModel().AddWeapon(Game.instance.model.GetTowerFromId("DartlingGunner-200").GetWeapon().Duplicate());
            }
            if (Rocket)
            {
                towerModel.GetAttackModel().AddWeapon(Game.instance.model.GetTowerFromId("DartlingGunner-030").GetWeapon().Duplicate());
            }
            if (Magic)
            {
                towerModel.GetAttackModel().AddWeapon(Game.instance.model.GetTowerFromId("WizardMonkey").GetWeapon().Duplicate());
            }
            if (Laser)
            {
                if(LaserShock)
                {
                    towerModel.GetAttackModel().AddWeapon(Game.instance.model.GetTowerFromId("DartlingGunner-300").GetWeapon().Duplicate());
                }
                else
                {
                    towerModel.GetAttackModel().AddWeapon(Game.instance.model.GetTowerFromId("SuperMonkey-100").GetWeapon().Duplicate());
                }
            }
            if (Plasma)
            {
                towerModel.GetAttackModel().AddWeapon(Game.instance.model.GetTowerFromId("SuperMonkey-200").GetWeapon().Duplicate());
            }
            if (SunAvatarBeam)
            {
                towerModel.GetAttackModel().AddWeapon(Game.instance.model.GetTowerFromId("SuperMonkey-300").GetWeapon().Duplicate());
            }
            if (SunGod)
            {
                towerModel.GetAttackModel().AddWeapon(Game.instance.model.GetTowerFromId("SuperMonkey-400").GetWeapon().Duplicate());
            }
            if (TrueSunGod)
            {
                towerModel.GetAttackModel().AddWeapon(Game.instance.model.GetTowerFromId("SuperMonkey-500").GetWeapon().Duplicate());
            }
            if (MonkeyRang)
            {
                if(Laser)
                    towerModel.GetAttackModel().AddWeapon(Game.instance.model.GetTowerFromId("SuperMonkey-103").GetWeapon().Duplicate());
                else if (Plasma)
                    towerModel.GetAttackModel().AddWeapon(Game.instance.model.GetTowerFromId("SuperMonkey-203").GetWeapon().Duplicate());
                else
                    towerModel.GetAttackModel().AddWeapon(Game.instance.model.GetTowerFromId("SuperMonkey-003").GetWeapon().Duplicate());
            }
            if (Magic)
            {
                towerModel.GetAttackModel().AddWeapon(Game.instance.model.GetTowerFromId("WizardMonkey").GetWeapon().Duplicate());
            }
            if (Shurikan)
            {
                towerModel.GetAttackModel().AddWeapon(Game.instance.model.GetTowerFromId("NinjaMonkey").GetWeapon().Duplicate());
            }
            if (Potion)
            {
                towerModel.GetAttackModel().AddWeapon(Game.instance.model.GetTowerFromId("Alchemist").GetWeapon().Duplicate());
            }
            if (Thorn)
            {
                towerModel.GetAttackModel().AddWeapon(Game.instance.model.GetTowerFromId("Druid").GetWeapon().Duplicate());
            }
            if (SpikedMines)
            {
                towerModel.GetAttackModel().AddWeapon(Game.instance.model.GetTowerFromId("SpikeFactory-400").GetWeapon().Duplicate());
            }
            foreach(var weaponModel_ in towerModel.GetWeapons())
            {
                var projectileModel_ = weaponModel_.projectile;
                projectileModel_.pierce = Pierce;
                weaponModel_.rate = Speed;
                if (projectileModel_.HasBehavior<TravelStraitModel>())
                {
                    projectileModel_.GetBehavior<TravelStraitModel>().speed = ProjectileSpeed;
                    projectileModel_.GetBehavior<TravelStraitModel>().lifespan = ProjectileLifespan;
                }
                if(!projectileModel_.HasBehavior<DamageModel>())
                {
                    projectileModel_.AddBehavior(new DamageModel(null, 0, 9999999999999999999, false, false, true, Il2Cpp.BloonProperties.None, Il2Cpp.BloonProperties.None, true));
                }
                var DamageModel = projectileModel_.GetDamageModel();
                DamageModel.damage = Damage;
                if (HitAll)
                {
                    DamageModel.immuneBloonProperties = Il2Cpp.BloonProperties.None;
                }
                else if (!HitLead && !HitPurple && !HitFrozen)
                {
                    DamageModel.immuneBloonProperties = Il2Cpp.BloonProperties.Lead | Il2Cpp.BloonProperties.Purple | Il2Cpp.BloonProperties.Frozen;
                }
                else if (!HitLead && !HitPurple && HitFrozen)
                {
                    DamageModel.immuneBloonProperties = Il2Cpp.BloonProperties.Purple | Il2Cpp.BloonProperties.Lead;
                }
                else if (HitLead && !HitPurple && !HitFrozen)
                {
                    DamageModel.immuneBloonProperties = Il2Cpp.BloonProperties.Purple | Il2Cpp.BloonProperties.Frozen;
                }
                else if (!HitLead && HitPurple && !HitFrozen)
                {
                    DamageModel.immuneBloonProperties = Il2Cpp.BloonProperties.Lead | Il2Cpp.BloonProperties.Frozen;
                }
                else if (HitLead && !HitPurple && HitFrozen)
                {
                    DamageModel.immuneBloonProperties = Il2Cpp.BloonProperties.Purple;
                }
                else if (HitLead && HitPurple && !HitFrozen)
                {
                    DamageModel.immuneBloonProperties = Il2Cpp.BloonProperties.Frozen;
                }
                else if (!HitLead && HitPurple && HitFrozen)
                {
                    DamageModel.immuneBloonProperties = Il2Cpp.BloonProperties.Lead;
                }
                else if (HitLead && HitPurple && HitFrozen)
                {
                    DamageModel.immuneBloonProperties = Il2Cpp.BloonProperties.None;
                }
                if (Moabs)
                {
                    weaponModel_.projectile.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Moabs", "Moabs", MoabsDamageMulti, MoabsDamageAdditive, false, false));
                }
                if (Ceramics)
                {
                    weaponModel_.projectile.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Ceramic", "Ceramic", CeramicDamageMulti, CeramicDamageAdditive, false, false));
                }
                if (Fortified)
                {
                    weaponModel_.projectile.AddBehavior(new DamageModifierForTagModel("DamageModelForTagModel_Fortified", "Fortified", FortifiedDamageMulti, FortifiedDamageAdditive, false, false));
                }
                weaponModel_.emission = new ArcEmissionModel("Emission", MultishotNumber, MultiShotOffset, MultiShotRotation, null, false, false);
            }
            towerModel.range = Range;
            towerModel.GetAttackModel().range = Range;
            if(SeeCamo)
            {
                towerModel.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
            }
            if (!SeeCamo)
            {
                towerModel.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = true);
            }
            if (GenerateMoney)
            {
                if (AutoCollectBananas)
                {
                    var generateCashModel = Game.instance.model.GetTowerFromId("BananaFarm-003").GetAttackModel().Duplicate();
                    var cashModel = generateCashModel.weapons[0].projectile.GetBehavior<CashModel>();
                    cashModel.maximum = MaxBananaValue;
                    cashModel.minimum = MinBananaValue;
                    generateCashModel.weapons[0].GetBehavior<EmissionsPerRoundFilterModel>().count = BananasPerRound;
                    towerModel.AddBehavior(generateCashModel);
                }
                else
                {
                    var generateCashModel = Game.instance.model.GetTowerFromId("BananaFarm").GetAttackModel().Duplicate();
                    var cashModel = generateCashModel.weapons[0].projectile.GetBehavior<CashModel>();
                    cashModel.maximum = MaxBananaValue;
                    cashModel.minimum = MinBananaValue;
                    generateCashModel.weapons[0].GetBehavior<EmissionsPerRoundFilterModel>().count = BananasPerRound;
                    towerModel.AddBehavior(generateCashModel);
                } 
            }
        }
        public override bool IsValidCrosspath(int[] tiers) =>
            ModHelper.HasMod("UltimateCrosspathing") ? true : base.IsValidCrosspath(tiers);
    }
}
