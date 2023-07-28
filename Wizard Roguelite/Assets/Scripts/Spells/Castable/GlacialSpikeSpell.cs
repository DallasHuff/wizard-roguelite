using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Woguelite.Enums;

namespace Woguelite.Spells
{
    [CreateAssetMenu(menuName = "Spells/GlacialSpike")]
    public class GlacialSpikeSpell : Spell
    {
        [SerializeField] private GameObject glacialSpikeGO;
        public float projectileSpeed;

        public override AbilityState Cast(Transform playerTrans)
        {
            currActiveTime = activeTime;
            return AbilityState.ACTIVE;
        }

        public override AbilityState Act(Transform playerTrans)
        {
            if (currActiveTime <= 0)
            {
                RaycastHit hit;
                var ray = cam.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                {
                    Debug.Log(hit.point);
                    GameObject glacialSpike = Instantiate(glacialSpikeGO, playerTrans.position + new Vector3(0, 2.5f, 0), cam.transform.rotation);
                    glacialSpike.GetComponent<Rigidbody>().velocity = (hit.point - playerTrans.position).normalized * projectileSpeed;
                    currCD = cooldownTime;
                    return AbilityState.COOLDOWN;
                }
            }
            else 
            {
                currActiveTime -= Time.deltaTime;
                Debug.Log("casting");
            }
            // Cast is still active
            return AbilityState.ACTIVE;
        }
    }
}
