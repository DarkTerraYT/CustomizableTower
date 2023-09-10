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

namespace MiddlePath
{
    internal class MUpgrade1 : ModUpgrade<CustomizableTowerClass>
    {
        public override int Path => MIDDLE;

        public override int Tier => 1;

        public override int Cost => MU1Cost;
        public override string DisplayName => MU1Name;
        public override string Description => MU1Desc;
        public override int Priority => -2;

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            TotalDamage += MU1Damage;
            foreach (var WeaponModel in towerModel.GetWeapons())
            {
                towerModel.GetAttackModel().weapons[0].emission = new ArcEmissionModel("Emission", M1MultiShotNumber, M1MultiShotOffset, M1MultiShotRotation, null, false, false);
                var ProjectileModel = WeaponModel.projectile;
                ProjectileModel.AddBehavior(new DamageModel(null, TotalDamage, 9999999999999999999, false, false, true, Il2Cpp.BloonProperties.None, Il2Cpp.BloonProperties.None));
                var DamageModel = ProjectileModel.GetDamageModel();
                WeaponModel.rate *= MU1Speed;
                ProjectileModel.pierce += MU1Pierce;
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
                if (M1Moabs)
                {
                    WeaponModel.projectile.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Moab", "Moab", M1MoabDamageMulti, M1MoabDamageAdditive, false, false));
                }
                if (M1Ceramics)
                {
                    WeaponModel.projectile.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Ceramic", "Ceramic", M1CeramicDamageMulti, M1CeramicDamageAdditive, false, false));
                }
                if (M1Fortified)
                {
                    WeaponModel.projectile.AddBehavior(new DamageModifierForTagModel("DamageModelForTagModel_Fortified", "Fortified", M1FortifiedDamageMulti, M1FortifiedDamageAdditive, false, false));
                }

            }
            towerModel.range += MU1Range;
            var AttackModel = towerModel.GetAttackModel();

