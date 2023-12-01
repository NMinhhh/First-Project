using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolt : MonoBehaviour
{
    [SerializeField] private Transform attackPoint;
    [SerializeField] private LayerMask whatIsPlayer;
    [SerializeField] private Vector2 size;
    private float damage;
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

    public void TriggerAnimation2()
    {
        RaycastHit2D[] hit = Physics2D.BoxCastAll(attackPoint.position, size, 0, Vector2.right, 0, whatIsPlayer);
        attackDetails.attackPos = transform;
        attackDetails.attackDamage = (int)(damage/2);
        foreach (RaycastHit2D col in hit)
        {
            if (col)
            {
                col.transform.SendMessage("Damage", attackDetails);
            }
        }
    }
    public void CreateSpells(float damage)
    {
        this.damage = damage;

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(attackPoint.position, size);
    }
}
