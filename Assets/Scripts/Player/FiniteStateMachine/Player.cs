using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region State Variables
    public StateMachine StateMachine { get; private set; }
    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    public PlayerJumpState JumpState { get; private set; }
    public PlayerAttackState AttackState { get; private set; }
    public PlayerInAirState InAirState { get; private set; }
    public PlayerDashState DashState { get; private set; }
    public PlayerHeavyAttackState HeavyAttackState { get; private set; }
    public PlayerHurtState HurtState { get; private set; }
    public PlayerDeadState DeadState { get; private set; }
    public PlayerJumpAttackState JumpAttackState { get; private set; }
    public PlayerWaterBlastSkillState WaterBlastSkillState { get; private set; }
    public PlayerWindSkillState WindSkillState { get; private set; }

    #endregion

    #region Components
    public Animator Anim { get; private set; }

    public Animator smokeAnim { get; private set; }

    private Animator levelUpAnim;
    public Rigidbody2D _rb { get; private set; }

    private TrailRenderer _trailRenderer;
    #endregion

    #region Check Transform

    [SerializeField] private PlayerData _playerData;
    [SerializeField] private WeaponsData _weaponData;

    [SerializeField] private Transform checkGround;

    [SerializeField] private Transform attackPoint;

    [SerializeField] private Transform dashPoint;

    [SerializeField] private Transform heavyAttackPoint;
    [SerializeField] private Transform heavyAttackEffectPoint;

    [SerializeField] private Transform particleBloodPoint;

    [SerializeField] private Transform jumpAttackPoint;

    [SerializeField] private Transform waterBlastPoint;
    [SerializeField] private Transform checkEnemyToWindSkill;

    #endregion

    #region Other Variables

    [SerializeField] private GameObject particleBlood;
    [SerializeField] private PlayerHealthBar playerHealthBar;
    [SerializeField] private SkillCooldownManager skill1;
    [SerializeField] private SkillCooldownManager skill2;
    [SerializeField] private SkillCooldownManager skill3;
    [SerializeField] private SkillCooldownManager dash;
    [SerializeField] private PhysicsMaterial2D noFriction;
    [SerializeField] private PhysicsMaterial2D Friction;

    public bool isFacingRight { get; private set; }
    private int facingDir;
    private Vector2 _workSpace;
    public Vector2 CurrentVelocity { get; private set; }
    public int LeftAmountOfJump { get; private set; }
    public int AmountOfAttack { get; private set; }
    public int AmountOfJumpAttack { get; private set; }

    private float startTimeAttack;
    public bool isDashing { get; private set; }

    private float currentHealth;

    private float attackDir;

    private bool isHurt;
    private bool isDead;
    private bool isLevelUp;
    private float levelUpTime;

    public float currentGravity { get; private set; }

    public AttackDetails attackDetails;

    #endregion

    #region Unity CallBack Function

    private void Awake()
    {
        StateMachine = new StateMachine();
        IdleState = new PlayerIdleState(this, StateMachine, _playerData, "idle");
        MoveState = new PlayerMoveState(this, StateMachine, _playerData, "move");
        JumpState = new PlayerJumpState(this, StateMachine, _playerData, "jump");
        AttackState = new PlayerAttackState(this, StateMachine, _playerData, "attack", attackPoint);
        InAirState = new PlayerInAirState(this, StateMachine, _playerData, "jump");
        DashState = new PlayerDashState(this, StateMachine, _playerData, "dash", dash);
        HeavyAttackState = new PlayerHeavyAttackState(this, StateMachine, _playerData, "heavyAttack", heavyAttackPoint, heavyAttackEffectPoint, skill1);
        HurtState = new PlayerHurtState(this, StateMachine, _playerData, "hurt");
        DeadState = new PlayerDeadState(this, StateMachine, _playerData, "dead");
        JumpAttackState = new PlayerJumpAttackState(this, StateMachine, _playerData, "jumpAttack", jumpAttackPoint);
        WindSkillState = new PlayerWindSkillState(this, StateMachine, _playerData, "windSkill",checkEnemyToWindSkill, skill2);
        WaterBlastSkillState = new PlayerWaterBlastSkillState(this, StateMachine, _playerData, "waterBlastSkill", waterBlastPoint, skill3);
    }

    void Start()
    {
        Anim = GetComponent<Animator>();
        smokeAnim = transform.Find("SmokeEffect").GetComponent<Animator>();
        levelUpAnim = transform.Find("LevelUpEffect").GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        _trailRenderer = dashPoint.GetComponent<TrailRenderer>();
        StateMachine.Initilize(IdleState);
        isFacingRight = true;
        facingDir = 1;
        AmountOfAttack = 0;
        AmountOfJumpAttack= 0;
        LeftAmountOfJump = _playerData.amountOfJump;
        currentHealth = AmoutHealth();
        currentGravity = _rb.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        StateMachine.CurrentState.LogicUpdate();
        Anim.SetFloat("velocityY", _rb.velocity.y);
        CurrentVelocity = _rb.velocity;
        SetAttackCounter();
        if(StateMachine.CurrentState == MoveState || StateMachine.CurrentState == DashState || StateMachine.CurrentState == HurtState || StateMachine.CurrentState == JumpState || StateMachine.CurrentState == InAirState)
        {
            _rb.sharedMaterial = noFriction;
        }
        else
        {
            _rb.sharedMaterial = Friction;
        }

        if (isLevelUp)
        {
            levelUpTime -= Time.deltaTime;
            if(levelUpTime <= 0) 
            {
                levelUpAnim.SetBool("levelUp", false);
                isLevelUp = false;
            }
        }
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicUpdate();
    }

    #endregion

    #region Set Functions

    public void SetGravityScale(float gravityScale)
    {
        _rb.gravityScale = gravityScale;
    }

    public void SetKnockBack(Vector2 knockBackSpeed)
    {
        _workSpace.Set(knockBackSpeed.x * attackDir,knockBackSpeed.y);
        _rb.velocity = _workSpace;
    }

    public void SetVelocityX(float velocityX)
    {
        _workSpace.Set(velocityX, _rb.velocity.y);
        _rb.velocity = _workSpace;
    }

    public void SetAmountOfJumpAttack()
    {
        AmountOfJumpAttack = 0;
    }

    public void SetAmountOfAttack()
    {
        AmountOfAttack = 0;
    }

    public void SetAmountOfJump()
    {
        LeftAmountOfJump = _playerData.amountOfJump;
    }
    public void SetVelocityY(float velocityY)
    {
        _workSpace.Set(_rb.velocity.x, velocityY);
        _rb.velocity = _workSpace;
    }

    public void SetVelocityZero()
    {
        _rb.velocity = Vector2.zero;
    }

    private void SetAttackCounter()
    {
        if (AmountOfAttack != 0 && Time.time > startTimeAttack + _playerData.resetAttackTime)
        {
            AmountOfAttack = 0;
        }
    }
    #endregion

    #region Check Functions
    public void CheckIfFlip(float xInput)
    {
        if (isFacingRight && xInput < 0)
        {
            Flip();
        }
        else if (!isFacingRight && xInput > 0)
        {
            Flip();
        }
    }
    public bool CheckGrounded()
    {
        return Physics2D.OverlapCircle(checkGround.position, _playerData.radius, _playerData.whatIsGround);
    }


    #endregion

    #region Other Functions

    public float WeaponDamage()
    {
        return _weaponData.amountAttack;
    }

    public float AmountDamage()
    {
        return _playerData.attackDamage + _weaponData.amountAttack;
    }

    public float AmountDefense()
    {
        return (_playerData.defense + _weaponData.amountDefense)*.3f;
    }

    public float AmoutHealth()
    {
        return _playerData.maxHealth + _weaponData.amountHelth;
    }

    public void LevelUp()
    {
        levelUpTime = 1;
        isLevelUp = true;
        levelUpAnim.SetBool("levelUp",isLevelUp);
        SoundFXManager.Instance.CreateAudio(_playerData.audioClips[7], transform, 1);
        currentHealth = AmoutHealth();
        playerHealthBar.UpdateHealth(currentHealth, AmoutHealth());
    }

    public void ComboJumpAttack()
    {
        AmountOfJumpAttack += 1;
    }

    public void Dead(float overTimeDead)
    {
        Destroy(gameObject,overTimeDead);
    }
    public int GetFacingDir()
    {
        return facingDir;
    }

    public bool Immortal()
    {
        if(StateMachine.CurrentState == DashState || StateMachine.CurrentState == HeavyAttackState || StateMachine.CurrentState == WaterBlastSkillState || StateMachine.CurrentState == WindSkillState)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Damage(AttackDetails attackDetails)
    {
        if (Immortal())
            return;
        int damage = (attackDetails.attackDamage - AmountDefense() > 0? (int)(attackDetails.attackDamage - AmountDefense()) : 1);

        currentHealth = Mathf.Clamp(currentHealth - damage, 0, AmoutHealth());
        playerHealthBar.UpdateHealth(currentHealth, AmoutHealth());
        if(transform.position.x < attackDetails.attackPos.position.x)
        {
            Instantiate(particleBlood, particleBloodPoint.position, Quaternion.Euler(0, 180, 0));
            attackDir = -1;
        }
        else
        {
            Instantiate(particleBlood, particleBloodPoint.position, Quaternion.identity);
            attackDir = 1;
        }
        DamagePopupManager.Instance.Create(transform, damage + "", attackDir);
        if(currentHealth > 0)
        {
            isHurt = true;
        }
        else if(currentHealth <= 0)
        {
            isDead = true;
            gameObject.layer = 0;
        }
        if (isDead)
        {
            StateMachine.ChangeState(DeadState);
        }
        else if(isHurt && StateMachine.CurrentState != HurtState)
        {
            StateMachine.ChangeState(HurtState);
        }
    }

    public void IsDashing()
    {
        isDashing = true;
    }

    public void Dash(float dashTime, float dashSpeed)
    {
        StartCoroutine(Dashing(dashTime,dashSpeed));
    }

    public IEnumerator Dashing(float dashTime, float dashSpeed)
    {
        _trailRenderer.emitting = true;
        _workSpace.Set(facingDir * dashSpeed, 0);
        _rb.velocity = _workSpace;
        yield return new WaitForSeconds(dashTime);
        _trailRenderer.emitting = false;
        isDashing = false;
    }

    public void ComboAttack()
    {
        AmountOfAttack += 1;
        startTimeAttack = Time.time;
    }

    public void DeCreaseAmountOfJump()
    {
        LeftAmountOfJump -= 1;
    }



    private void Flip()
    {
        transform.Rotate(0, 180, 0);
        isFacingRight = !isFacingRight;
        facingDir *= -1;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(checkGround.position, _playerData.radius);
        //Gizmos.DrawWireCube(attackPoint.position, _playerData.attackSize);
        //Gizmos.DrawWireSphere(attackPoint.position, _playerData.attackRadius);
        //Gizmos.DrawWireSphere(heavyAttackPoint.position, _playerData.heavyAttackRadius);
        //Gizmos.DrawWireCube(jumpAttackPoint.position, _playerData.jumpAttackSize);
        Gizmos.DrawWireCube(checkEnemyToWindSkill.position, _playerData.checkSize);
        //Gizmos.DrawWireSphere(jumpAttackPoint.position, _playerData.jumpAttackRad);
    }

    public void FinishAnimation() => StateMachine.CurrentState.FinishAnimation();
    public void TriggerAnimation() => StateMachine.CurrentState.TriggerAnimation();

    #endregion
}
