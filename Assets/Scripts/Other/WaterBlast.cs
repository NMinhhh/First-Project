using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBlast : MonoBehaviour
{
    private float speed;
    private float damage;
    private float overTimeLife;
    [SerializeField] private float cooldownTimer;
    [SerializeField] private LayerMask whatIsEnemy;
    [SerializeField] private BoxCollider2D boxCollider;
    private float timer;
    private float leftTimeLife;
    public AttackDetails attackDetails;
    private Rigidbody2D rb;
    private Animator anim;
    private bool isFinishStartup;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        leftTimeLife = overTimeLife;
        isFinishStartup = false;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isFinishStartup)
            return;
        if(leftTimeLife <= 0)
        {
            rb.velocity = Vector2.zero;
            anim.SetBool("explode", true);
        }
        else
        {
            rb.velocity = transform.right * speed;
            leftTimeLife -= Time.deltaTime;
        }
        TakeDamage();
    }
    public void FinishStartup()
    {
        isFinishStartup = true;
    }
    private void TakeDamage()
    {
        timer -= Time.deltaTime;
        RaycastHit2D[] hit = Physics2D.BoxCastAll(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.right, 0, whatIsEnemy);
        attackDetails.attackPos = transform;
        attackDetails.attackDamage = damage;
        foreach (RaycastHit2D col in hit)
        {
            if (col && timer <= 0)
            {
                timer = cooldownTimer;
                col.transform.SendMessage("Damage", attackDetails);
            }
        }
    }
    public void Create(float speed, float damage, float overTimeLife)
    {
        this.speed = speed;
        this.damage = damage;
        this.overTimeLife = overTimeLife;
    }
}
