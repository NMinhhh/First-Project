using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newBossDeathData", menuName = "Data/Boss/Boss Death Data")]
public class BossDeathData : ScriptableObject
{
    public Vector2 knockbackForce;
    public float timeDes = 1f;
    public float coin;
}
