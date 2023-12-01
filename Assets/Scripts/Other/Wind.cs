using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Wind : MonoBehaviour
{
    private float damage;
    private Transform takeDamageGO;
    private Rigidbody2D rb;
    private Animator anim;
    private bool isFinishStartup;
    public AttackDetails attackDetails;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        isFinishStartup = false;
        transform.position = takeDamageGO.position;
    }
    private void Update()
    {
        transform.position = takeDamageGO.position;
        if (isFinishStartup)
        {
            anim.SetBool("explode", isFinishStartup);
        }
    }
    public void FinishStartup()
    {
        isFinishStartup = true;
    }
    public void AttackDamageStart()
    {
        if (takeDamageGO.position == null)
            return;
        attackDetails.attackPos = transform;
        attackDetails.attackDamage = (int)damage/2;
        takeDamageGO.SendMessage("Damage", attackDetails);
    }
    public void AttackDamageEnd()
    {
        if (takeDamageGO.position == null)
            return;
        attackDetails.attackPos = transform;
        attackDetails.attackDamage = damage;
        takeDamageGO.SendMessage("Damage", attackDetails);
    }
    
    public void Create(Transform takeDamageGo,float damage)
    {
        this.takeDamageGO = takeDamageGo;
        this.damage = damage;
    }
}
