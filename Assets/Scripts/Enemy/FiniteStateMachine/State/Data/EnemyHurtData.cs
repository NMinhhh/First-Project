using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "newHurtData", menuName = "Data/Enemy Data/Hurt Data")]
public class EnemyHurtData : ScriptableObject
{
    public Vector2 knockBackSpeed;
}
