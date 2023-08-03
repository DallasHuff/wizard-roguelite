using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Woguelite.Stats
{
    public interface IHitDetector
    {
        public IHitResponder hitResponder { get; set; }
        public void CheckHit();
    }
}