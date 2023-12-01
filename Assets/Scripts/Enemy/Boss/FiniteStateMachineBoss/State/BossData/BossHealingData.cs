using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newBossHealingData", menuName = "Data/Boss/Boss Healing Data")]
public class BossHealingData : ScriptableObject
{
    public float cooldownTimer = 5f;
    public float amountHealth = 100f;
}
