using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Woguelite.Stats
{
    public interface IHurtBox
    {
        public bool active { get; }
        public GameObject owner { get; }
        public Transform trans { get; }
        public IHurtResponder hurtResponder { get; set; }
        public bool CheckHit(HitData hitData);
    }
}