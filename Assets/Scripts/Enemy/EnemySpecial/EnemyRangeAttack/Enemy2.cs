using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : Entity
{
    
    public E2_IdleState IdleState { get; private set; }
    public E2_MoveState MoveState { get; private set; }
    public E2_PlayerDetected PlayerDetected { get; private set; }
    public E2_LookForPlayer LookForPlayer { get; private set; }
    public E2_ChargeState ChargeState { get; private set; }
    public E2_RangeAttackState RangeAttackState { get; private set; }
    public E2_HurtState HurtState { get; private set; }
    public E2_DeadState DeadState { get; private set; }

    [SerializeField] private EnemyIdleData idleData;
    [SerializeField] private EnemyMoveData moveData;
    [SerializeField] private EnemyPlayerDetectedData playerDetectedData;
    [SerializeField] private EnemyLookForPlayerData lookForPlayerData;
    [SerializeField] private EnemyChargeData chargeData;
    [SerializeField] private EnemyRangeAttackData rangeAttackData;
    [SerializeField] private EnemyHurtData hurtData;
    [SerializeField] private EnemyDeadData deadData;

    [SerializeField] private Transform attackPoint;
    public override void Start()
    {
        base.Start();
        IdleState = new E2_IdleState(stateMachine, this, "idle", idleData, this);
        MoveState = new E2_MoveState(stateMachine, this, "move", moveData, this);
        PlayerDetected = new E2_PlayerDetected(stateMachine, this, "idle", playerDetectedData, this);
        LookForPlayer = new E2_LookForPlayer(stateMachine, this, "idle", lookForPlayerData, this);
        ChargeState = new E2_ChargeState(stateMachine, this, "move", chargeData, this);
        RangeAttackState = new E2_RangeAttackState(stateMachine, this, "rangeAttack", attackPoint, rangeAttackData, this);
        HurtState = new E2_HurtState(stateMachine, this, "hurt", hurtData, this);
        DeadState = new E2_DeadState(stateMachine, this, "dead", deadData);
        stateMachine.Initialize(MoveState);
    }

    public override void Damage(AttackDetails attackDetails)
    {
        if(isDead)
            return;
        base.Damage(attackDetails);
        if (isDead)
        {
            stateMachine.ChangeState(DeadState);
        }
        else if(isHurt && stateMachine.currentState != HurtState)
        {
            stateMachine.ChangeState(HurtState);
        }
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
}
