using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Boss : MonoBehaviour
{

    #region Compnent

    protected BossStateMachine stateMachine;

    [SerializeField] protected BossData data;
    public Animator anim { get; private set; }
    public Rigidbody2D rb { get; private set; }
    #endregion

    #region Check Transform

    [SerializeField] private Transform checkPlayer;
    [SerializeField] private Transform checkLongRangePlayer;

    #endregion

    #region Other Variable
    [SerializeField] private PlayerHealthBar enemyHealthBar;
    [SerializeField] private GameObject particleBlood;
    [SerializeField] private Transform particlePoint;
    [SerializeField] private bool isParticleRandomRotation;
    public AttackDetails attackDetails;

    public GameObject player { get; private set; }
    public PlayerExBar exBar { get; private set; }
    public int facingDir { get; private set; }
    public bool isSkill { get; set; }

    protected int attackDir;
    protected int amountTakeDamageLeft;
    protected float currentHealth;
    protected float startTime;
    public bool isDead { get; private set; }

    protected bool isHurt;

    private Vector2 workSpace;

    #endregion

    #region Unity Call Back Functions
    // Start is called before the first frame update
    protected virtual void Start()
    {
        exBar = GameObject.Find("ExImage").gameObject.GetComponent<PlayerExBar>();
        stateMachine = new BossStateMachine();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        player = GameObject.FindObjectOfType<Player>().gameObject;
        facingDir = 1;
        currentHealth = data.maxHealth;
        amountTakeDamageLeft = data.amountTakeDamage;
        startTime = Time.time;
        isSkill = false;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        stateMachine.currentState.LogicUpdate();
    }

    protected virtual void FixedUpdate()
    {
        stateMachine.currentState.PhysicUpdate();
    }

    #endregion

    #region Set Functions

    public void ResetCooldownTimer(float time)
    {
        startTime = Time.time;
    }

    public void SetKhockback(Vector2 force)
    {
        workSpace.Set(force.x * attackDir,force.y);
        rb.velocity = workSpace;
    }

    public void SetVelocityX(float velocity)
    {
        workSpace.Set(velocity * facingDir, rb.velocity.y);
        rb.velocity = workSpace;
    }

    public void SetVelocityZero()
    {
        rb.velocity = Vector2.zero;
    }

    #endregion

    #region Check Function

    public bool CheckDistance()
    {
        if (player == null)
            return false;
        return (Mathf.Abs(transform.position.x - player.transform.position.x) <= data.distancePlayer ? true : false);
    }

    public bool CheckLongRangePlayer()
    {
        return Physics2D.BoxCast(checkLongRangePlayer.position, data.longRangePlayerDetected, 0, Vector2.right, 0, data.whatIsPlayer);
    }

    public bool CheckPlayerDetected()
    {
        return Physics2D.BoxCast(checkPlayer.position, data.rangePlayerDetected, 0, Vector2.right, 0, data.whatIsPlayer);
    }

    public void CheckIfFlip()
    {
        if (player == null)
            return;
        if (facingDir == 1 && player.transform.position.x <= transform.position.x )
        {
            Flip();
        }
        else if(facingDir == -1 && player.transform.position.x > transform.position.x)
        {
            Flip();
        }
    }

    #endregion

    #region Other Functions

    public void Healing(float health)
    {
        DamagePopupManager.Instance.CreateHealing(transform, "+" + health + "", -(facingDir),new Color(0,1,0,1));
        currentHealth = Mathf.Clamp(currentHealth + health, 0, data.maxHealth);
        enemyHealthBar.UpdateHealth(currentHealth, data.maxHealth);
    }

    public void UpdateHealth()
    {
        enemyHealthBar.UpdateHealth(currentHealth, data.maxHealth);
    }

    public void DestroyGO(float timeDes)
    {
        Destroy(gameObject,timeDes);
    }
    public virtual void Damage(AttackDetails attackDetails)
    {
        isHurt = false;
        amountTakeDamageLeft--;
        currentHealth = Mathf.Clamp(currentHealth - attackDetails.attackDamage, 0, data.maxHealth);
        enemyHealthBar.UpdateHealth(currentHealth, data.maxHealth);
        if(transform.position.x < attackDetails.attackPos.position.x)
        {
            attackDir = -1;
        }
        else
        {
            attackDir = 1;
        }
        if(isParticleRandomRotation)
        {
            Instantiate(particleBlood, particlePoint.position, Quaternion.Euler(0, 0, Random.Range(0,360)));
        }
        else
        {
            if (attackDir == -1)
            {
                Instantiate(particleBlood, particlePoint.position, Quaternion.Euler(0, 180, 0));
            }
            else
            {
                Instantiate(particleBlood, particlePoint.position, Quaternion.identity);
            }
        }
        DamagePopupManager.Instance.Create(transform, attackDetails.attackDamage + "", attackDir);
        if(currentHealth <= 0)
        {
            gameObject.layer = 0;
            exBar.UpdateExBar(data.amountEx);
            isDead = true;
        }
        else if(currentHealth > 0 && amountTakeDamageLeft <= 0)
        {
            amountTakeDamageLeft = data.amountTakeDamage;
            isHurt = true;
        }
    }

    public void Flip()
    {
        facingDir *= -1;
        transform.Rotate(0, 180, 0);
    }

    public void FinishAnimation() => stateMachine.currentState.FinishAnimation();
    public void TriggerAnimation() => stateMachine.currentState.TriggerAnimation();

    public virtual void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(checkPlayer.position, data.rangePlayerDetected);
        Gizmos.DrawWireCube(checkLongRangePlayer.position, data.longRangePlayerDetected);
    }

    #endregion
}
