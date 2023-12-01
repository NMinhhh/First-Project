using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : Entity
{
    public E1_MoveState MoveState { get; private set; }
    public E1_IdleState IdleState { get; private set; }
    public E1_PlayerDetectedState PlayerDetectedState { get; private set; }
    public E1_ChargeState ChargeState { get; private set; }
    public E1_LookForPlayerState LookForPlayerState { get; private set; }
    public E1_MeleeAttackState MeleeAttackState { get; private set; }
    public E1_HurtState HurtState { get; private set;}
    public E1_DeadState DeadState { get; private set; }

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
        MoveState = new E1_MoveState(stateMachine, this, "move", moveData, this);
        IdleState = new E1_IdleState(stateMachine, this, "idle", idleData, this);
        PlayerDetectedState = new E1_PlayerDetectedState(stateMachine, this, "idle", detectedData, this);
        ChargeState = new E1_ChargeState(stateMachine, this, "move",chargeData, this);
        LookForPlayerState = new E1_LookForPlayerState(stateMachine, this, "idle", lookForPlayerData, this);
        MeleeAttackState = new E1_MeleeAttackState(stateMachine, this, "meleeAttack", attackPoint, meleeAttackData, this);
        HurtState = new E1_HurtState(stateMachine, this,"hurt",hurtData,this);
        DeadState = new E1_DeadState(stateMachine, this, "dead",deadData, this);
        stateMachine.Initialize(MoveState);
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

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.DrawWireSphere(attackPoint.position, meleeAttackData.radiusAttackPoint);
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
}
