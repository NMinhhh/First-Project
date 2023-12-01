using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newRangeAttackData", menuName = "Data/Boss/Boss Range Attack Data")]
public class BossRangeAttackData : ScriptableObject
{
    public GameObject projectile;
    public float damage = 20f;
    public float speed = 3f;
    public float overFlyTime = 5f;
    public float coolDownTimer = 5f;
    public Vector2 randomSpeed;
}
