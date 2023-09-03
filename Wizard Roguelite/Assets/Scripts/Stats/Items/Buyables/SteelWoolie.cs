using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Woguelite.Stats;

public class SteelWoolie : Item
{
    float hpMod;
    float armorMod;
    float speedMod;
    int cost;
    public override void Modify()
    {
        //CharacterStats.instance.UpdateStat(CharacterStats.instance.damage, hpMod);
        //CharacterStats.instance.UpdateStat(CharacterStats.instance.damage, armorMod);
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
