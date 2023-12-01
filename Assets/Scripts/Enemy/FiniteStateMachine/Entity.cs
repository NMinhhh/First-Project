using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Entity : MonoBehaviour
{
    #region Component

    protected EnemyStateMachine stateMachine;
    public Animator anim { get; private set; }
    public Rigidbody2D rb { get; private set; }

    #endregion

    #region Check Transform

    [SerializeField] private EntityData entityData;
    [SerializeField] private Transform checkLedge;
    [SerializeField] private Transform checkWall;
    [SerializeField] private Transform playerDetected;
    [SerializeField] private Transform closeRangePlayerDetected;
    [SerializeField] private Transform longRangePlayerDetected;
    [SerializeField] private Transform particlePoint;
    #endregion

    #region Variables
    [SerializeField] private GameObject particleBlood;
    [SerializeField] private PhysicsMaterial2D friction;
    [SerializeField] private bool isParticleRandomRotation;
    private PlayerExBar exBar;
    //[SerializeField] private GameObject ParticleChunkBlood;
    private float currentHealth;
    private float maxHealth;
    private float amountEx;
    private Vector2 _workSpace;
    public int facingDir { get; private set; }
    public GameObject Player { get; private set; }
    public AttackDetails attackDetails;
    private int attackDir;
    protected bool isHurt;
    protected bool isDead;
    protected bool isSkill;
    protected float startTime;

    #endregion

    #region Unity Callback Function
    public virtual void Start()
    {
        exBar = GameObject.Find("ExImage").gameObject.GetComponent<PlayerExBar>();
        if (transform.rotation.y == 0)
            facingDir = 1;
        else
            facingDir = -1;
        Player = GameObject.Find("Player").gameObject;
        stateMachine = new EnemyStateMachine();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        currentHealth = Random.Range(entityData.randomMaxHealth.x,entityData.randomMaxHealth.y);
        maxHealth = currentHealth;
        amountEx = Random.Range(entityData.randomEx.x, entityData.randomEx.y);
        isSkill = true;
    }

    public virtual void Update()
    {

        stateMachine.currentState.LogicUpdate();
    }

    public virtual void FixedUpdate()
    {
        stateMachine.currentState.PhysicUpdate();
    }
    #endregion

    #region Set Functions

    public virtual void ResetSkill()
    {
        isSkill = false;
    }

    public virtual void ResetCooldown()
    {
        startTime = Time.time;
    }

    public virtual void SetKnockBack(Vector2 knockBack)
    {
        _workSpace.Set(knockBack.x * attackDir,knockBack.y);
        rb.velocity = _workSpace;
    }

    public virtual void SetVelocityZero()
    {
        rb.velocity = Vector2.zero;
    }
    public virtual void SetVelocityX(float velocity)
    {
        _workSpace.Set(facingDir * velocity, rb.velocity.y);
        rb.velocity = _workSpace;
    }

    #endregion

    #region Check Function

    public virtual void CheckFriction(bool check)
    {
        if (check)
        {
            rb.sharedMaterial = friction;
        }
        else
        {
            rb.sharedMaterial = null;
        }
    }

    public virtual bool CheckSkill()
    {
        return isSkill;
    }

    public virtual bool CheckLongRangePlayerDetected()
    {
        return Physics2D.BoxCast(longRangePlayerDetected.position, entityData.longRangePlayer, 0, Vector2.right, 0, entityData.whatIsPlayer);
    }

    public virtual bool CheckChoseRangePlayerDetected()
    {
        return Physics2D.BoxCast(closeRangePlayerDetected.position, entityData.closeRangePlayer, 0, Vector2.right, 0, entityData.whatIsPlayer);
    }

    public virtual bool CheckPlayerDetected()
    {
        return Physics2D.BoxCast(playerDetected.position, entityData.playerDetected, 0, Vector2.right, 0, entityData.whatIsPlayer);
    }

    public virtual bool CheckLedge()
    {
        return Physics2D.Raycast(checkLedge.position, Vector2.down, entityData.groundDistance, entityData.whatIsGround);
    }

    public virtual bool CheckWall()
    {
        return Physics2D.Raycast(checkWall.position, Vector2.right * facingDir, entityData.wallDistance, entityData.whatIsGround);
    }

    #endregion

    #region Other Function

    public virtual void Dead()
    {
        //Instantiate(ParticleChunkBlood, particlePoint.position, Quaternion.identity);
        Destroy(gameObject);
    }

    public virtual void Dead(float overDeadTime)
    {
        Destroy(gameObject,overDeadTime);
    }

    public virtual void Damage(AttackDetails attackDetails)
    {
        currentHealth = Mathf.Clamp(currentHealth - attackDetails.attackDamage,0, maxHealth);
        if(transform.position.x < attackDetails.attackPos.position.x)
        {
            attackDir = -1;
        }
        else
        {
            attackDir = 1;
        }
        if (isParticleRandomRotation)
        {
            Instantiate(particleBlood, particlePoint.position, Quaternion.Euler(0f, 0f, Random.Range(0,360f)));
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
        DamagePopupManager.Instance.Create(transform, attackDetails.attackDamage + "",attackDir);
        if (currentHealth > 0)
        {
            isHurt = true;
        }
        else
        {
            gameObject.layer = 0;
            isDead = true;
            exBar.UpdateExBar(amountEx);
        }
    }

    public virtual void Flip()
    {
        facingDir *= -1;
        transform.Rotate(0, 180f, 0);
    }

    protected virtual void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(playerDetected.position, entityData.playerDetected);
        Gizmos.DrawWireCube(closeRangePlayerDetected.position, entityData.closeRangePlayer);
        Gizmos.DrawWireCube(longRangePlayerDetected.position, entityData.longRangePlayer);
        Gizmos.DrawLine(checkLedge.position, checkLedge.position + (Vector3)(Vector2.down * entityData.groundDistance));
        Gizmos.DrawLine(checkWall.position, checkWall.position + (Vector3)(Vector2.right * entityData.wallDistance * facingDir));
    }

    public virtual void FinishAnimation() => stateMachine.currentState.FinishAnimation();

    public virtual void TriggerAnimation() => stateMachine.currentState.TriggerAnimation();

    #endregion
}
