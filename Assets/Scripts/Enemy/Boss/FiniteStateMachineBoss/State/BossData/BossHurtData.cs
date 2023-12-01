using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newBossHurtData", menuName = "Data/Boss/Boss Hurt Data")]
public class BossHurtData : ScriptableObject
{
    public Vector2 knockback;
}
