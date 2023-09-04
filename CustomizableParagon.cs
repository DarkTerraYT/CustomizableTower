using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using static CustomizableTower.CustomizableTower;
namespace CustomizableTower
{
    internal class CustomizableParagon : ModParagonUpgrade<CustomizableTowerClass>
    {
        public override int Cost => ParagonCost;
        public override string DisplayName => ParagonName;
        public override string Description => "This is a paragon";
        public override string Icon => "CustomizableParagon-Icon";
        public override string Portrait => "CustomizableParagon-Icon";
        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.ApplyDisplay<CustomizableParagonDisplay>();
            towerModel.range += ParagonRange;
            towerModel.GetAttackModel().range += ParagonRange;
            towerModel.GetWeapon().rate *= ParagonSpeedModifier;
            towerModel.GetWeapon().projectile.pierce += ParagonPierce;
            towerModel.GetWeapon().projectile.GetDamageModel().damage += ParagonDamageBuff;
            towerModel.GetWeapon().projectile.GetDamageModel().immuneBloonProperties = Il2Cpp.BloonProperties.None;
            towerModel.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
        }
    }
}
