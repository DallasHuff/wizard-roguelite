using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Woguelite.Stats
{
    public class Inventory : MonoBehaviour
    {
        #region Singleton
        public static Inventory instance;

        private void Awake()
        {
            if (instance != null)
            {
                Debug.LogWarning("More than once instance of Inventory found!");
                return;
            }

            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        #endregion

        public delegate void OnItemPickup(Item item);
        public OnItemPickup onItemPickup;

        public Dictionary<Item, int> items = new Dictionary<Item, int>();

        public void Add(Item item)
        {
            if (onItemPickup != null)
            {
                if (!items.ContainsKey(item))
                {
                    items.Add(item, 0);
                }
                items[item]++;
                item.Modify();
                onItemPickup.Invoke(item);
            }
        }
    }
}
// load several shop lists based on rarity of items
// ex. epicItems = resources.LoadAll("items/epic")

// when reroll button is pressed, choose a rarity for each slot, and then an item from each rarity list. have another array that contains costs

// when buy button is pressed, check if you have that much money. if you do, add the item to inventory and subtract cost from your total money

// TODO:
// make PH sprites that go in the description of the items
