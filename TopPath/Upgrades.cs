using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;

namespace CustomizableTower.TopPath
{
    internal class TUpgrade1 : ModUpgrade<CustomizableTowerClass>
    {
        public override int Path => TOP;

        public override int Tier => 1;

        public override int Cost => CustomizableTower.TU1Cost;
        public override string DisplayName => CustomizableTower.TU1Name;
        public override string Description => CustomizableTower.TU1Desc;

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.range += CustomizableTower.TU1Range;
            var AttackModel = towerModel.GetAttackModel();
            var WeaponModel = AttackModel.weapons[0];
            var ProjectileModel = WeaponModel.projectile;
            var DamageModel = ProjectileModel.GetDamageModel();

            AttackModel.range += CustomizableTower.TU1Range;
            WeaponModel.rate *= CustomizableTower.TU1Speed;
            ProjectileModel.pierce += CustomizableTower.TU1Pierce;
            DamageModel.damage += CustomizableTower.TU1Damage;
        }
    }
    internal class TUpgrade2 : ModUpgrade<CustomizableTowerClass>
    {
        public override int Path => TOP;

        public override int Tier => 2;

        public override int Cost => CustomizableTower.TU2Cost;
        public override string DisplayName => CustomizableTower.TU2Name;
        public override string Description => CustomizableTower.TU2Desc;

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.range += CustomizableTower.TU2Range;
            var AttackModel = towerModel.GetAttackModel();
            var WeaponModel = AttackModel.weapons[0];
            var ProjectileModel = WeaponModel.projectile;
            var DamageModel = ProjectileModel.GetDamageModel();

            AttackModel.range += CustomizableTower.TU2Range;
            WeaponModel.rate *= CustomizableTower.TU2Speed;
            ProjectileModel.pierce += CustomizableTower.TU2Pierce;
            DamageModel.damage += CustomizableTower.TU2Damage;
        }
    }
    internal class TUpgrade3 : ModUpgrade<CustomizableTowerClass>
    {
        public override int Path => TOP;

        public override int Tier => 3;

        public override int Cost => CustomizableTower.TU3Cost;
        public override string DisplayName => CustomizableTower.TU3Name;
        public override string Description => CustomizableTower.TU3Desc;

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.range += CustomizableTower.TU3Range;
            var AttackModel = towerModel.GetAttackModel();
            var WeaponModel = AttackModel.weapons[0];
            var ProjectileModel = WeaponModel.projectile;
            var DamageModel = ProjectileModel.GetDamageModel();

            AttackModel.range += CustomizableTower.TU3Range;
            WeaponModel.rate *= CustomizableTower.TU3Speed;
            ProjectileModel.pierce += CustomizableTower.TU3Pierce;
            DamageModel.damage += CustomizableTower.TU3Damage;
        }
    }
    internal class TUpgrade4 : ModUpgrade<CustomizableTowerClass>
    {
        public override int Path => TOP;

        public override int Tier => 4;

        public override int Cost => CustomizableTower.TU4Cost;
        public override string DisplayName => CustomizableTower.TU4Name;
        public override string Description => CustomizableTower.TU4Desc;

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.range += CustomizableTower.TU4Range;
            var AttackModel = towerModel.GetAttackModel();
            var WeaponModel = AttackModel.weapons[0];
            var ProjectileModel = WeaponModel.projectile;
            var DamageModel = ProjectileModel.GetDamageModel();

            AttackModel.range += CustomizableTower.TU4Range;
            WeaponModel.rate *= CustomizableTower.TU4Speed;
            ProjectileModel.pierce += CustomizableTower.TU4Pierce;
            DamageModel.damage += CustomizableTower.TU4Damage;
        }
    }
    internal class TUpgrade5 : ModUpgrade<CustomizableTowerClass>
    {
        public override int Path => TOP;

        public override int Tier => 5;

        public override int Cost => CustomizableTower.TU5Cost;
        public override string DisplayName => CustomizableTower.TU5Name;
        public override string Description => CustomizableTower.TU5Desc;

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.range += CustomizableTower.TU5Range;
            var AttackModel = towerModel.GetAttackModel();
            var WeaponModel = AttackModel.weapons[0];
            var ProjectileModel = WeaponModel.projectile;
            var DamageModel = ProjectileModel.GetDamageModel();

            AttackModel.range += CustomizableTower.TU5Range;
            WeaponModel.rate *= CustomizableTower.TU5Speed;
            ProjectileModel.pierce += CustomizableTower.TU5Pierce;
            DamageModel.damage += CustomizableTower.TU5Damage;
        }
    }
}
