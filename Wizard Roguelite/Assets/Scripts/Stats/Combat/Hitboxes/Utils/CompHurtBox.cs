using UnityEngine;
using Woguelite.Enums;

namespace Woguelite.Stats
{
    public class CompHurtBox : MonoBehaviour, IHurtBox
    {
        [SerializeField] private bool active = true;
        [SerializeField] private GameObject owner = null;
        [SerializeField] private HurtboxType hurtboxType = HurtboxType.Enemy;
        private IHurtResponder hurtResponder;
        public bool Active { get { return active; } set { active = value; } }
        public GameObject Owner { get { return owner; } }
        public Transform Transform { get { return transform; } }
        public HurtboxType Type { get { return hurtboxType; } }
        public IHurtResponder HurtResponder { get { return hurtResponder; } set => hurtResponder = value; }

        public bool CheckHit(HitData hitData)
        {
            if (hurtResponder == null) { Debug.Log("No responder for " + transform.name); }
            return true;
        }

    }
}