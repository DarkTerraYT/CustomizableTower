using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;

namespace CustomizableTower.MiddlePath
{
    internal class MUpgrade1 : ModUpgrade<CustomizableTowerClass>
    {
        public override int Path => MIDDLE;

        public override int Tier => 1;

        public override int Cost => CustomizableTower.MU1Cost;
        public override string DisplayName => CustomizableTower.MU1Name;
        public override string Description => CustomizableTower.MU1Desc;

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.range += CustomizableTower.MU1Range;
            var AttackModel = towerModel.GetAttackModel();
            var WeaponModel = AttackModel.weapons[0];
            var ProjectileModel = WeaponModel.projectile;
            var DamageModel = ProjectileModel.GetDamageModel();

            AttackModel.range += CustomizableTower.MU1Range;
            WeaponModel.rate *= CustomizableTower.MU1Speed;
            ProjectileModel.pierce += CustomizableTower.MU1Pierce;
            DamageModel.damage += CustomizableTower.MU1Damage;
        }
    }
    internal class MUpgrade2 : ModUpgrade<CustomizableTowerClass>
    {
        public override int Path => MIDDLE;

        public override int Tier => 2;

        public override int Cost => CustomizableTower.MU2Cost;
        public override string DisplayName => CustomizableTower.MU2Name;
        public override string Description => CustomizableTower.MU2Desc;

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.range += CustomizableTower.MU2Range;
            var AttackModel = towerModel.GetAttackModel();
            var WeaponModel = AttackModel.weapons[0];
            var ProjectileModel = WeaponModel.projectile;
            var DamageModel = ProjectileModel.GetDamageModel();

            AttackModel.range += CustomizableTower.MU2Range;
            WeaponModel.rate *= CustomizableTower.MU2Speed;
            ProjectileModel.pierce += CustomizableTower.MU2Pierce;
            DamageModel.damage += CustomizableTower.MU2Damage;
        }
    }
    internal class MUpgrade3 : ModUpgrade<CustomizableTowerClass>
    {
        public override int Path => MIDDLE;

        public override int Tier => 3;

        public override int Cost => CustomizableTower.MU3Cost;
        public override string DisplayName => CustomizableTower.MU3Name;
        public override string Description => CustomizableTower.MU3Desc;

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.range += CustomizableTower.MU3Range;
            var AttackModel = towerModel.GetAttackModel();
            var WeaponModel = AttackModel.weapons[0];
            var ProjectileModel = WeaponModel.projectile;
            var DamageModel = ProjectileModel.GetDamageModel();

            AttackModel.range += CustomizableTower.MU3Range;
            WeaponModel.rate *= CustomizableTower.MU3Speed;
            ProjectileModel.pierce += CustomizableTower.MU3Pierce;
            DamageModel.damage += CustomizableTower.MU3Damage;
        }
    }
    internal class MUpgrade4 : ModUpgrade<CustomizableTowerClass>
    {
        public override int Path => MIDDLE;

        public override int Tier => 4;

        public override int Cost => CustomizableTower.MU4Cost;
        public override string DisplayName => CustomizableTower.MU4Name;
        public override string Description => CustomizableTower.MU4Desc;

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.range += CustomizableTower.MU4Range;
            var AttackModel = towerModel.GetAttackModel();
            var WeaponModel = AttackModel.weapons[0];
            var ProjectileModel = WeaponModel.projectile;
            var DamageModel = ProjectileModel.GetDamageModel();

            AttackModel.range += CustomizableTower.MU4Range;
            WeaponModel.rate *= CustomizableTower.MU4Speed;
            ProjectileModel.pierce += CustomizableTower.MU4Pierce;
            DamageModel.damage += CustomizableTower.MU4Damage;
        }
    }
    internal class MUpgrade5 : ModUpgrade<CustomizableTowerClass>
    {
        public override int Path => MIDDLE;

        public override int Tier => 5;

        public override int Cost => CustomizableTower.MU5Cost;
        public override string DisplayName => CustomizableTower.MU5Name;
        public override string Description => CustomizableTower.MU5Desc;

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.range += CustomizableTower.MU5Range;
            var AttackModel = towerModel.GetAttackModel();
            var WeaponModel = AttackModel.weapons[0];
            var ProjectileModel = WeaponModel.projectile;
            var DamageModel = ProjectileModel.GetDamageModel();

            AttackModel.range += CustomizableTower.MU5Range;
            WeaponModel.rate *= CustomizableTower.MU5Speed;
            ProjectileModel.pierce += CustomizableTower.MU5Pierce;
            DamageModel.damage += CustomizableTower.MU5Damage;
        }
    }
}
