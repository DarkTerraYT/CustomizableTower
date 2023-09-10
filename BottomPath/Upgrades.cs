using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2Cpp;
using static CustomizableTower.CustomizableTower;
using static CustomizableTower.CustomizableTowerClass;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using CustomizableTower;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using Il2CppAssets.Scripts.Models.Towers.Weapons;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;

namespace BottomPath
{
    internal class BUpgrade1 : ModUpgrade<CustomizableTowerClass>
    {
        public override int Path => BOTTOM;

        public override int Tier => 1;

        public override int Cost => BU1Cost;
        public override string DisplayName => BU1Name;
        public override string Description => BU1Desc;
        public override int Priority => -2;

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            TotalDamage += BU1Damage;
            foreach (var WeaponModel in towerModel.GetWeapons())
            {
                var ProjectileModel = WeaponModel.projectile;
                ProjectileModel.AddBehavior(new DamageModel(null, TotalDamage, 9999999999999999999, false, false, true, Il2Cpp.BloonProperties.None, Il2Cpp.BloonProperties.None));
                var DamageModel = ProjectileModel.GetDamageModel();
                WeaponModel.rate *= BU1Speed;
                ProjectileModel.pierce += BU1Pierce;
                if (B1HitAll)
                {
                    DamageModel.immuneBloonProperties = BloonProperties.None;
                }
                else if (!B1HitFrozen && !B1HitLead && !B1HitPurple)
                {
                    DamageModel.immuneBloonProperties = BloonProperties.Lead | BloonProperties.Purple | BloonProperties.Frozen;
                }
                else if (!B1HitLead && !B1HitPurple && B1HitFrozen)
                {
                    DamageModel.immuneBloonProperties = BloonProperties.Lead | BloonProperties.Purple;
                }
                else if (!B1HitLead && B1HitPurple && !B1HitFrozen)
                {
                    DamageModel.immuneBloonProperties = BloonProperties.Lead | BloonProperties.Frozen;
                }
                else if (B1HitLead && !B1HitPurple && !B1HitFrozen)
                {
                    DamageModel.immuneBloonProperties = BloonProperties.Purple | BloonProperties.Frozen;
                }
                else if (B1HitAll && B1HitPurple && !B1HitFrozen)
                {
                    DamageModel.immuneBloonProperties = BloonProperties.Frozen;
                }
                else if (B1HitLead && !B1HitPurple && B1HitFrozen)
                {
                    DamageModel.immuneBloonProperties = BloonProperties.Purple;
                }
                else if (!B1HitFrozen && B1HitPurple && B1HitFrozen)
                {
                    DamageModel.immuneBloonProperties = BloonProperties.Lead;
                }
                else if (B1HitFrozen && B1HitPurple && B1HitFrozen)
                {
                    DamageModel.immuneBloonProperties = BloonProperties.None;
                }
                WeaponModel.emission = new ArcEmissionModel("Emission", B1MultiShotNumber, B1MultiShotOffset, B1MultiShotRotation, null, false, false);

            }
            towerModel.range += BU1Range;
            var AttackModel = towerModel.GetAttackModel();

