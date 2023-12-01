using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "weaponData", menuName = "Data/Weapon")]
public class WeaponsData : ScriptableObject
{
    public float levelAttack = 1;
    public float levelDefense = 1;
    public float levelHealth = 1;

    public float amountAttack = 5f;
    public float amountDefense = 6f;
    public float amountHelth = 100f;

    public float indexDamage = 3f;
    public float indexDefense = 3f;
    public float indexHealth = 50f;

    public float priceDamage = 100f;
    public float priceDefense = 100f;
    public float priceHealth = 100f;
}
