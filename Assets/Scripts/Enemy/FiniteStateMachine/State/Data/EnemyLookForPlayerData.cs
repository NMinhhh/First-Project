using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newLookForPlayerData", menuName = "Data/Enemy Data/Look For Palyer Data")]
public class EnemyLookForPlayerData : ScriptableObject
{
    public int amountOfFlip = 4;
    public float isOverFlip = 0.2f;
}
