using BTD_Mod_Helper;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Components;
using CustomizableTower.Api.Models;
using CustomizableTower.Api.Projectile.Behaviour;
using CustomizableTower.Api.Projectile.Data;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomizableTower.Api.Projectile
{
    public class ProjectileModelBuilder : ModelBuilder<ProjectileModel>
    {
        public ProjectileModelBuilder(ProjectileData data, List<ModelBuilder> behaviors, BloonsMod mod) 
        {
            BehaviorBuilders = behaviors;
            Data = data;
            this.mod = mod;
        }
        internal ProjectileModelBuilder(ProjectileData data, List<ModelBuilder> behaviors)
        {
            BehaviorBuilders = behaviors;
            Data = data;
            mod = ModHelper.GetMod<Main>();
        }

        public List<ModelBuilder> BehaviorBuilders = [];

        public List<ProjectileBehaviorModel> GetBehaviors()
        {
            if (BehaviorBuilders == null || BehaviorBuilders.Count == 0)
            {
                return [];
            }

            List<ProjectileBehaviorModel> list = new List<ProjectileBehaviorModel>();

            foreach(var builder in BehaviorBuilders)
            {
                list.Add((ProjectileBehaviorModel)builder.Build());
            }

            return list;
        }

        [JsonProperty]
        private ProjectileData Data { get; set; }

        public override ModHelperPanel CreateBuilderPanel()
        {
            return null;
        }

        public override ProjectileModel Build()
        {
            ProjectileModel model = new(Data.GetDisplayModel().display, Data.Name, Data.Radius, 0, Data.Pierce, Data.MaxPierce, new([.. GetBehaviors()]), null, Data.PassThroughWalls, false, false, Data.Scale, new([]), false, 0, false, false, null, Data.GetDisplayModel());
            return model;
        }

        public override string Serialize()
        {
            return JsonConvert.SerializeObject(Data);
        }
    }
}
