using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using CustomizableTower.Api.Projectile;
using CustomizableTower.Api.Projectile.Behaviour;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.TowerSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomizableTower
{
    public class TestTower : ModTower
    {
        public override TowerSet TowerSet => TowerSet.Primary;

        public override string BaseTower => TowerType.DartMonkey;

        public override int Cost => 450;

        public override void ModifyBaseTowerModel(TowerModel towerModel)
        {
            ProjectileModelBuilder projectileModelBuilder = new ProjectileModelBuilder(new Api.Projectile.Data.ProjectileData() { BaseProjectileDisplay = "26e9c99e89180fd468cb47d76c7536b6", DisplayType = Api.DisplayType.Vanilla }, [new DamageBuilder(new Api.Projectile.Behaviour.Data.DamageData()), new TravelStraitBuilder(new Api.Projectile.Behaviour.Data.TravelStraightData())]);

            towerModel.GetWeapon().projectile = projectileModelBuilder.Build();
        }
    }
}
