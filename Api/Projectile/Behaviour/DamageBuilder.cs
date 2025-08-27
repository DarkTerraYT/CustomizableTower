using BTD_Mod_Helper.Api.Components;
using CustomizableTower.Api.Projectile.Behaviour.Data;
using Il2Cpp;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomizableTower.Api.Projectile.Behaviour
{
    public class DamageBuilder : ProjectileBehaviorBuilder<DamageModel>
    {
        public DamageBuilder(DamageData data)
        {
            Data = data;
        }

        DamageData Data;

        public override DamageModel Build() => new DamageModel(Data.Name, Data.Damage, Data.MaxDamage, Data.DistributeToChildren, false, Data.CreatePopEffect, (BloonProperties)Data.ImmuneBloonProperties, (BloonProperties)Data.ImmuneBloonProperties, Data.IgnoreImmunityDestroy, Data.IgnoreDamageMultipliers);

        public override ModHelperPanel CreateBuilderPanel()
        {
            throw new NotImplementedException();
        }

        public override string Serialize()
        {
            return JsonConvert.SerializeObject(Data);
        }
    }
}
