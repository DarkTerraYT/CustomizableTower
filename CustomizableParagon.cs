using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using static CustomizableTower.CustomizableTower;
namespace CustomizableTower
{
    internal class CustomizableParagon : ModParagonUpgrade<CustomizableTowerClass>
    {
        public override int Cost => ParagonCost;
        public override string DisplayName => ParagonName;
        public override string Description => ParagonDescription;
        public override string Icon => "CustomizableParagon-Icon";
        public override string Portrait => "CustomizableParagon-Icon";
        public override void ApplyUpgrade(TowerModel towerModel)
        {
            CustomizableTowerClass.TotalDamage += ParagonDamageBuff;
            foreach(var WeaponModel in towerModel.GetWeapons())
            {
                WeaponModel.rate = ParagonSpeed;
                WeaponModel.projectile.pierce = ParagonPierce;
                WeaponModel.projectile.AddBehavior(new DamageModel(null, CustomizableTowerClass.TotalDamage, 9999999999999999999, false, false, true, Il2Cpp.BloonProperties.None, Il2Cpp.BloonProperties.None, false, false));
                WeaponModel.emission = new ArcEmissionModel(null, ParagonMultiShotNumber, ParagonMultiShotOffset, ParagonMultiShotAngle, null, false, false);
            }
            towerModel.ApplyDisplay<CustomizableParagonDisplay>();
            towerModel.range = ParagonRange;
            towerModel.GetAttackModel().range = ParagonRange;
            towerModel.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
        }
    }
}
