using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Woguelite.Enums;

public abstract class Spell : ScriptableObject
{

    public new string name;
    public float cooldownTime;
    public float activeTime;
    [SerializeField] private Camera cam;
    [SerializeField] private Transform playerCastTrans;

    public abstract AbilityState Cast();
    public abstract AbilityState Act();
    public abstract AbilityState Cooldown();
}
