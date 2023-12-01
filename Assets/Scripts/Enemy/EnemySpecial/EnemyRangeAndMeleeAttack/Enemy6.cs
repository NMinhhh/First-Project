using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy6 : Entity
{
    public E6_MoveState MoveState { get; private set; }
    public E6_IdleState IdleState { get; private set; }
    public E6_PlayerDetectedState PlayerDetectedState { get; private set; }
    public E6_ChargeState ChargeState { get; private set; }
    public E6_LookForPlayerState LookForPlayerState { get; private set; }
    public E6_MeleeAttackState MeleeAttackState { get; private set; }
    public E6_RangeAttackState RangeAttackState { get; private set; }
    public E6_HurtState HurtState { get; private set; }
    public E6_DeadState DeadState { get; private set; }

    [SerializeField] private EnemyMoveData moveData;
    [SerializeField] private EnemyIdleData idleData;
    [SerializeField] private EnemyPlayerDetectedData detectedData;
    [SerializeField] private EnemyChargeData chargeData;
    [SerializeField] private EnemyLookForPlayerData lookForPlayerData;
    [SerializeField] private EnemyMeleeAttackData meleeAttackData;
    [SerializeField] private EnemyRangeAttackData rangeAttackData;
    [SerializeField] private EnemyHurtData hurtData;
    [SerializeField] private EnemyDeadData deadData;

    [SerializeField] private Transform attackPoint;
    [SerializeField] private Transform rangeAttackPoint;
    public override void Start()
    {
        base.Start();
        MoveState = new E6_MoveState(stateMachine, this, "move", moveData, this);
        IdleState = new E6_IdleState(stateMachine, this, "idle", idleData, this);
        PlayerDetectedState = new E6_PlayerDetectedState(stateMachine, this, "idle", detectedData, this);
        ChargeState = new E6_ChargeState(stateMachine, this, "move", chargeData, this);
        LookForPlayerState = new E6_LookForPlayerState(stateMachine, this, "idle", lookForPlayerData, this);
        MeleeAttackState = new E6_MeleeAttackState(stateMachine, this, "meleeAttack", attackPoint, meleeAttackData, this);
        RangeAttackState = new E6_RangeAttackState(stateMachine, this, "rangeAttack", rangeAttackPoint, rangeAttackData, this);
        HurtState = new E6_HurtState(stateMachine, this, "hurt", hurtData, this);
        DeadState = new E6_DeadState(stateMachine, this, "dead", deadData, this);
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
