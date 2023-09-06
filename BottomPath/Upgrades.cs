using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2Cpp;
using static CustomizableTower.CustomizableTower;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using CustomizableTower;
using Il2CppNinjaKiwi.LiNK.AuthenticationProviders;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;

namespace BottomPath
{
    internal class BUpgrade1 : ModUpgrade<CustomizableTowerClass>
    {
        public override int Path => BOTTOM;

        public override int Tier => 1;

        public override int Cost => BU1Cost;
        public override string DisplayName => BU1Name;
        public override string Description => BU1Desc;

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.range += BU1Range;
            var AttackModel = towerModel.GetAttackModel();
            var WeaponModel = AttackModel.weapons[0];
            var ProjectileModel = WeaponModel.projectile;
            var DamageModel = ProjectileModel.GetDamageModel();

            AttackModel.range += BU1Range;
            WeaponModel.rate *= BU1Speed;
            ProjectileModel.pierce += BU1Pierce;
            DamageModel.damage += BU1Damage;
            if(B1HitAll)
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
            if(B1Camo)
            {
                towerModel.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
            }
            MultiShotTotal += B1MultiShotNumber;
            towerModel.GetWeapon().emission = new ArcEmissionModel("Emission", MultiShotTotal, B1MultiShotOffset, B1MultiShotRotation, null, false, false);
        }

    }
    internal class BUpgrade2 : ModUpgrade<CustomizableTowerClass>
    {
        public override int Path => BOTTOM;

        public override int Tier => 2;

        public override int Cost => BU2Cost;
        public override string DisplayName => BU2Name;
        public override string Description => BU2Desc;

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.range += BU2Range;
            var AttackModel = towerModel.GetAttackModel();
            var WeaponModel = AttackModel.weapons[0];
            var ProjectileModel = WeaponModel.projectile;
            var DamageModel = ProjectileModel.GetDamageModel();

            AttackModel.range += BU2Range;
            WeaponModel.rate *= BU2Speed;
            ProjectileModel.pierce += BU2Pierce;
            DamageModel.damage += BU2Damage;
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
            if (B2Camo)
            {
                towerModel.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
            }
            MultiShotTotal += B2MultiShotNumber;
            towerModel.GetWeapon().emission = new ArcEmissionModel("Emission", MultiShotTotal, B2MultiShotOffset, B2MultiShotRotation, null, false, false);
        }
    }
    internal class BUpgrade3 : ModUpgrade<CustomizableTowerClass>
    {
        public override int Path => BOTTOM;

        public override int Tier => 3;

        public override int Cost => BU3Cost;
        public override string DisplayName => BU3Name;
        public override string Description => BU3Desc;

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.range += BU3Range;
            var AttackModel = towerModel.GetAttackModel();
            var WeaponModel = AttackModel.weapons[0];
            var ProjectileModel = WeaponModel.projectile;
            var DamageModel = ProjectileModel.GetDamageModel();

            AttackModel.range += BU3Range;
            WeaponModel.rate *= BU3Speed;
            ProjectileModel.pierce += BU3Pierce;
            DamageModel.damage += BU3Damage;

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
            if (B3Camo)
            {
                towerModel.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
            }
            MultiShotTotal += B3MultiShotNumber;
            towerModel.GetWeapon().emission = new ArcEmissionModel("Emission", MultiShotTotal, B3MultiShotOffset, B3MultiShotRotation, null, false, false);
        }

    }
    internal class BUpgrade4 : ModUpgrade<CustomizableTowerClass>
    {
        public override int Path => BOTTOM;

        public override int Tier => 4;

        public override int Cost => BU4Cost;
        public override string DisplayName => BU4Name;
        public override string Description => BU4Desc;

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.range += BU4Range;
            var AttackModel = towerModel.GetAttackModel();
            var WeaponModel = AttackModel.weapons[0];
            var ProjectileModel = WeaponModel.projectile;
            var DamageModel = ProjectileModel.GetDamageModel();

            AttackModel.range += BU4Range;
            WeaponModel.rate *= BU4Speed;
            ProjectileModel.pierce += BU4Pierce;
            DamageModel.damage += BU4Damage;
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
            if (B4Camo)
            {
                towerModel.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);

            }
            MultiShotTotal += B4MultiShotNumber;
            towerModel.GetWeapon().emission = new ArcEmissionModel("Emission", MultiShotTotal, B4MultiShotOffset, B4MultiShotRotation, null, false, false);
        }
    }
    internal class BUpgrade5 : ModUpgrade<CustomizableTowerClass>
    {
        public override int Path => BOTTOM;

        public override int Tier => 5;

        public override int Cost => BU5Cost;
        public override string DisplayName => BU5Name;
        public override string Description => BU5Desc;

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.range += BU5Range;
            var AttackModel = towerModel.GetAttackModel();
            var WeaponModel = AttackModel.weapons[0];
            var ProjectileModel = WeaponModel.projectile;
            var DamageModel = ProjectileModel.GetDamageModel();

            AttackModel.range += BU5Range;
            WeaponModel.rate *= BU5Speed;
            ProjectileModel.pierce += BU5Pierce;
            DamageModel.damage += BU5Damage;
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
            if (B5Camo)
            {
                towerModel.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
            }
            MultiShotTotal += B5MultiShotNumber;
            towerModel.GetWeapon().emission = new ArcEmissionModel("Emission", MultiShotTotal, B5MultiShotOffset, B5MultiShotRotation, null, false, false);
        }
    }
}
