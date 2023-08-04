using System.Collections.Generic;
using UnityEngine;

namespace Woguelite.Stats
{
    public class PiggleHurtResponse : MonoBehaviour, IHurtResponder
    {
        [SerializeField] private Rigidbody rbPiggle;

        private List<CompHurtBox> hurtboxes = new List<CompHurtBox>();

        private void Start()
        {
            // assign every hurtbox of this character into a list
            hurtboxes = new List<CompHurtBox>(GetComponentsInChildren<CompHurtBox>());
            foreach (CompHurtBox _hurtbox in hurtboxes)
            {
                _hurtbox.HurtResponder = this;
            }
        }

        bool IHurtResponder.CheckHit(HitData data)
        {
            return true;
        }

        void IHurtResponder.Response(HitData data)
        {
            Debug.Log("hurt response");
        }
    }
}