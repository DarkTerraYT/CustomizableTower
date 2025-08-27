using BTD_Mod_Helper.Api.Components;
using CustomizableTower.Api.Projectile.Behaviour.Data;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomizableTower.Api.Projectile.Behaviour
{
    public class TravelStraitBuilder : ProjectileBehaviorBuilder<TravelStraitModel>
    {
        public TravelStraitBuilder(TravelStraightData data) 
        {
            Data = data;
        }

        TravelStraightData Data;

        public override TravelStraitModel Build() => new TravelStraitModel(Data.Name, Data.Speed, Data.Lifespan);

        public override ModHelperPanel CreateBuilderPanel()
        {
            return null;
        }

        public override string Serialize() => JsonConvert.SerializeObject(this);
    }
}
