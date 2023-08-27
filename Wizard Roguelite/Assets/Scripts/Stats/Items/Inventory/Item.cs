using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

namespace Woguelite.Stats
{
    public abstract class Item : ScriptableObject
    {
        new public string name = "New item";
        public Sprite icon = null;
        public string description;
        public string rarity;
        public abstract int baseCost { get; }

        public abstract void Modify();
    }
}