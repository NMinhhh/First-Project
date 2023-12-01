using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy4 : Entity
{
    public E4_IdleState IdleState { get; private set; }
    public E4_MoveState MoveState { get; private set; }
    public E4_PlayerDetectedState PlayerDetectedState { get; private set; }
    public E4_ChargeState ChargeState { get; private set; }
    public E4_MeleeAttackState MeleeAttackState { get; private set; }
    public E4_LookForPlayerState LookForPlayerState { get; private set; }
    public E4_BlockState BlockState { get; private set; }
    public E4_HurtState HurtState { get; private set; }
    public E4_DeadState DeadState { get; private set; }

    [SerializeField] private EnemyIdleData idleData;
    [SerializeField] private EnemyMoveData moveData;
    [SerializeField] private EnemyPlayerDetectedData detectedData;
    [SerializeField] private EnemyChargeData chargeData;
    [SerializeField] private EnemyMeleeAttackData meleeAttackData;
    [SerializeField] private EnemyHurtData hurtData;
    [SerializeField] private EnemyLookForPlayerData lookForPlayerData;
    [SerializeField] private EnemyDeadData deadData;
    [SerializeField] private EnemyBlockData blockData;

    [SerializeField] private Transform attackPoint;
    public override void Start()
    {
        base.Start();
        IdleState = new E4_IdleState(stateMachine, this, "idle", idleData, this);
        MoveState = new E4_MoveState(stateMachine, this, "move", moveData, this);
        PlayerDetectedState = new E4_PlayerDetectedState(stateMachine, this, "idle", detectedData, this);
        ChargeState = new E4_ChargeState(stateMachine, this, "move", chargeData, this);
        MeleeAttackState = new E4_MeleeAttackState(stateMachine, this, "meleeAttack", attackPoint, meleeAttackData, this);
        LookForPlayerState = new E4_LookForPlayerState(stateMachine, this, "idle", lookForPlayerData, this);
        BlockState = new E4_BlockState(stateMachine, this, "block", blockData, this);
        HurtState = new E4_HurtState(stateMachine, this, "hurt", hurtData, this);
        DeadState = new E4_DeadState(stateMachine, this, "dead", deadData, this);
        stateMachine.Initialize(MoveState);

    }

    public override void Update()
    {
        base.Update();

        if(Time.time >= startTime + blockData.cooldownBlockTime && stateMachine.currentState != BlockState)
        {
            isSkill = true;
        }

        if (stateMachine.currentState == MoveState || stateMachine.currentState == HurtState || stateMachine.currentState == ChargeState)
        {
            CheckFriction(false);
        }
        else
        {
            CheckFriction(true);
        }
    }
    public override void Damage(AttackDetails attackDetails)
    {
        if(stateMachine.currentState == BlockState)
        {
            return;
        }
        base.Damage(attackDetails);
        if (isDead)
        {
            stateMachine.ChangeState(DeadState);
        }else if(isHurt && stateMachine.currentState != HurtState)
        {
            stateMachine.ChangeState(HurtState);
        }
    }

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.DrawWireSphere(attackPoint.position, meleeAttackData.radiusAttackPoint);
    }
}
