using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

using Woguelite.Enums;

public class Spell : ScriptableObject
{
    public string spellName;
    public string description;
    public float cooldownTime;
    public float activeTime;

    public virtual AbilityState Cast(Transform playerTrans) { return AbilityState.READY; }

    public virtual AbilityState Act(Transform playerTrans) { return AbilityState.READY; }

    public virtual AbilityState Cooldown(Transform playerTrans) { return AbilityState.READY; }
}
