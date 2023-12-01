using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "newSpawnData", menuName = "Data/Enemy Data/Spawn Data")]
public class EnemySpawnData : ScriptableObject
{
    public GameObject spawnGO;
    public float cooldownTimer = 5f;
}
