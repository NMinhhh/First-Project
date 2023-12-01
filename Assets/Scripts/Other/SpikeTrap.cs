using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    [SerializeField] private Transform takeDamagePoint;
    [SerializeField] private Vector2 sizeTrap;
    [SerializeField] private LayerMask whatIsPlayer;
    [SerializeField] private float coolDownTimer;
    [SerializeField] private float damage;
    private float startTime;
    public AttackDetails attackDetails;
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        TakeDamage();
    }

    private void TakeDamage()
    {
        RaycastHit2D[] hit = Physics2D.BoxCastAll(takeDamagePoint.position, sizeTrap, 0, transform.right, 0, whatIsPlayer);
        attackDetails.attackPos = transform;
        attackDetails.attackDamage = damage;
        foreach(RaycastHit2D col in hit)
        {
            if(col && Time.time >= startTime + coolDownTimer)
            {
                startTime = Time.time;
                col.transform.SendMessage("Damage", attackDetails);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, sizeTrap);
    }
}
