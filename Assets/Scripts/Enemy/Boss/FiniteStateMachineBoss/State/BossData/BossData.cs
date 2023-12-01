using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "newBossData",menuName = "Data/Base Data/Boss Data")]
public class BossData : ScriptableObject
{
    public Vector2 rangePlayerDetected;
    public Vector2 longRangePlayerDetected;

    public float maxHealth = 300f;
    public float distancePlayer = 2f;
    public int amountTakeDamage = 3;
    public float amountEx = 100f;

    public LayerMask whatIsPlayer;

}
