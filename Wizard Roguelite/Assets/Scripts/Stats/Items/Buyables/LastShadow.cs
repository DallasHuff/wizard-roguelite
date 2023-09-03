using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Woguelite.Stats
{
    public class LastShadow : Item
    {
        float damMod;
        float speedMod;
        int cost;

        public override void Modify()
        {
            //CharacterStats.instance.UpdateStat(CharacterStats.instance.damage, damMod);
            //CharacterStats.instance.UpdateStat(CharacterStats.instance.damage, speedMod);
        }
        public override int baseCost
        {
            get
            {
                return cost;
            }
        }
    }
}

// possible effects

// execute enemies under 5% hp and generate additional gold for the kill
// armor pen = old morello in league
// abilities deal a DoT like liandry in league