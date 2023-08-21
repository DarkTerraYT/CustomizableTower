using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;

namespace CustomizableTower.BottomPath
{
    internal class BUpgrade1 : ModUpgrade<CustomizableTowerClass>
    {
        public override int Path => BOTTOM;

        public override int Tier => 1;

        public override int Cost => CustomizableTower.BU1Cost;
        public override string DisplayName => CustomizableTower.BU1Name;
        public override string Description => CustomizableTower.BU1Desc;

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.range += CustomizableTower.BU1Range;
            var AttackModel = towerModel.GetAttackModel();
            var WeaponModel = AttackModel.weapons[0];
            var ProjectileModel = WeaponModel.projectile;
            var DamageModel = ProjectileModel.GetDamageModel();

            AttackModel.range += CustomizableTower.BU1Range;
            WeaponModel.rate *= CustomizableTower.BU1Speed;
            ProjectileModel.pierce += CustomizableTower.BU1Pierce;
            DamageModel.damage += CustomizableTower.BU1Damage;
        }
    }
    internal class BUpgrade2 : ModUpgrade<CustomizableTowerClass>
    {
        public override int Path => BOTTOM;

        public override int Tier => 2;

        public override int Cost => CustomizableTower.BU2Cost;
        public override string DisplayName => CustomizableTower.BU2Name;
        public override string Description => CustomizableTower.BU2Desc;

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.range += CustomizableTower.BU2Range;
            var AttackModel = towerModel.GetAttackModel();
            var WeaponModel = AttackModel.weapons[0];
            var ProjectileModel = WeaponModel.projectile;
            var DamageModel = ProjectileModel.GetDamageModel();

            AttackModel.range += CustomizableTower.BU2Range;
            WeaponModel.rate *= CustomizableTower.BU2Speed;
            ProjectileModel.pierce += CustomizableTower.BU2Pierce;
            DamageModel.damage += CustomizableTower.BU2Damage;
        }
    }
    internal class BUpgrade3 : ModUpgrade<CustomizableTowerClass>
    {
        public override int Path => BOTTOM;

        public override int Tier => 3;

        public override int Cost => CustomizableTower.BU3Cost;
        public override string DisplayName => CustomizableTower.BU3Name;
        public override string Description => CustomizableTower.BU3Desc;

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.range += CustomizableTower.BU3Range;
            var AttackModel = towerModel.GetAttackModel();
            var WeaponModel = AttackModel.weapons[0];
            var ProjectileModel = WeaponModel.projectile;
            var DamageModel = ProjectileModel.GetDamageModel();

            AttackModel.range += CustomizableTower.BU3Range;
            WeaponModel.rate *= CustomizableTower.BU3Speed;
            ProjectileModel.pierce += CustomizableTower.BU3Pierce;
            DamageModel.damage += CustomizableTower.BU3Damage;
        }
    }
    internal class BUpgrade4 : ModUpgrade<CustomizableTowerClass>
    {
        public override int Path => BOTTOM;

        public override int Tier => 4;

        public override int Cost => CustomizableTower.BU4Cost;
        public override string DisplayName => CustomizableTower.BU4Name;
        public override string Description => CustomizableTower.BU4Desc;

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.range += CustomizableTower.BU4Range;
            var AttackModel = towerModel.GetAttackModel();
            var WeaponModel = AttackModel.weapons[0];
            var ProjectileModel = WeaponModel.projectile;
            var DamageModel = ProjectileModel.GetDamageModel();

            AttackModel.range += CustomizableTower.BU4Range;
            WeaponModel.rate *= CustomizableTower.BU4Speed;
            ProjectileModel.pierce += CustomizableTower.BU4Pierce;
            DamageModel.damage += CustomizableTower.BU4Damage;
        }
    }
    internal class BUpgrade5 : ModUpgrade<CustomizableTowerClass>
    {
        public override int Path => BOTTOM;

        public override int Tier => 5;

        public override int Cost => CustomizableTower.BU5Cost;
        public override string DisplayName => CustomizableTower.BU5Name;
        public override string Description => CustomizableTower.BU5Desc;

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.range += CustomizableTower.BU5Range;
            var AttackModel = towerModel.GetAttackModel();
            var WeaponModel = AttackModel.weapons[0];
            var ProjectileModel = WeaponModel.projectile;
            var DamageModel = ProjectileModel.GetDamageModel();

            AttackModel.range += CustomizableTower.BU5Range;
            WeaponModel.rate *= CustomizableTower.BU5Speed;
            ProjectileModel.pierce += CustomizableTower.BU5Pierce;
            DamageModel.damage += CustomizableTower.BU5Damage;
        }
    }
}
