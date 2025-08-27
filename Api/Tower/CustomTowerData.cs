using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomizableTower.Api.Tower
{
    public struct CustomTowerData
    {
        public string Name;
        public string Description;

        public int Cost;

        public int TowerSet;
        public int DisplayType;

        public List<string> Behaviors;
    }
}
