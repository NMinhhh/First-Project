using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Golem : Boss
{
    public B5_MoveState MoveState { get; private set; }
    public B5_IdleState IdleState { get; private set; }
    public B5_PlayerDetectedState PlayerDetectedState { get; private set; }
    public B5_MeleeAttackState MeleeAttackState { get; private set; }
    public B5_HurtState HurtState { get; private set; }
    public B5_DeadState DeadState { get; private set; }
    public B5_BulletSkillState BulletSkillState { get; private set;}

    [SerializeField] private BossMoveData moveData;
    [SerializeField] private BossPlayerDetectedData detectedData;
    [SerializeField] private BossMeleeAttackData meleeAttackData;
    [SerializeField] private BossHurtData hurtData;
    [SerializeField] private BossDeathData deathData;
    [SerializeField] private BossRangeAttackData rangeAttackData;

    [SerializeField] private Transform attackPoint;
    [SerializeField] private Transform rangeAttackPoint;
    [SerializeField] private GameObject boss2;
    public Transform cam { get; private set; }
    protected override void Start()
    {
        base.Start();
        MoveState = new B5_MoveState(this, stateMachine, "move", moveData, this);
        IdleState = new B5_IdleState(this, stateMachine, "idle", this);
        PlayerDetectedState = new B5_PlayerDetectedState(this, stateMachine, "idle", detectedData, this);
        MeleeAttackState = new B5_MeleeAttackState(this, stateMachine, "meleeAttack", attackPoint, meleeAttackData, this);
        BulletSkillState = new B5_BulletSkillState(this, stateMachine, "shoot", rangeAttackPoint, rangeAttackData, this);
        HurtState = new B5_HurtState(this, stateMachine, "hurt", hurtData, this);
        DeadState = new B5_DeadState(this, stateMachine, "dead", deathData, this);
        stateMachine.Initialize(MoveState);
        cam = GameObject.Find("Main Camera").transform;

    }

    protected override void Update()
    {
        base.Update();
        if (player == null)
        {
            stateMachine.ChangeState(IdleState);
        }
        if(Time.time >= startTime + rangeAttackData.coolDownTimer && !isSkill)
        {
            isSkill = true;
        }
        
    }
    public override void Damage(AttackDetails attackDetails)
    {
        base.Damage(attackDetails);
        if (isDead)
        {
            stateMachine.ChangeState(DeadState);
        }
        else if (isHurt && stateMachine.currentState != HurtState)
        {
            stateMachine.ChangeState(HurtState);
        }
    }

    public void CreateBoss2()
    {
        boss2.transform.position = transform.position;
        boss2.SetActive(true);
    }

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.DrawWireSphere(attackPoint.position, meleeAttackData.radius);
    }
}
