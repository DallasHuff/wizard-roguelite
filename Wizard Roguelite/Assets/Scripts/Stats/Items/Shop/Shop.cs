using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Woguelite.Stats;

public class Shop : MonoBehaviour
{
    #region Singleton
    public static Shop instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than once instance of Shop found!");
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    #endregion

    // load several shop lists based on rarity of items
    // ex. epicItems = resources.LoadAll("items/epic")

    // when reroll button is pressed, choose a rarity for each slot, and then an item from each rarity list. have another array that contains costs

    // when buy button is pressed, check if you have that much money. if you do, add the item to inventory and subtract cost from your total money

    // TODO:
    // make PH sprites that go in the description of the items

}
