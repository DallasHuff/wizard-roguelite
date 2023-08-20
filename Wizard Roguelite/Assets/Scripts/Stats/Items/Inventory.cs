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