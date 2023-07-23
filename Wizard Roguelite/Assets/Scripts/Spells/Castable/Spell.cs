using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

using Woguelite.Enums;

public class Spell : MonoBehaviour
{
    public new string name;
    public float cooldownTime;
    public float activeTime;
    [SerializeField] private Camera cam;
    [SerializeField] private Transform playerCastTrans;

    public virtual AbilityState Cast() { return AbilityState.READY; }

    public virtual AbilityState Act() { return AbilityState.READY; }

    public virtual AbilityState Cooldown() { return AbilityState.READY; }
}