            AttackModel.range += MU1Range;
            if (M1Camo)
            {
                towerModel.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
            }
        }
    }
    internal class MUpgrade2 : ModUpgrade<CustomizableTowerClass>
    {
        public override int Path => MIDDLE;

        public override int Tier => 2;

        public override int Cost => MU2Cost;
        public override string DisplayName => MU2Name;
        public override string Description => MU2Desc;
        public override int Priority => -2;

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            TotalDamage += MU2Damage;
            foreach (var WeaponModel in towerModel.GetWeapons())
            {
                towerModel.GetAttackModel().weapons[0].emission = new ArcEmissionModel("Emission", M2MultiShotNumber, M2MultiShotOffset, M2MultiShotRotation, null, false, false);
                var ProjectileModel = WeaponModel.projectile;
                ProjectileModel.AddBehavior(new DamageModel(null, TotalDamage, 9999999999999999999, false, false, true, Il2Cpp.BloonProperties.None, Il2Cpp.BloonProperties.None));
                var DamageModel = ProjectileModel.GetDamageModel();
                WeaponModel.rate *= MU2Speed;
                ProjectileModel.pierce += MU2Pierce;
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
                if (M2Moabs)
                {
                    WeaponModel.projectile.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Moab", "Moab", M2MoabDamageMulti, M2MoabDamageAdditive, false, false));
                }
                if (M2Ceramics)
                {
                    WeaponModel.projectile.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Ceramic", "Ceramic", M2CeramicDamageMulti, M2CeramicDamageAdditive, false, false));
                }
                if (M2Fortified)
                {
                    WeaponModel.projectile.AddBehavior(new DamageModifierForTagModel("DamageModelForTagModel_Fortified", "Fortified", M2FortifiedDamageMulti, M2FortifiedDamageAdditive, false, false));
                }

            }
            towerModel.range += MU2Range;
            var AttackModel = towerModel.GetAttackModel();
            AttackModel.range += MU2Range;
            if (M2Camo)
            {
                towerModel.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
            }
        }
    }
    internal class MUpgrade3 : ModUpgrade<CustomizableTowerClass>
    {
        public override int Path => MIDDLE;

        public override int Tier => 3;

        public override int Cost => MU3Cost;
        public override string DisplayName => MU3Name;
        public override string Description => MU3Desc;
        public override int Priority => -2;

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            TotalDamage += MU3Damage;
            foreach (var WeaponModel in towerModel.GetWeapons())
            {
                towerModel.GetAttackModel().weapons[0].emission = new ArcEmissionModel("Emission", M3MultiShotNumber, M3MultiShotOffset, M3MultiShotRotation, null, false, false);
                var ProjectileModel = WeaponModel.projectile;
                ProjectileModel.AddBehavior(new DamageModel(null, TotalDamage, 9999999999999999999, false, false, true, Il2Cpp.BloonProperties.None, Il2Cpp.BloonProperties.None));
                var DamageModel = ProjectileModel.GetDamageModel();

                WeaponModel.rate *= MU3Speed;
                ProjectileModel.pierce += MU3Pierce;
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
                if (M3Moabs)
                {
                    WeaponModel.projectile.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Moab", "Moab", M3MoabDamageMulti, M3MoabDamageAdditive, false, false));
                }
                if (M3Ceramics)
                {
                    WeaponModel.projectile.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Ceramic", "Ceramic", M3CeramicDamageMulti, M3CeramicDamageAdditive, false, false));
                }
                if (M3Fortified)
                {
                    WeaponModel.projectile.AddBehavior(new DamageModifierForTagModel("DamageModelForTagModel_Fortified", "Fortified", M3FortifiedDamageMulti, M3FortifiedDamageAdditive, false, false));
                }

            }
            towerModel.range += MU3Range;
            var AttackModel = towerModel.GetAttackModel();
            AttackModel.range += MU3Range;
        }
    }
    internal class MUpgrade4 : ModUpgrade<CustomizableTowerClass>
    {
        public override int Path => MIDDLE;

        public override int Tier => 4;

        public override int Cost => MU4Cost;
        public override string DisplayName => MU4Name;
        public override string Description => MU4Desc;
        public override int Priority => -2;

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            TotalDamage += MU4Damage;
            foreach (var WeaponModel in towerModel.GetWeapons())
            {
                towerModel.GetAttackModel().weapons[0].emission = new ArcEmissionModel("Emission", M4MultiShotNumber, M4MultiShotOffset, M4MultiShotRotation, null, false, false);
                var ProjectileModel = WeaponModel.projectile;
                ProjectileModel.AddBehavior(new DamageModel(null, TotalDamage, 9999999999999999999, false, false, true, Il2Cpp.BloonProperties.None, Il2Cpp.BloonProperties.None));
                var DamageModel = ProjectileModel.GetDamageModel();

                WeaponModel.rate *= MU4Speed;
                ProjectileModel.pierce += MU4Pierce;
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
                if (M4Moabs)
                {
                    WeaponModel.projectile.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Moab", "Moab", M4MoabDamageMulti, M4MoabDamageAdditive, false, false));
                }
                if (M4Ceramics)
                {
                    WeaponModel.projectile.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Ceramic", "Ceramic", M4CeramicDamageMulti, M4CeramicDamageAdditive, false, false));
                }
                if (M4Fortified)
                {
                    WeaponModel.projectile.AddBehavior(new DamageModifierForTagModel("DamageModelForTagModel_Fortified", "Fortified", M4FortifiedDamageMulti, M4FortifiedDamageAdditive, false, false));
                }

            }
            towerModel.range += MU4Range;
            var AttackModel = towerModel.GetAttackModel();
            AttackModel.range += MU4Range;
            if (M4Camo)
            {
                towerModel.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
            }
        }
    }
    internal class MUpgrade5 : ModUpgrade<CustomizableTowerClass>
    {
        public override int Path => MIDDLE;

        public override int Tier => 5;

        public override int Cost => MU5Cost;
        public override string DisplayName => MU5Name;
        public override string Description => MU5Desc;
        public override int Priority => -2;

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            TotalDamage += MU5Damage;
            foreach (var WeaponModel in towerModel.GetWeapons())
            {
                var ProjectileModel = WeaponModel.projectile;
                ProjectileModel.AddBehavior(new DamageModel(null, TotalDamage, 9999999999999999999, false, false, true, Il2Cpp.BloonProperties.None, Il2Cpp.BloonProperties.None));
                var DamageModel = ProjectileModel.GetDamageModel();

                WeaponModel.rate *= MU5Speed;
                ProjectileModel.pierce += MU5Pierce;
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
                if (M5Moabs)
                {
                    WeaponModel.projectile.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Moab", "Moab", M5MoabDamageMulti, M5MoabDamageAdditive, false, false));
                }
                if (M5Ceramics)
                {
                    WeaponModel.projectile.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Ceramic", "Ceramic", M5CeramicDamageMulti, M5CeramicDamageAdditive, false, false));
                }
                if (M5Fortified)
                {
                    WeaponModel.projectile.AddBehavior(new DamageModifierForTagModel("DamageModelForTagModel_Fortified", "Fortified", M5FortifiedDamageMulti, M5FortifiedDamageAdditive, false, false));
                }

                towerModel.GetAttackModel().weapons[0].emission = new ArcEmissionModel("Emission", M5MultiShotNumber, M5MultiShotOffset, M5MultiShotRotation, null, false, false);
            }
            towerModel.range += MU5Range;
            var AttackModel = towerModel.GetAttackModel();
            AttackModel.range += MU5Range;
            if (M5Camo)
            {
                towerModel.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
            }
        }
    }
}
