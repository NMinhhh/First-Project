using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    
    [SerializeField] private Transform damagePoint;
    [SerializeField] private LayerMask whatIsPlayer;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private float radius; 

    private bool isDamagePlayer;
    private bool isGround;

    private float flyOverTime;
    private float flySpeed;

    private AttackDetails attackDetails;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        attackDetails.attackPos = transform;
        rb.velocity = transform.right * flySpeed;
        isDamagePlayer = false;
        isGround = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDamagePlayer || isGround)
        {
            rb.velocity = Vector2.zero;
            isDamagePlayer = true;
            anim.SetBool("explode", true);
        }
        else if(!isGround)
        {
            attackDetails.attackPos = transform;
            Destroy(gameObject, flyOverTime);
        }
           
    }

    private void FixedUpdate()
    {
        Collider2D ground = Physics2D.OverlapCircle(damagePoint.position, radius, whatIsGround);
        Collider2D player = Physics2D.OverlapCircle(damagePoint.position, radius, whatIsPlayer);
        if(player && !isDamagePlayer)
        {
            rb.gravityScale = 0;
            isDamagePlayer = true;
            player.transform.SendMessage("Damage", attackDetails);
        }else if (ground)
        {
            rb.gravityScale = 0;
            isGround = true;
        }
    }

    public void SetFireBall(float speed,float damage,float time)
    {
        this.flySpeed = speed;
        this.flyOverTime = time;
        attackDetails.attackDamage = damage;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(damagePoint.position, radius);
    }

}
