using CustomizableTower.Api.Models;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomizableTower.Api.Projectile.Behaviour
{
    public abstract class ProjectileBehaviorBuilder<T> : ModelBuilder<T> where T : ProjectileBehaviorModel
    {
    }
}
