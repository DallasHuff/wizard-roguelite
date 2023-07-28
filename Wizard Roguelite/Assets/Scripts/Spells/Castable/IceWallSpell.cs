using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Woguelite.Enums;

namespace Woguelite.Spells
{
    [CreateAssetMenu(menuName = "Spells/IceWall")]
    public class IceWallSpell : Spell
    {
        [SerializeField] private GameObject iceWallGO;

        public override AbilityState Cast(Transform playerTrans)
        {
            RaycastHit hit;
            var ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                GameObject iceWall = Instantiate(iceWallGO, hit.point, Quaternion.Euler(0,cam.transform.rotation.eulerAngles.y, 0));
                currCD = cooldownTime;
                return AbilityState.COOLDOWN;
            }
            // Raycast didn't hit, so we did not cast. Do not go on CD
            return AbilityState.READY;
        }
    }
}