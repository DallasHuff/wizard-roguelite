using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Woguelite.Enums;

namespace Woguelite.Spells
{
    [CreateAssetMenu(menuName = "Spells/Fireball")]
    public class FireballSpell : Spell
    {
        [SerializeField] private GameObject fireballGO;
        public float projectileSpeed;

        public override AbilityState Cast(Transform playerTrans)
        {
            //  TODO: add a gameobject to player prefab to cast from to prevent the fireball from crashing into player and remove the hardcode vector3 addition
            RaycastHit hit;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.point);
                GameObject fireball = Instantiate(fireballGO, playerTrans.position + new Vector3(0, 2.5f, 0), playerTrans.rotation);
                fireball.GetComponent<Rigidbody>().velocity = (hit.point - playerTrans.position).normalized * projectileSpeed;
                return AbilityState.COOLDOWN;

            }
            return AbilityState.READY;
        }
        
        public override AbilityState Act(Transform playerTrans)
        {
            return AbilityState.COOLDOWN;
        }

        public override AbilityState Cooldown(Transform playerTrans)
        {
            if (cooldownTime > 0)
            {
                cooldownTime -= Time.deltaTime;
                return AbilityState.COOLDOWN;
            }
            else
            {
                return AbilityState.READY;
            }
        }
    }
}
