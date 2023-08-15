using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Woguelite.Stats
{
    public class HitResponse : MonoBehaviour, IHitResponder
    {
        [SerializeField] private bool attack;
        [SerializeField] private int damage;
        [SerializeField] private CompHitBox _hitbox;
        
        int IHitResponder.Damage { get { return damage; } }
        void Start()
        {
            _hitbox.HitResponder = this;
        }

        // Update is called once per frame
        void Update()
        {
            if (attack)
            {
                _hitbox.CheckHit();
            }
        }

        bool IHitResponder.CheckHit(HitData data)
        {
            return true;
        }

        void IHitResponder.Response(HitData data)
        {

        }
    }
}