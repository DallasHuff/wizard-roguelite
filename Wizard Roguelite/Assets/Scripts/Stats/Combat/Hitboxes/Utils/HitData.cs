using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Woguelite.Stats
{
    public class HitData
    {
        public int damage;
        public Vector3 hitPoint;
        public Vector3 hitNormal;
        public IHurtBox hurtBox;
        public IHitDetector hitDetector;

        public bool Validate()
        {
            if (hurtBox != null)
            {
                if (hurtBox.CheckHit(this))
                {
                    if (hurtBox.hurtResponder == null || hurtBox.hurtResponder.CheckHit(this))
                    {
                        if (hitDetector.hitResponder == null || hitDetector.hitResponder.CheckHit(this))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}