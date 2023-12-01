using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newRangeAttackData", menuName = "Data/Enemy Data/Range Attack Data")]
public class EnemyRangeAttackData : ScriptableObject
{
    public GameObject fireBall;
    public float damage = 10f;

    public float overFlyTime = 1f;
    public float speed = 5f;
}
