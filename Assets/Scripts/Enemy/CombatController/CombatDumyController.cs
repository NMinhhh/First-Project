using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatDumyController : MonoBehaviour
{
    [SerializeField] private Vector2 knockBackSpeed;
    [SerializeField] private float knockBackOver;
    [SerializeField] private GameObject particle;
    [SerializeField] private float maxHealth;
    [SerializeField] private float torqueForce;
    [SerializeField] private Vector2 deadSpeed;
    [SerializeField] private float amountEx;
    [SerializeField] private Vector2 randomCoin;
    private float currentHealth;
    private float startKnockBack;
    private Rigidbody2D rbAlive, rbTop, rbBot;
    private Animator anim;
    private GameObject aliveGO;
    private GameObject bottomGO;
    private GameObject topGO;
    private PlayerExBar exBar;
    private bool knockBack;
    private int playerFacingDir;
    private float attackDir;

    private CapsuleCollider2D col;
    private void Start()
    {
        exBar = GameObject.Find("ExImage").gameObject.GetComponent<PlayerExBar>();
        aliveGO = transform.Find("Alive").gameObject;
        bottomGO = transform.Find("Bottom").gameObject;
        topGO = transform.Find("Top").gameObject;

        rbAlive = GetComponent<Rigidbody2D>();
        rbBot = bottomGO.GetComponent<Rigidbody2D>();
        rbTop = topGO.GetComponent<Rigidbody2D>();
        
        anim = aliveGO.GetComponent<Animator>();
        topGO.SetActive(false);
        bottomGO.SetActive(false);
        currentHealth = maxHealth;

        col = GetComponent<CapsuleCollider2D>();
    }

    private void Update()
    {
        CheckKnockBack();
        
    }

    private void KnockBack()
    {
        knockBack = true;
        startKnockBack = Time.time;
        rbAlive.velocity = new Vector2(knockBackSpeed.x * attackDir, knockBackSpeed.y);
    }

    private void CheckKnockBack()
    {
        if(Time.time >= startKnockBack + knockBackOver && knockBack)
        {
            knockBack = false;
            rbAlive.velocity = new Vector2(0,rbAlive.velocity.y);
        }
    }

    private void Damage(AttackDetails attackDetails)
    {
        currentHealth = Mathf.Clamp(currentHealth - attackDetails.attackDamage, 0, maxHealth);
        Instantiate(particle, transform.position, Quaternion.Euler(0, 0, Random.Range(0, 360)));
        if(transform.position.x < attackDetails.attackPos.position.x)
        {
            attackDir = -1;
        }
        else
        {
            attackDir = 1;
        }
        KnockBack();
        DamagePopupManager.Instance.Create(transform, attackDetails.attackDamage + "", attackDir);
        anim.SetInteger("attackOnLeft", (int)attackDir);
        anim.SetTrigger("damage");
        if(currentHealth <= 0)
        {
            Die();
            Destroy(gameObject, 5);
        }
    }

    private void Die()
    {
        exBar.UpdateExBar(amountEx);
        GameManager.instance.EncreaseCoin((int)Random.Range(randomCoin.x, randomCoin.y));
        col.enabled = false;
        aliveGO.SetActive(false);
        topGO.SetActive(true);
        bottomGO.SetActive(true);
        rbTop.velocity = new Vector2(deadSpeed.x * attackDir, deadSpeed.y);
        rbBot.velocity = new Vector2(knockBackSpeed.x * playerFacingDir, knockBackSpeed.y);
        rbTop.AddTorque(torqueForce, ForceMode2D.Impulse);
    }
}
