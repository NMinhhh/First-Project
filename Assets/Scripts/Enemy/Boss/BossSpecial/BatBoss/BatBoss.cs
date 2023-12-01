using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BatBoss : Boss
{
    public B1_MoveState MoveState { get; private set; }
    public B1_DetectedPlayerState DetectedPlayerState { get; private set; }
    public B1_RangeAttackState RangeAttackState { get; private set; }
    public B1_IdleState IdleState { get; private set; }
    public B1_MeleeAttackState MeleeAttackState { get; private set; }
    public B1_DeathState DeathState { get; private set; }
    public B1_HurtState HurtState { get; private set;}
    public B1_BulletRainSkillState BulletRainSkillState { get; private set; }


    [SerializeField] private BossMoveData moveData;
    [SerializeField] private BossPlayerDetectedData detectedData;
    [SerializeField] private BossRangeAttackData rangeAttackData;
    [SerializeField] private BossMeleeAttackData meleeAttackData;
    [SerializeField] private BossDeathData deathData;
    [SerializeField] private BossHurtData hurtData;
    [SerializeField] private BossBulletRainSkillData bulletRainSkillData;

    [SerializeField] private Transform rangeAttackPoint;
    [SerializeField] private Transform meleeAttackPoint;
    [SerializeField] private GameObject bgSkill;
    public GameObject cam { get; private set; }
    private float healthToSkill;
    protected override void Start()
    {
        base.Start();
        cam = GameObject.Find("Main Camera");
        healthToSkill = currentHealth;
        MoveState = new B1_MoveState(this ,stateMachine, "move", moveData, this);
        DetectedPlayerState = new B1_DetectedPlayerState(this ,stateMachine,"idle",detectedData, this);
        RangeAttackState = new B1_RangeAttackState(this, stateMachine, "rangeAttack", rangeAttackPoint, rangeAttackData, this);
        IdleState = new B1_IdleState(this, stateMachine, "idle", this);
        MeleeAttackState = new B1_MeleeAttackState(this, stateMachine, "meleeAttack", meleeAttackPoint, meleeAttackData, this);
        DeathState = new B1_DeathState(this, stateMachine, "death", deathData, this);
        HurtState = new B1_HurtState(this, stateMachine, "hurt", hurtData, this);
        BulletRainSkillState = new B1_BulletRainSkillState(this, stateMachine, "startSkill", bulletRainSkillData, this, bgSkill);
        stateMachine.Initialize(MoveState);
    }

    protected override void Update()
    {
        base.Update();
        if(player == null)
        {
            stateMachine.ChangeState(IdleState);
        }
        if(Time.time > startTime + bulletRainSkillData.cooldownTimer && player != null && stateMachine.currentState != HurtState && !isSkill && currentHealth <= healthToSkill*2/3)
        {
            isSkill = true;
            gameObject.layer = 0;
        }
        if (bgSkill.activeInHierarchy)
        {
            bgSkill.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y,0);
        }
        
    }

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.DrawWireSphere(meleeAttackPoint.position, meleeAttackData.radius);
    }

    public override void Damage(AttackDetails attackDetails)
    {
        if (stateMachine.currentState == BulletRainSkillState)
            return;
        base.Damage(attackDetails);
        if (isDead)
        {
            stateMachine.ChangeState(DeathState);
        }else if(isHurt & stateMachine.currentState != HurtState)
        {
            stateMachine.ChangeState(HurtState);
        }
    }
}
