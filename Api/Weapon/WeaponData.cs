using Il2CppAssets.Scripts.Models.Towers.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CustomizableTower.Api.Weapon
{
    public struct WeaponData()
    {
        public string Name = "Weapon";
        public float FireRate;
        public bool FireWithoutTarget = false;
        public bool FireBetweenRounds = false;
        public Vector3 FireOffset;

        public string Projectile = "";
        public string Emission = "";

        public List<string> Behaviors = [];
    }
}
