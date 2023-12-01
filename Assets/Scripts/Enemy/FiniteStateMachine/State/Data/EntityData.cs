using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newEntityData", menuName = "Data/Base Data/Entity Data")]
public class EntityData : ScriptableObject
{
    public float groundDistance = 0.2f;
    public float wallDistance = 0.2f;
    public Vector2 randomMaxHealth;
   
    public Vector2 closeRangePlayer;
    public Vector2 longRangePlayer;
    public Vector2 playerDetected;

    public LayerMask whatIsPlayer;
    public LayerMask whatIsGround;

    public Vector2 randomEx;
}
