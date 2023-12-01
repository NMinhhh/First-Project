using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newDeadData", menuName = "Data/Enemy Data/Dead Data")]
public class EnemyDeadData : ScriptableObject
{
    public float overDeadTime = 1f;
    public Vector2 randomCoin;
}