            AttackModel.range += BU1Range;
            if(B1Camo)
            {
                towerModel.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
            }
        }
    }
    internal class BUpgrade2 : ModUpgrade<CustomizableTowerClass>
    {
        public override int Path => BOTTOM;

        public override int Tier => 2;

        public override int Cost => BU2Cost;
        public override string DisplayName => BU2Name;
        public override string Description => BU2Desc;
        public override int Priority => -2;

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            TotalDamage += BU2Damage;
            foreach (var WeaponModel in towerModel.GetWeapons())
            {
                var ProjectileModel = WeaponModel.projectile;
                ProjectileModel.AddBehavior(new DamageModel(null, TotalDamage, 9999999999999999999, false, false, true, Il2Cpp.BloonProperties.None, Il2Cpp.BloonProperties.None));
                var DamageModel = ProjectileModel.GetDamageModel();
                WeaponModel.rate *= BU2Speed;
                ProjectileModel.pierce += BU2Pierce;
                if (B2HitAll)
                {
                    DamageModel.immuneBloonProperties = BloonProperties.None;
                }
                else if (!B2HitFrozen && !B2HitLead && !B2HitPurple)
                {
                    DamageModel.immuneBloonProperties = BloonProperties.Lead | BloonProperties.Purple | BloonProperties.Frozen;
                }
                else if (!B2HitLead && !B2HitPurple && B2HitFrozen)
                {
                    DamageModel.immuneBloonProperties = BloonProperties.Lead | BloonProperties.Purple;
                }
                else if (!B2HitLead && B2HitPurple && !B2HitFrozen)
                {
                    DamageModel.immuneBloonProperties = BloonProperties.Lead | BloonProperties.Frozen;
                }
                else if (B2HitLead && !B2HitPurple && !B2HitFrozen)
                {
                    DamageModel.immuneBloonProperties = BloonProperties.Purple | BloonProperties.Frozen;
                }
                else if (B2HitAll && B2HitPurple && !B2HitFrozen)
                {
                    DamageModel.immuneBloonProperties = BloonProperties.Frozen;
                }
                else if (B2HitLead && !B2HitPurple && B2HitFrozen)
                {
                    DamageModel.immuneBloonProperties = BloonProperties.Purple;
                }
                else if (!B2HitFrozen && B2HitPurple && B2HitFrozen)
                {
                    DamageModel.immuneBloonProperties = BloonProperties.Lead;
                }
                else if (B2HitFrozen && B2HitPurple && B2HitFrozen)
                {
                    DamageModel.immuneBloonProperties = BloonProperties.None;
                }
                towerModel.GetAttackModel().weapons[0].emission = new ArcEmissionModel("Emission", B2MultiShotNumber, B2MultiShotOffset, B2MultiShotRotation, null, false, false);
            }
            towerModel.range += BU2Range;
            var AttackModel = towerModel.GetAttackModel();

            AttackModel.range += BU2Range;
            if (B2Camo)
            {
                towerModel.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
            }
        }
    }
    internal class BUpgrade3 : ModUpgrade<CustomizableTowerClass>
    {
        public override int Path => BOTTOM;

        public override int Tier => 3;

        public override int Cost => BU3Cost;
        public override string DisplayName => BU3Name;
        public override string Description => BU3Desc;
        public override int Priority => -2;

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            TotalDamage += BU3Damage;
            foreach (var WeaponModel in towerModel.GetWeapons())
            {
                var ProjectileModel = WeaponModel.projectile;
                ProjectileModel.AddBehavior(new DamageModel(null, TotalDamage, 9999999999999999999, false, false, true, Il2Cpp.BloonProperties.None, Il2Cpp.BloonProperties.None));
                var DamageModel = ProjectileModel.GetDamageModel();
                WeaponModel.rate *= BU3Speed;
                ProjectileModel.pierce += BU3Pierce;

                if (B3HitAll)
                {
                    DamageModel.immuneBloonProperties = BloonProperties.None;
                }
                else if (!B3HitFrozen && !B3HitLead && !B3HitPurple)
                {
                    DamageModel.immuneBloonProperties = BloonProperties.Lead | BloonProperties.Purple | BloonProperties.Frozen;
                }
                else if (!B3HitLead && !B3HitPurple && B3HitFrozen)
                {
                    DamageModel.immuneBloonProperties = BloonProperties.Lead | BloonProperties.Purple;
                }
                else if (!B3HitLead && B3HitPurple && !B3HitFrozen)
                {
                    DamageModel.immuneBloonProperties = BloonProperties.Lead | BloonProperties.Frozen;
                }
                else if (B3HitLead && !B3HitPurple && !B3HitFrozen)
                {
                    DamageModel.immuneBloonProperties = BloonProperties.Purple | BloonProperties.Frozen;
                }
                else if (B3HitAll && B3HitPurple && !B3HitFrozen)
                {
                    DamageModel.immuneBloonProperties = BloonProperties.Frozen;
                }
                else if (B3HitLead && !B3HitPurple && B3HitFrozen)
                {
                    DamageModel.immuneBloonProperties = BloonProperties.Purple;
                }
                else if (!B3HitFrozen && B3HitPurple && B3HitFrozen)
                {
                    DamageModel.immuneBloonProperties = BloonProperties.Lead;
                }
                else if (B3HitFrozen && B3HitPurple && B3HitFrozen)
                {
                    DamageModel.immuneBloonProperties = BloonProperties.None;
                }
                towerModel.GetAttackModel().weapons[0].emission = new ArcEmissionModel("Emission", B3MultiShotNumber, B3MultiShotOffset, B3MultiShotRotation, null, false, false);
            }
            towerModel.range += BU3Range;
            var AttackModel = towerModel.GetAttackModel();
            AttackModel.range += BU3Range;
            if (B3Camo)
            {
                towerModel.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
            }
        }
    }
    internal class BUpgrade4 : ModUpgrade<CustomizableTowerClass>
    {
        public override int Path => BOTTOM;

        public override int Tier => 4;

        public override int Cost => BU4Cost;
        public override string DisplayName => BU4Name;
        public override string Description => BU4Desc;
        public override int Priority => -2;

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            TotalDamage = BU4Damage;
            foreach (var WeaponModel in towerModel.GetWeapons())
            {
                var ProjectileModel = WeaponModel.projectile;
                ProjectileModel.AddBehavior(new DamageModel(null, TotalDamage, 9999999999999999999, false, false, true, Il2Cpp.BloonProperties.None, Il2Cpp.BloonProperties.None));
                var DamageModel = ProjectileModel.GetDamageModel();
                WeaponModel.rate *= BU4Speed;
                ProjectileModel.pierce += BU4Pierce;
                if (B4HitAll)
                {
                    DamageModel.immuneBloonProperties = BloonProperties.None;
                }
                else if (!B4HitFrozen && !B4HitLead && !B4HitPurple)
                {
                    DamageModel.immuneBloonProperties = BloonProperties.Lead | BloonProperties.Purple | BloonProperties.Frozen;
                }
                else if (!B4HitLead && !B4HitPurple && B4HitFrozen)
                {
                    DamageModel.immuneBloonProperties = BloonProperties.Lead | BloonProperties.Purple;
                }
                else if (!B4HitLead && B4HitPurple && !B4HitFrozen)
                {
                    DamageModel.immuneBloonProperties = BloonProperties.Lead | BloonProperties.Frozen;
                }
                else if (B4HitLead && !B4HitPurple && !B4HitFrozen)
                {
                    DamageModel.immuneBloonProperties = BloonProperties.Purple | BloonProperties.Frozen;
                }
                else if (B4HitAll && B4HitPurple && !B4HitFrozen)
                {
                    DamageModel.immuneBloonProperties = BloonProperties.Frozen;
                }
                else if (B4HitLead && !B4HitPurple && B4HitFrozen)
                {
                    DamageModel.immuneBloonProperties = BloonProperties.Purple;
                }
                else if (!B4HitFrozen && B4HitPurple && B4HitFrozen)
                {
                    DamageModel.immuneBloonProperties = BloonProperties.Lead;
                }
                else if (B4HitFrozen && B4HitPurple && B4HitFrozen)
                {
                    DamageModel.immuneBloonProperties = BloonProperties.None;
                }
                towerModel.GetAttackModel().weapons[0].emission = new ArcEmissionModel("Emission", B4MultiShotNumber, B4MultiShotOffset, B4MultiShotRotation, null, false, false);
            }
            towerModel.range += BU4Range;
            var AttackModel = towerModel.GetAttackModel();

            AttackModel.range += BU4Range;
            if (B4Camo)
            {
                towerModel.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
            }
        }
    }
    internal class BUpgrade5 : ModUpgrade<CustomizableTowerClass>
    {
        public override int Path => BOTTOM;

        public override int Tier => 5;

        public override int Cost => BU5Cost;
        public override string DisplayName => BU5Name;
        public override string Description => BU5Desc;
        public override int Priority => -2;

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            TotalDamage += BU5Damage;
            foreach (var WeaponModel in towerModel.GetWeapons())
            {
                var ProjectileModel = WeaponModel.projectile;
                ProjectileModel.AddBehavior(new DamageModel(null, TotalDamage, 9999999999999999999, false, false, true, Il2Cpp.BloonProperties.None, Il2Cpp.BloonProperties.None));
                var DamageModel = ProjectileModel.GetDamageModel();
                WeaponModel.rate *= BU5Speed;
                ProjectileModel.pierce += BU5Pierce;
                if (B5HitAll)
                {
                    DamageModel.immuneBloonProperties = BloonProperties.None;
                }
                else if (!B5HitFrozen && !B5HitLead && !B5HitPurple)
                {
                    DamageModel.immuneBloonProperties = BloonProperties.Lead | BloonProperties.Purple | BloonProperties.Frozen;
                }
                else if (!B5HitLead && !B5HitPurple && B5HitFrozen)
                {
                    DamageModel.immuneBloonProperties = BloonProperties.Lead | BloonProperties.Purple;
                }
                else if (!B5HitLead && B5HitPurple && !B5HitFrozen)
                {
                    DamageModel.immuneBloonProperties = BloonProperties.Lead | BloonProperties.Frozen;
                }
                else if (B5HitLead && !B5HitPurple && !B5HitFrozen)
                {
                    DamageModel.immuneBloonProperties = BloonProperties.Purple | BloonProperties.Frozen;
                }
                else if (B5HitAll && B5HitPurple && !B5HitFrozen)
                {
                    DamageModel.immuneBloonProperties = BloonProperties.Frozen;
                }
                else if (B5HitLead && !B5HitPurple && B5HitFrozen)
                {
                    DamageModel.immuneBloonProperties = BloonProperties.Purple;
                }
                else if (!B5HitFrozen && B5HitPurple && B5HitFrozen)
                {
                    DamageModel.immuneBloonProperties = BloonProperties.Lead;
                }
                else if (B5HitFrozen && B5HitPurple && B5HitFrozen)
                {
                    DamageModel.immuneBloonProperties = BloonProperties.None;
                }
                towerModel.GetAttackModel().weapons[0].emission = new ArcEmissionModel("Emission", B5MultiShotNumber, B5MultiShotOffset, B5MultiShotRotation, null, false, false);

            }
            towerModel.range += BU5Range;
            var AttackModel = towerModel.GetAttackModel();
            AttackModel.range += BU5Range;
            if (B5Camo)
            {
                towerModel.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
            }
        }
    }
}
