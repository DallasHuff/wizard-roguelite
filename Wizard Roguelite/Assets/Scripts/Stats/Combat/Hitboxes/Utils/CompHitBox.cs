using UnityEngine;
using Woguelite.Enums;

namespace Woguelite.Stats
{
    public class CompHitBox : MonoBehaviour, IHitDetector
    {
        [SerializeField] private BoxCollider boxCollider;
        [SerializeField] private LayerMask layerMask;
        [SerializeField] private HurtboxMask hurtboxMask = HurtboxMask.Enemy;

        private float thickness = 0.025f;
        private IHitResponder hitResponder;

        public IHitResponder HitResponder { get { return hitResponder; }  set => hitResponder = value; }

        public void CheckHit()
        {
            Vector3 scaledSize = new Vector3(
                boxCollider.size.x * transform.lossyScale.x,
                boxCollider.size.y * transform.lossyScale.y,
                boxCollider.size.z * transform.lossyScale.z);

            float distance = scaledSize.y - thickness;
            Vector3 direction = transform.up;
            Vector3 center = transform.TransformPoint(boxCollider.center);
            Vector3 start = center - direction * (distance / 2);
            Vector3 halfExtents = new Vector3(scaledSize.x, thickness, scaledSize.z) / 2;
            Quaternion orientation = transform.rotation;

            HitData hitData = null;
            IHurtBox hurtBox = null;
            RaycastHit[] hits = Physics.BoxCastAll(start, halfExtents, direction, orientation, distance, layerMask);
            foreach (RaycastHit hit in hits)
            {
                hurtBox = hit.collider.GetComponent<IHurtBox>();
                if (hurtBox != null)
                {
                    if (hurtBox.Active)
                    {
                        if (hurtboxMask.HasFlag((HurtboxMask)hurtBox.Type))
                        {
                            // Generate HitData
                            hitData = new HitData
                            {
                                damage = hitResponder == null ? 0 : hitResponder.damage,
                                hitPoint = hit.point == Vector3.zero ? center : hit.point,
                                hitNormal = hit.normal,
                                hurtBox = hurtBox,
                                hitDetector = this
                            };

                            // Validate and Response
                            if (hitData.Validate())
                            {
                                hitData.hitDetector.HitResponder?.Response(hitData);
                                hitData.hurtBox.HurtResponder?.Response(hitData);
                            }
                        }
                    }
                }
            }
        }
    }
}