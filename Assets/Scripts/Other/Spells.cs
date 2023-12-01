using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spells : MonoBehaviour
{
    [SerializeField] private Transform attackPoint;
    [SerializeField] private LayerMask whatIsPlayer;
    [SerializeField] private Vector2 size;
    [SerializeField] private Transform spawnPoint;
    private float dir;
    private float damage;
    private GameObject go;
    public AttackDetails attackDetails;

    public void TriggerAnimation()
    {
        RaycastHit2D[] hit = Physics2D.BoxCastAll(attackPoint.position, size, 0, Vector2.right, 0, whatIsPlayer);
        attackDetails.attackPos = transform;
        attackDetails.attackDamage = damage;
        foreach (RaycastHit2D col in hit) 
        {
            if (col)
            {
                col.transform.SendMessage("Damage", attackDetails);
            }
        }
    }

    public void SpawnEnemy()
    {
        if(dir == 1)
        {
            Instantiate(go, spawnPoint.position, Quaternion.identity);
        }
        else
        {
            Instantiate(go, spawnPoint.position, Quaternion.Euler(0,180,0));
        }
    }

    public void CreateSpells(float damage, GameObject go,float dir)
    {
        this.damage = damage;
        this.go = go;
        this.dir = dir;

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(attackPoint.position, size);
    }
}
