using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using CustomizableTower;
using static CustomizableTower.CustomizableTower;
using Il2Cpp;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;

namespace TopPath
{
    internal class TUpgrade1 : ModUpgrade<CustomizableTowerClass>
    {
        public override int Path => TOP;

        public override int Tier => 1;

        public override int Cost => TU1Cost;
        public override string DisplayName => TU1Name;
        public override string Description => TU1Desc;

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.range += TU1Range;
            var AttackModel = towerModel.GetAttackModel();
            var WeaponModel = AttackModel.weapons[0];
            var ProjectileModel = WeaponModel.projectile;
            var DamageModel = ProjectileModel.GetDamageModel();

            AttackModel.range += TU1Range;
            WeaponModel.rate *= TU1Speed;
            ProjectileModel.pierce += TU1Pierce;
            DamageModel.damage += TU1Damage;
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
            if (T1Camo)
            {
                towerModel.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
            }
            MultiShotTotal += T1MultiShotNumber;
            towerModel.GetWeapon().emission = new ArcEmissionModel("Emission", MultiShotTotal, T1MultiShotOffset, T1MultiShotRotation, null, false, false);
        }
    }
    internal class TUpgrade2 : ModUpgrade<CustomizableTowerClass>
    {
        public override int Path => TOP;

        public override int Tier => 2;

        public override int Cost => TU2Cost;
        public override string DisplayName => TU2Name;
        public override string Description => TU2Desc;

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.range += TU2Range;
            var AttackModel = towerModel.GetAttackModel();
            var WeaponModel = AttackModel.weapons[0];
            var ProjectileModel = WeaponModel.projectile;
            var DamageModel = ProjectileModel.GetDamageModel();

            AttackModel.range += TU2Range;
            WeaponModel.rate *= TU2Speed;
            ProjectileModel.pierce += TU2Pierce;
            DamageModel.damage += TU2Damage;
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
            if (T2Camo)
            {
                towerModel.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
            }
            MultiShotTotal += T2MultiShotNumber;
            towerModel.GetWeapon().emission = new ArcEmissionModel("Emission", MultiShotTotal, T2MultiShotOffset, T2MultiShotRotation, null, false, false);
        }
    }
    internal class TUpgrade3 : ModUpgrade<CustomizableTowerClass>
    {
        public override int Path => TOP;

        public override int Tier => 3;

        public override int Cost => TU3Cost;
        public override string DisplayName => TU3Name;
        public override string Description => TU3Desc;

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.range += TU3Range;
            var AttackModel = towerModel.GetAttackModel();
            var WeaponModel = AttackModel.weapons[0];
            var ProjectileModel = WeaponModel.projectile;
            var DamageModel = ProjectileModel.GetDamageModel();

            AttackModel.range += TU3Range;
            WeaponModel.rate *= TU3Speed;
            ProjectileModel.pierce += TU3Pierce;
            DamageModel.damage += TU3Damage;
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
            if (T3Camo)
            {
                towerModel.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
            }
            MultiShotTotal += T3MultiShotNumber;
            towerModel.GetWeapon().emission = new ArcEmissionModel("Emission", MultiShotTotal, T3MultiShotOffset, T3MultiShotRotation, null, false, false);
        }
    }
    internal class TUpgrade4 : ModUpgrade<CustomizableTowerClass>
    {
        public override int Path => TOP;

        public override int Tier => 4;

        public override int Cost => TU4Cost;
        public override string DisplayName => TU4Name;
        public override string Description => TU4Desc;

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.range += TU4Range;
            var AttackModel = towerModel.GetAttackModel();
            var WeaponModel = AttackModel.weapons[0];
            var ProjectileModel = WeaponModel.projectile;
            var DamageModel = ProjectileModel.GetDamageModel();

            AttackModel.range += TU4Range;
            WeaponModel.rate *= TU4Speed;
            ProjectileModel.pierce += TU4Pierce;
            DamageModel.damage += TU4Damage;
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
            if (T4Camo)
            {
                towerModel.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
            }
            MultiShotTotal += T4MultiShotNumber;
            towerModel.GetWeapon().emission = new ArcEmissionModel("Emission", MultiShotTotal, T4MultiShotOffset, T4MultiShotRotation, null, false, false);
        }
    }
    internal class TUpgrade5 : ModUpgrade<CustomizableTowerClass>
    {
        public override int Path => TOP;

        public override int Tier => 5;

        public override int Cost => TU5Cost;
        public override string DisplayName => TU5Name;
        public override string Description => TU5Desc;

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.range += TU5Range;
            var AttackModel = towerModel.GetAttackModel();
            var WeaponModel = AttackModel.weapons[0];
            var ProjectileModel = WeaponModel.projectile;
            var DamageModel = ProjectileModel.GetDamageModel();

            AttackModel.range += TU5Range;
            WeaponModel.rate *= TU5Speed;
            ProjectileModel.pierce += TU5Pierce;
            DamageModel.damage += TU5Damage;
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
            if (T5Camo)
            {
                towerModel.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
            }
            MultiShotTotal += T5MultiShotNumber;
            towerModel.GetWeapon().emission = new ArcEmissionModel("Emission", MultiShotTotal, T5MultiShotOffset, T5MultiShotRotation, null, false, false);
        }
    }
}
