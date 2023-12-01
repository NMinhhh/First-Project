using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy5 : Entity
{
    public E5_SleepState SleepState { get; private set; }
    public E5_IdleState IdleState { get; private set; }
    public E5_MoveState MoveState { get; private set; }
    public E5_PlayerDetectedState PlayerDetectedState { get; private set; }
    public E5_ChargeState ChargeState { get; private set; }
    public E5_MeleeAttackState MeleeAttackState { get; private set; }
    public E5_LookForPlayerState LookForPlayerState { get; private set; }
    public E5_HurtState HurtState { get; private set; }
    public E5_DeadState DeadState { get; private set; }

    [SerializeField] private EnemyMoveData moveData;
    [SerializeField] private EnemyIdleData idleData;
    [SerializeField] private EnemyPlayerDetectedData detectedData;
    [SerializeField] private EnemyChargeData chargeData;
    [SerializeField] private EnemyLookForPlayerData lookForPlayerData;
    [SerializeField] private EnemyMeleeAttackData meleeAttackData;
    [SerializeField] private EnemyHurtData hurtData;
    [SerializeField] private EnemyDeadData deadData;

    [SerializeField] private Transform attackPoint;
    public override void Start()
    {
        base.Start();
        SleepState = new E5_SleepState(stateMachine, this, "sleep", this);
        MoveState = new E5_MoveState(stateMachine, this, "move", moveData, this);
        IdleState = new E5_IdleState(stateMachine, this, "idle", idleData, this);
        PlayerDetectedState = new E5_PlayerDetectedState(stateMachine, this, "idle", detectedData, this);
        ChargeState = new E5_ChargeState(stateMachine, this, "move", chargeData, this);
        LookForPlayerState = new E5_LookForPlayerState(stateMachine, this, "idle", lookForPlayerData, this);
        MeleeAttackState = new E5_MeleeAttackState(stateMachine, this, "meleeAttack", attackPoint, meleeAttackData, this);
        HurtState = new E5_HurtState(stateMachine, this, "hurt", hurtData, this);
        DeadState = new E5_DeadState(stateMachine, this, "dead", deadData, this);
        stateMachine.Initialize(SleepState);
    }

    public override void Update()
    {
        base.Update();
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
