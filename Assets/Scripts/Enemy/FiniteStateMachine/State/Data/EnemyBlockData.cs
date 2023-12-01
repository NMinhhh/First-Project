using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newBlockData", menuName = "Data/Enemy Data/Block Data")]
public class EnemyBlockData : ScriptableObject
{
    public float blockTimer = 1f;
    public float cooldownBlockTime = 3f;
}
