using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newMeleeAttackData", menuName = "Data/Enemy Data/Melee Attack Data")]
public class EnemyMeleeAttackData : ScriptableObject
{
    public float radiusAttackPoint = 0.2f;
    public float damage = 10f;

    public LayerMask whatIsPlayer;
}
