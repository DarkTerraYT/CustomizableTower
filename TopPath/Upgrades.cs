using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using CustomizableTower;
using static CustomizableTower.CustomizableTower;
using static CustomizableTower.CustomizableTowerClass;
using Il2Cpp;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;

namespace TopPath
{
    internal class TUpgrade1 : ModUpgrade<CustomizableTowerClass>
    {
        public override int Path => TOP;

        public override int Tier => 1;

        public override int Cost => TU1Cost;
        public override string DisplayName => TU1Name;
        public override string Description => TU1Desc;
        public override int Priority => -2;

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            TotalDamage += TU1Damage;
            foreach (var WeaponModel in towerModel.GetWeapons())
            {
                var ProjectileModel = WeaponModel.projectile;
                ProjectileModel.AddBehavior(new DamageModel(null, TotalDamage, 9999999999999999999, false, false, true, Il2Cpp.BloonProperties.None, Il2Cpp.BloonProperties.None));
                var DamageModel = ProjectileModel.GetDamageModel();
                WeaponModel.rate *= TU1Speed;
                ProjectileModel.pierce += TU1Pierce;
                if (T1HitAll)
                {
                    DamageModel.immuneBloonProperties = BloonProperties.None;
                }
                else if (!T1HitFrozen && !T1HitLead && !T1HitPurple)
                {
                    DamageModel.immuneBloonProperties = BloonProperties.Lead | BloonProperties.Purple | BloonProperties.Frozen;
                }
                else if (!T1HitLead && !T1HitPurple && T1HitFrozen)
                {
                    DamageModel.immuneBloonProperties = BloonProperties.Lead | BloonProperties.Purple;
                }
                else if (!T1HitLead && T1HitPurple && !T1HitFrozen)
                {
                    DamageModel.immuneBloonProperties = BloonProperties.Lead | BloonProperties.Frozen;
                }
                else if (T1HitLead && !T1HitPurple && !T1HitFrozen)
                {
                    DamageModel.immuneBloonProperties = BloonProperties.Purple | BloonProperties.Frozen;
                }
                else if (T1HitAll && T1HitPurple && !T1HitFrozen)
                {
                    DamageModel.immuneBloonProperties = BloonProperties.Frozen;
                }
                else if (T1HitLead && !T1HitPurple && T1HitFrozen)
                {
                    DamageModel.immuneBloonProperties = BloonProperties.Purple;
                }
                else if (!T1HitFrozen && T1HitPurple && T1HitFrozen)
                {
                    DamageModel.immuneBloonProperties = BloonProperties.Lead;
                }
                else if (T1HitFrozen && T1HitPurple && T1HitFrozen)
                {
                    DamageModel.immuneBloonProperties = BloonProperties.None;
                }
                towerModel.GetAttackModel().weapons[0].emission = new ArcEmissionModel("Emission", T1MultiShotNumber, T1MultiShotOffset, T1MultiShotRotation, null, false, false);
            }
            towerModel.range += TU1Range;
            var AttackModel = towerModel.GetAttackModel();
            AttackModel.range += TU1Range;

