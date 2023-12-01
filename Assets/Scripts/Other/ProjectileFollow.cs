using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileFollow : MonoBehaviour
{
    [SerializeField] private Transform attackPoint;
    [SerializeField] private LayerMask whatIsPlayer;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private float radius = 0.2f;
    private Transform player;
    private Rigidbody2D rb;
    private Animator anim;
    private float speed;
    private float overFly;
    private bool isDamage;
    private bool isGround;

    public AttackDetails attackDetails;

    private void Start()
    {
        player = GameObject.Find("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        attackDetails.attackPos = transform;
        rb.velocity = GetDir() * speed;
    }

    private void Update()
    {
      
        if(isDamage || isGround)
        {
            isDamage = true;
            anim.SetBool("explode", true);
        }else if (!isGround)
        {
            attackDetails.attackPos = transform;
            Destroy(gameObject, overFly);
        }
    }

    private void FixedUpdate()
    {
        Collider2D player = Physics2D.OverlapCircle(attackPoint.position, radius, whatIsPlayer);
        Collider2D ground = Physics2D.OverlapCircle(attackPoint.position, radius, whatIsGround);
        if(player && !isDamage)
        {
            rb.velocity = Vector2.zero;
            isDamage = true;
            player.transform.SendMessage("Damage", attackDetails);
        }else if (ground)
        {
            rb.velocity = Vector2.zero;
            isGround = true;
        }

    }

    public Vector2 GetDir()
    {
        return (player.position - transform.position).normalized;
    }

    public void Create(float speed, float damage, float overFly)
    {
        this.speed = speed;
        this.overFly = overFly;
        attackDetails.attackDamage = damage;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPoint.position, radius);
    }
}
