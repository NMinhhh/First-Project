using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : Entity
{
    public E3_IdleState IdleState { get; private set; }
    public E3_MoveState MoveState { get; private set; }
    public E3_PlayerDetectedState PlayerDetectedState { get; private set; }
    public E3_ChargeState ChargeState { get; private set; }
    public E3_RangeAttackState RangeAttackState { get; private set; }
    public E3_HurtState HurtState { get; private set; }
    public E3_LookForPlayerState LookForPlayerState { get; private set; }
    public E3_DeadState DeadState { get; private set; }
    public E3_SpawnState SpawnState { get; private set; }

    [SerializeField] private EnemyIdleData idleData;
    [SerializeField] private EnemyMoveData moveData;
    [SerializeField] private EnemyPlayerDetectedData detectedData;
    [SerializeField] private EnemyChargeData chargeData;
    [SerializeField] private EnemyRangeAttackData attackData;
    [SerializeField] private EnemyHurtData hurtData;
    [SerializeField] private EnemyLookForPlayerData lookForPlayerData;
    [SerializeField] private EnemyDeadData deadData;
    [SerializeField] private EnemySpawnData spawnData;

    [SerializeField] private Transform attackPoint;
    [SerializeField] private Transform spawnPoint;

    public override void Start()
    {
        base.Start();
        IdleState = new E3_IdleState(stateMachine, this, "idle", idleData, this);
        MoveState = new E3_MoveState(stateMachine, this, "move", moveData, this);
        PlayerDetectedState = new E3_PlayerDetectedState(stateMachine, this, "idle", detectedData, this);
        ChargeState = new E3_ChargeState(stateMachine,this,"move",chargeData,this);
        RangeAttackState = new E3_RangeAttackState(stateMachine, this, "rangeAttack", attackPoint, attackData, this);
        HurtState = new E3_HurtState(stateMachine, this, "hurt", hurtData, this);
        LookForPlayerState = new E3_LookForPlayerState(stateMachine, this, "idle", lookForPlayerData, this);
        DeadState = new E3_DeadState(stateMachine, this, "dead", deadData, this);
        SpawnState = new E3_SpawnState(stateMachine, this, "spawn",spawnData,spawnPoint,this);
        stateMachine.Initialize(MoveState);
    }
    public override void Update()
    {
        base.Update();
        if(Time.time >= startTime + spawnData.cooldownTimer)
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
        base.Damage(attackDetails);
        if (isDead)
        {
            stateMachine.ChangeState(DeadState);
        }else if(isHurt && stateMachine.currentState != HurtState)
        {
            stateMachine.ChangeState(HurtState);
        }
    }

}
