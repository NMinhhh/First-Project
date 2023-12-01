using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newBossSpawnData", menuName = "Data/Boss/Boss Spawn Data")]
public class BossSpawnData : ScriptableObject
{
    public GameObject spawnGO;
    public GameObject[] enemy;
    public float damage = 100f;
    public Vector2 point;
    public float cooldownTimer = 15f;
}
