using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


namespace Woguelite.Stats
{
    [CreateAssetMenu(fileName = "DallasDagger", menuName = "Inventory/Item/DallasDagger")]
    public class DallasDagger : Item
    {
        float damMod = 0.05f;
        float aHMod = 5f;

        public override void Modify()
        {
            CharacterStats.instance.UpdateStat(CharacterStats.instance.damage, damMod);
            CharacterStats.instance.UpdateStat(CharacterStats.instance.abilityHaste, aHMod);
        }
    }
}