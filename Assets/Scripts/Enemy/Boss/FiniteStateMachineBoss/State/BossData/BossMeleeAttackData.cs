using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newBossMeleeAttackData", menuName = "Data/Boss/Boss Melee Attack Data")]
public class BossMeleeAttackData : ScriptableObject
{
    public float damage = 20f;
    public float radius = 0.3f;
    public LayerMask whatIsPlayer;
}
