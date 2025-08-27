using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Components;
using Il2CppAssets.Scripts.Models;

namespace CustomizableTower.Api.Models
{
    public abstract class ModelBuilder : ModContent
    {
        public override void Register()
        {
            
        }

        public abstract Model Build();

        public abstract string Serialize();

        public abstract ModHelperPanel CreateBuilderPanel();
    }

    public abstract class ModelBuilder<T> : ModelBuilder where T : Model
    {
        public abstract override T Build();
    }
}
