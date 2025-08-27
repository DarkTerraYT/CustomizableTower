using Il2Cpp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomizableTower.Api.Projectile.Behaviour.Data
{
    public struct DamageData()
    {
        public string Name = "DamageModel_";
        public float Damage = 1;
        public float MaxDamage = 0;
        public float CappedDamage = 1;
        public int CollisionPass = 0;
        public int ImmuneBloonProperties = 17;
        public bool DistributeToChildren = true;
        public bool CreatePopEffect = true;
        public bool IgnoreImmunityDestroy = false;
        public bool IgnoreDamageMultipliers = false;
    }
}
