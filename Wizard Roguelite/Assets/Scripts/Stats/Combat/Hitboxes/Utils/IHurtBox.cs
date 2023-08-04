using UnityEngine;
using Woguelite.Enums;

namespace Woguelite.Stats
{
    public interface IHurtBox
    {
        public bool Active { get; }
        public GameObject Owner { get; }
        public Transform Transform { get; }
        public HurtboxType Type { get; }
        public IHurtResponder HurtResponder { get; set; }
        public bool CheckHit(HitData hitData);
    }
}