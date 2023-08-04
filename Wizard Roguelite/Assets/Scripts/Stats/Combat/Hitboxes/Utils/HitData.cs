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
                    if (hurtBox.HurtResponder == null || hurtBox.HurtResponder.CheckHit(this))
                    {
                        if (hitDetector.HitResponder == null || hitDetector.HitResponder.CheckHit(this))
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