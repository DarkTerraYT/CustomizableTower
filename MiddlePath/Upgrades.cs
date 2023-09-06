using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using CustomizableTower;
using static CustomizableTower.CustomizableTower;
using Il2Cpp;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;

namespace MiddlePath
{
    internal class MUpgrade1 : ModUpgrade<CustomizableTowerClass>
    {
        public override int Path => MIDDLE;

        public override int Tier => 1;

        public override int Cost => MU1Cost;
        public override string DisplayName => MU1Name;
        public override string Description => MU1Desc;

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.range += MU1Range;
            var AttackModel = towerModel.GetAttackModel();
            var WeaponModel = AttackModel.weapons[0];
            var ProjectileModel = WeaponModel.projectile;
            var DamageModel = ProjectileModel.GetDamageModel();

            AttackModel.range += MU1Range;
            WeaponModel.rate *= MU1Speed;
            ProjectileModel.pierce += MU1Pierce;
            DamageModel.damage += MU1Damage;
            if (M1HitAll)
            {
                DamageModel.immuneBloonProperties = BloonProperties.None;
            }
            else if (!M1HitFrozen && !M1HitLead && !M1HitPurple)
            {
                DamageModel.immuneBloonProperties = BloonProperties.Lead | BloonProperties.Purple | BloonProperties.Frozen;
            }
            else if (!M1HitLead && !M1HitPurple && M1HitFrozen)
            {
                DamageModel.immuneBloonProperties = BloonProperties.Lead | BloonProperties.Purple;
            }
            else if (!M1HitLead && M1HitPurple && !M1HitFrozen)
            {
                DamageModel.immuneBloonProperties = BloonProperties.Lead | BloonProperties.Frozen;
            }
            else if (M1HitLead && !M1HitPurple && !M1HitFrozen)
            {
                DamageModel.immuneBloonProperties = BloonProperties.Purple | BloonProperties.Frozen;
            }
            else if (M1HitAll && M1HitPurple && !M1HitFrozen)
            {
                DamageModel.immuneBloonProperties = BloonProperties.Frozen;
            }
            else if (M1HitLead && !M1HitPurple && M1HitFrozen)
            {
                DamageModel.immuneBloonProperties = BloonProperties.Purple;
            }
            else if (!M1HitFrozen && M1HitPurple && M1HitFrozen)
            {
                DamageModel.immuneBloonProperties = BloonProperties.Lead;
            }
            else if (M1HitFrozen && M1HitPurple && M1HitFrozen)
            {
                DamageModel.immuneBloonProperties = BloonProperties.None;
            }
            if (M1Camo)
            {
                towerModel.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
            }
            MultiShotTotal += M1MultiShotNumber;
            towerModel.GetWeapon().emission = new ArcEmissionModel("Emission", MultiShotTotal, M1MultiShotOffset, M1MultiShotRotation, null, false, false);
        }
    }
    internal class MUpgrade2 : ModUpgrade<CustomizableTowerClass>
    {
        public override int Path => MIDDLE;

        public override int Tier => 2;

        public override int Cost => MU2Cost;
        public override string DisplayName => MU2Name;
        public override string Description => MU2Desc;

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.range += MU2Range;
            var AttackModel = towerModel.GetAttackModel();
            var WeaponModel = AttackModel.weapons[0];
            var ProjectileModel = WeaponModel.projectile;
            var DamageModel = ProjectileModel.GetDamageModel();

            AttackModel.range += MU2Range;
            WeaponModel.rate *= MU2Speed;
            ProjectileModel.pierce += MU2Pierce;
            DamageModel.damage += MU2Damage;
            if (M2HitAll)
            {
                DamageModel.immuneBloonProperties = BloonProperties.None;
            }
            else if (!M2HitFrozen && !M2HitLead && !M2HitPurple)
            {
                DamageModel.immuneBloonProperties = BloonProperties.Lead | BloonProperties.Purple | BloonProperties.Frozen;
            }
            else if (!M2HitLead && !M2HitPurple && M2HitFrozen)
            {
                DamageModel.immuneBloonProperties = BloonProperties.Lead | BloonProperties.Purple;
            }
            else if (!M2HitLead && M2HitPurple && !M2HitFrozen)
            {
                DamageModel.immuneBloonProperties = BloonProperties.Lead | BloonProperties.Frozen;
            }
            else if (M2HitLead && !M2HitPurple && !M2HitFrozen)
            {
                DamageModel.immuneBloonProperties = BloonProperties.Purple | BloonProperties.Frozen;
            }
            else if (M2HitAll && M2HitPurple && !M2HitFrozen)
            {
                DamageModel.immuneBloonProperties = BloonProperties.Frozen;
            }
            else if (M2HitLead && !M2HitPurple && M2HitFrozen)
            {
                DamageModel.immuneBloonProperties = BloonProperties.Purple;
            }
            else if (!M2HitFrozen && M2HitPurple && M2HitFrozen)
            {
                DamageModel.immuneBloonProperties = BloonProperties.Lead;
            }
            else if (M2HitFrozen && M2HitPurple && M2HitFrozen)
            {
                DamageModel.immuneBloonProperties = BloonProperties.None;
            }
            if (M2Camo)
            {
                towerModel.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
            }
            MultiShotTotal += M2MultiShotNumber;
            towerModel.GetWeapon().emission = new ArcEmissionModel("Emission", MultiShotTotal, M2MultiShotOffset, M2MultiShotRotation, null, false, false);
        }
    }
    internal class MUpgrade3 : ModUpgrade<CustomizableTowerClass>
    {
        public override int Path => MIDDLE;

        public override int Tier => 3;

        public override int Cost => MU3Cost;
        public override string DisplayName => MU3Name;
        public override string Description => MU3Desc;

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.range += MU3Range;
            var AttackModel = towerModel.GetAttackModel();
            var WeaponModel = AttackModel.weapons[0];
            var ProjectileModel = WeaponModel.projectile;
            var DamageModel = ProjectileModel.GetDamageModel();

            AttackModel.range += MU3Range;
            WeaponModel.rate *= MU3Speed;
            ProjectileModel.pierce += MU3Pierce;
            DamageModel.damage += MU3Damage;
            if (M3HitAll)
            {
                DamageModel.immuneBloonProperties = BloonProperties.None;
            }
            else if (!M3HitFrozen && !M3HitLead && !M3HitPurple)
            {
                DamageModel.immuneBloonProperties = BloonProperties.Lead | BloonProperties.Purple | BloonProperties.Frozen;
            }
            else if (!M3HitLead && !M3HitPurple && M3HitFrozen)
            {
                DamageModel.immuneBloonProperties = BloonProperties.Lead | BloonProperties.Purple;
            }
            else if (!M3HitLead && M3HitPurple && !M3HitFrozen)
            {
                DamageModel.immuneBloonProperties = BloonProperties.Lead | BloonProperties.Frozen;
            }
            else if (M3HitLead && !M3HitPurple && !M3HitFrozen)
            {
                DamageModel.immuneBloonProperties = BloonProperties.Purple | BloonProperties.Frozen;
            }
            else if (M3HitAll && M3HitPurple && !M3HitFrozen)
            {
                DamageModel.immuneBloonProperties = BloonProperties.Frozen;
            }
            else if (M3HitLead && !M3HitPurple && M3HitFrozen)
            {
                DamageModel.immuneBloonProperties = BloonProperties.Purple;
            }
            else if (!M3HitFrozen && M3HitPurple && M3HitFrozen)
            {
                DamageModel.immuneBloonProperties = BloonProperties.Lead;
            }
            else if (M3HitFrozen && M3HitPurple && M3HitFrozen)
            {
                DamageModel.immuneBloonProperties = BloonProperties.None;
            }
            if (M3Camo)
            {
                towerModel.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
            }
            MultiShotTotal += M3MultiShotNumber;
            towerModel.GetWeapon().emission = new ArcEmissionModel("Emission", MultiShotTotal, M3MultiShotOffset, M3MultiShotRotation, null, false, false);
        }
    }
    internal class MUpgrade4 : ModUpgrade<CustomizableTowerClass>
    {
        public override int Path => MIDDLE;

        public override int Tier => 4;

        public override int Cost => MU4Cost;
        public override string DisplayName => MU4Name;
        public override string Description => MU4Desc;

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.range += MU4Range;
            var AttackModel = towerModel.GetAttackModel();
            var WeaponModel = AttackModel.weapons[0];
            var ProjectileModel = WeaponModel.projectile;
            var DamageModel = ProjectileModel.GetDamageModel();

            AttackModel.range += MU4Range;
            WeaponModel.rate *= MU4Speed;
            ProjectileModel.pierce += MU4Pierce;
            DamageModel.damage += MU4Damage;
            if (M4HitAll)
            {
                DamageModel.immuneBloonProperties = BloonProperties.None;
            }
            else if (!M4HitFrozen && !M4HitLead && !M4HitPurple)
            {
                DamageModel.immuneBloonProperties = BloonProperties.Lead | BloonProperties.Purple | BloonProperties.Frozen;
            }
            else if (!M4HitLead && !M4HitPurple && M4HitFrozen)
            {
                DamageModel.immuneBloonProperties = BloonProperties.Lead | BloonProperties.Purple;
            }
            else if (!M4HitLead && M4HitPurple && !M4HitFrozen)
            {
                DamageModel.immuneBloonProperties = BloonProperties.Lead | BloonProperties.Frozen;
            }
            else if (M4HitLead && !M4HitPurple && !M4HitFrozen)
            {
                DamageModel.immuneBloonProperties = BloonProperties.Purple | BloonProperties.Frozen;
            }
            else if (M4HitAll && M4HitPurple && !M4HitFrozen)
            {
                DamageModel.immuneBloonProperties = BloonProperties.Frozen;
            }
            else if (M4HitLead && !M4HitPurple && M4HitFrozen)
            {
                DamageModel.immuneBloonProperties = BloonProperties.Purple;
            }
            else if (!M4HitFrozen && M4HitPurple && M4HitFrozen)
            {
                DamageModel.immuneBloonProperties = BloonProperties.Lead;
            }
            else if (M4HitFrozen && M4HitPurple && M4HitFrozen)
            {
                DamageModel.immuneBloonProperties = BloonProperties.None;
            }
            if (M4Camo)
            {
                towerModel.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
            }
            MultiShotTotal += M4MultiShotNumber;
            towerModel.GetWeapon().emission = new ArcEmissionModel("Emission", MultiShotTotal, M4MultiShotOffset, M4MultiShotRotation, null, false, false);
        }
    }
    internal class MUpgrade5 : ModUpgrade<CustomizableTowerClass>
    {
        public override int Path => MIDDLE;

        public override int Tier => 5;

        public override int Cost => MU5Cost;
        public override string DisplayName => MU5Name;
        public override string Description => MU5Desc;

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.range += MU5Range;
            var AttackModel = towerModel.GetAttackModel();
            var WeaponModel = AttackModel.weapons[0];
            var ProjectileModel = WeaponModel.projectile;
            var DamageModel = ProjectileModel.GetDamageModel();

            AttackModel.range += MU5Range;
            WeaponModel.rate *= MU5Speed;
            ProjectileModel.pierce += MU5Pierce;
            DamageModel.damage += MU5Damage;
            if (M5HitAll)
            {
                DamageModel.immuneBloonProperties = BloonProperties.None;
            }
            else if (!M5HitFrozen && !M5HitLead && !M5HitPurple)
            {
                DamageModel.immuneBloonProperties = BloonProperties.Lead | BloonProperties.Purple | BloonProperties.Frozen;
            }
            else if (!M5HitLead && !M5HitPurple && M5HitFrozen)
            {
                DamageModel.immuneBloonProperties = BloonProperties.Lead | BloonProperties.Purple;
            }
            else if (!M5HitLead && M5HitPurple && !M5HitFrozen)
            {
                DamageModel.immuneBloonProperties = BloonProperties.Lead | BloonProperties.Frozen;
            }
            else if (M5HitLead && !M5HitPurple && !M5HitFrozen)
            {
                DamageModel.immuneBloonProperties = BloonProperties.Purple | BloonProperties.Frozen;
            }
            else if (M5HitAll && M5HitPurple && !M5HitFrozen)
            {
                DamageModel.immuneBloonProperties = BloonProperties.Frozen;
            }
            else if (M5HitLead && !M5HitPurple && M5HitFrozen)
            {
                DamageModel.immuneBloonProperties = BloonProperties.Purple;
            }
            else if (!M5HitFrozen && M5HitPurple && M5HitFrozen)
            {
                DamageModel.immuneBloonProperties = BloonProperties.Lead;
            }
            else if (M5HitFrozen && M5HitPurple && M5HitFrozen)
            {
                DamageModel.immuneBloonProperties = BloonProperties.None;
            }
            if (M5Camo)
            {
                towerModel.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
            }
            MultiShotTotal += M5MultiShotNumber;
            towerModel.GetWeapon().emission = new ArcEmissionModel("Emission", MultiShotTotal, M5MultiShotOffset, M5MultiShotRotation, null, false, false);
        }
    }
}