            if (T1Camo)
            {
                towerModel.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
            }
           
        }
    }
    internal class TUpgrade2 : ModUpgrade<CustomizableTowerClass>
    {
        public override int Path => TOP;

        public override int Tier => 2;

        public override int Cost => TU2Cost;
        public override string DisplayName => TU2Name;
        public override string Description => TU2Desc;
        public override int Priority => -2;

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            TotalDamage += TU2Damage;
            foreach (var WeaponModel in towerModel.GetWeapons())
            {
                var ProjectileModel = WeaponModel.projectile;
                ProjectileModel.AddBehavior(new DamageModel(null, TotalDamage, 9999999999999999999, false, false, true, Il2Cpp.BloonProperties.None, Il2Cpp.BloonProperties.None));
                var DamageModel = ProjectileModel.GetDamageModel();
                WeaponModel.rate *= TU2Speed;
                ProjectileModel.pierce += TU2Pierce;
                if (T2HitAll)
                {
                    DamageModel.immuneBloonProperties = BloonProperties.None;
                }
                else if (!T2HitFrozen && !T2HitLead && !T2HitPurple)
                {
                    DamageModel.immuneBloonProperties = BloonProperties.Lead | BloonProperties.Purple | BloonProperties.Frozen;
                }
                else if (!T2HitLead && !T2HitPurple && T2HitFrozen)
                {
                    DamageModel.immuneBloonProperties = BloonProperties.Lead | BloonProperties.Purple;
                }
                else if (!T2HitLead && T2HitPurple && !T2HitFrozen)
                {
                    DamageModel.immuneBloonProperties = BloonProperties.Lead | BloonProperties.Frozen;
                }
                else if (T2HitLead && !T2HitPurple && !T2HitFrozen)
                {
                    DamageModel.immuneBloonProperties = BloonProperties.Purple | BloonProperties.Frozen;
                }
                else if (T2HitAll && T2HitPurple && !T2HitFrozen)
                {
                    DamageModel.immuneBloonProperties = BloonProperties.Frozen;
                }
                else if (T2HitLead && !T2HitPurple && T2HitFrozen)
                {
                    DamageModel.immuneBloonProperties = BloonProperties.Purple;
                }
                else if (!T2HitFrozen && T2HitPurple && T2HitFrozen)
                {
                    DamageModel.immuneBloonProperties = BloonProperties.Lead;
                }
                else if (T2HitFrozen && T2HitPurple && T2HitFrozen)
                {
                    DamageModel.immuneBloonProperties = BloonProperties.None;
                }
                towerModel.GetAttackModel().weapons[0].emission = new ArcEmissionModel("Emission", T2MultiShotNumber, T2MultiShotOffset, T2MultiShotRotation, null, false, false);
            }
            towerModel.range += TU2Range;
            var AttackModel = towerModel.GetAttackModel();
            AttackModel.range += TU2Range;
            
            if (T2Camo)
            {
                towerModel.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
            }
        }
    }
    internal class TUpgrade3 : ModUpgrade<CustomizableTowerClass>
    {
        public override int Path => TOP;

        public override int Tier => 3;

        public override int Cost => TU3Cost;
        public override string DisplayName => TU3Name;
        public override string Description => TU3Desc;
        public override int Priority => -2;

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            TotalDamage += TU3Damage;
            foreach (var WeaponModel in towerModel.GetWeapons())
            {
                var ProjectileModel = WeaponModel.projectile;
                ProjectileModel.AddBehavior(new DamageModel(null, TotalDamage, 9999999999999999999, false, false, true, Il2Cpp.BloonProperties.None, Il2Cpp.BloonProperties.None));
                var DamageModel = ProjectileModel.GetDamageModel();
                WeaponModel.rate *= TU3Speed;
                ProjectileModel.pierce += TU3Pierce;
                if (T3HitAll)
                {
                    DamageModel.immuneBloonProperties = BloonProperties.None;
                }
                else if (!T3HitFrozen && !T3HitLead && !T3HitPurple)
                {
                    DamageModel.immuneBloonProperties = BloonProperties.Lead | BloonProperties.Purple | BloonProperties.Frozen;
                }
                else if (!T3HitLead && !T3HitPurple && T3HitFrozen)
                {
                    DamageModel.immuneBloonProperties = BloonProperties.Lead | BloonProperties.Purple;
                }
                else if (!T3HitLead && T3HitPurple && !T3HitFrozen)
                {
                    DamageModel.immuneBloonProperties = BloonProperties.Lead | BloonProperties.Frozen;
                }
                else if (T3HitLead && !T3HitPurple && !T3HitFrozen)
                {
                    DamageModel.immuneBloonProperties = BloonProperties.Purple | BloonProperties.Frozen;
                }
                else if (T3HitAll && T3HitPurple && !T3HitFrozen)
                {
                    DamageModel.immuneBloonProperties = BloonProperties.Frozen;
                }
                else if (T3HitLead && !T3HitPurple && T3HitFrozen)
                {
                    DamageModel.immuneBloonProperties = BloonProperties.Purple;
                }
                else if (!T3HitFrozen && T3HitPurple && T3HitFrozen)
                {
                    DamageModel.immuneBloonProperties = BloonProperties.Lead;
                }
                else if (T3HitFrozen && T3HitPurple && T3HitFrozen)
                {
                    DamageModel.immuneBloonProperties = BloonProperties.None;
                }
                towerModel.GetAttackModel().weapons[0].emission = new ArcEmissionModel("Emission", T3MultiShotNumber, T3MultiShotOffset, T3MultiShotRotation, null, false, false);
            }
            towerModel.range += TU3Range;
            var AttackModel = towerModel.GetAttackModel();
            AttackModel.range += TU3Range;         
            if (T3Camo)
            {
                towerModel.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
            }            
        }
    }
    internal class TUpgrade4 : ModUpgrade<CustomizableTowerClass>
    {
        public override int Path => TOP;

        public override int Tier => 4;

        public override int Cost => TU4Cost;
        public override string DisplayName => TU4Name;
        public override string Description => TU4Desc;
        public override int Priority => -2;

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            TotalDamage += TU4Damage;
            foreach (var WeaponModel in towerModel.GetWeapons())
            {
                var ProjectileModel = WeaponModel.projectile;
                ProjectileModel.AddBehavior(new DamageModel(null, TotalDamage, 9999999999999999999, false, false, true, Il2Cpp.BloonProperties.None, Il2Cpp.BloonProperties.None));
                var DamageModel = ProjectileModel.GetDamageModel();

                WeaponModel.rate *= TU4Speed;
                ProjectileModel.pierce += TU4Pierce;
                if (T4HitAll)
                {
                    DamageModel.immuneBloonProperties = BloonProperties.None;
                }
                else if (!T4HitFrozen && !T4HitLead && !T4HitPurple)
                {
                    DamageModel.immuneBloonProperties = BloonProperties.Lead | BloonProperties.Purple | BloonProperties.Frozen;
                }
                else if (!T4HitLead && !T4HitPurple && T4HitFrozen)
                {
                    DamageModel.immuneBloonProperties = BloonProperties.Lead | BloonProperties.Purple;
                }
                else if (!T4HitLead && T4HitPurple && !T4HitFrozen)
                {
                    DamageModel.immuneBloonProperties = BloonProperties.Lead | BloonProperties.Frozen;
                }
                else if (T4HitLead && !T4HitPurple && !T4HitFrozen)
                {
                    DamageModel.immuneBloonProperties = BloonProperties.Purple | BloonProperties.Frozen;
                }
                else if (T4HitAll && T4HitPurple && !T4HitFrozen)
                {
                    DamageModel.immuneBloonProperties = BloonProperties.Frozen;
                }
                else if (T4HitLead && !T4HitPurple && T4HitFrozen)
                {
                    DamageModel.immuneBloonProperties = BloonProperties.Purple;
                }
                else if (!T4HitFrozen && T4HitPurple && T4HitFrozen)
                {
                    DamageModel.immuneBloonProperties = BloonProperties.Lead;
                }
                else if (T4HitFrozen && T4HitPurple && T4HitFrozen)
                {
                    DamageModel.immuneBloonProperties = BloonProperties.None;
                }
                towerModel.GetAttackModel().weapons[0].emission = new ArcEmissionModel("Emission", T4MultiShotNumber, T4MultiShotOffset, T4MultiShotRotation, null, false, false);
            }
            towerModel.range += TU4Range;
            var AttackModel = towerModel.GetAttackModel();
            AttackModel.range += TU4Range;
            if (T4Camo)
            {
                towerModel.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
            }

        }
    }
    internal class TUpgrade5 : ModUpgrade<CustomizableTowerClass>
    {
        public override int Path => TOP;

        public override int Tier => 5;

        public override int Cost => TU5Cost;
        public override string DisplayName => TU5Name;
        public override string Description => TU5Desc;
        public override int Priority => -2;

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            TotalDamage += TU5Damage;
            foreach (var WeaponModel in towerModel.GetWeapons())
            {
                var ProjectileModel = WeaponModel.projectile;
                ProjectileModel.AddBehavior(new DamageModel(null, TotalDamage, 9999999999999999999, false, false, true, Il2Cpp.BloonProperties.None, Il2Cpp.BloonProperties.None));
                var DamageModel = ProjectileModel.GetDamageModel();
                WeaponModel.rate *= TU5Speed;
                ProjectileModel.pierce += TU5Pierce;
                if (T5HitAll)
                {
                    DamageModel.immuneBloonProperties = BloonProperties.None;
                }
                else if (!T5HitFrozen && !T5HitLead && !T5HitPurple)
                {
                    DamageModel.immuneBloonProperties = BloonProperties.Lead | BloonProperties.Purple | BloonProperties.Frozen;
                }
                else if (!T5HitLead && !T5HitPurple && T5HitFrozen)
                {
                    DamageModel.immuneBloonProperties = BloonProperties.Lead | BloonProperties.Purple;
                }
                else if (!T5HitLead && T5HitPurple && !T5HitFrozen)
                {
                    DamageModel.immuneBloonProperties = BloonProperties.Lead | BloonProperties.Frozen;
                }
                else if (T5HitLead && !T5HitPurple && !T5HitFrozen)
                {
                    DamageModel.immuneBloonProperties = BloonProperties.Purple | BloonProperties.Frozen;
                }
                else if (T5HitAll && T5HitPurple && !T5HitFrozen)
                {
                    DamageModel.immuneBloonProperties = BloonProperties.Frozen;
                }
                else if (T5HitLead && !T5HitPurple && T5HitFrozen)
                {
                    DamageModel.immuneBloonProperties = BloonProperties.Purple;
                }
                else if (!T5HitFrozen && T5HitPurple && T5HitFrozen)
                {
                    DamageModel.immuneBloonProperties = BloonProperties.Lead;
                }
                else if (T5HitFrozen && T5HitPurple && T5HitFrozen)
                {
                    DamageModel.immuneBloonProperties = BloonProperties.None;
                }
                towerModel.GetAttackModel().weapons[0].emission = new ArcEmissionModel("Emission", T5MultiShotNumber, T5MultiShotOffset, T5MultiShotRotation, null, false, false);
            }
            towerModel.range += TU5Range;
            var AttackModel = towerModel.GetAttackModel();
            AttackModel.range += TU5Range;
            if (T5Camo)
            {
                towerModel.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
            }        
        }
    }
}
