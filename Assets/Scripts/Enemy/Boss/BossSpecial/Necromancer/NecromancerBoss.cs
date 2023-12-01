using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NecromancerBoss : Boss
{
    public B3_IdleState IdleState { get; private set; }
    public B3_MoveState MoveState { get; private set; }
    public B3_PlayerDetectedState PlayerDetectedState { get; private set; }
    public B3_AttackState AttackState { get; private set; }
    public B3_HurtState HurtState { get; private set; }
    public B3_DeadState DeadState { get; private set; }
    public B3_SkillSpawnState SkillSpawnState { get; private set;}
    public B3_HealingSkillState HealingSkillState { get; private set; }

    [SerializeField] private BossMoveData moveData;
    [SerializeField] private BossPlayerDetectedData detectedData;
    [SerializeField] private BossRangeAttackData rangeAttackData;
    [SerializeField] private BossHurtData hurtData;
    [SerializeField] private BossDeathData deathData;
    [SerializeField] private BossSpawnData spawnData;
    [SerializeField] private BossHealingData healingData;

    [SerializeField] private Transform attackPoint;

    private int amountHealing;

    public Transform cam { get; private set; }
    protected override void Start()
    {
        base.Start();
        IdleState = new B3_IdleState(this, stateMachine, "idle", this);
        MoveState = new B3_MoveState(this, stateMachine, "move", moveData, this);
        PlayerDetectedState = new B3_PlayerDetectedState(this, stateMachine, "idle", detectedData, this);
        AttackState = new B3_AttackState(this, stateMachine, "rangeAttack", attackPoint, rangeAttackData, this);
        HurtState = new B3_HurtState(this, stateMachine, "hurt", hurtData, this);
        DeadState = new B3_DeadState(this, stateMachine, "dead", deathData);
        SkillSpawnState = new B3_SkillSpawnState(this,stateMachine,"spawn",spawnData, this);
        HealingSkillState = new B3_HealingSkillState(this, stateMachine, "healing", healingData, this);
        stateMachine.Initialize(MoveState);
        cam = GameObject.Find("Main Camera").transform;
    }

    protected override void Update()
    {
        base.Update();
        if(player == null)
        {
            stateMachine.ChangeState(IdleState);
        }
        if(Time.time >= startTime + healingData.cooldownTimer && !isSkill && amountHealing <= 2 && currentHealth < data.maxHealth)
        {
            amountHealing++;
            stateMachine.ChangeState(HealingSkillState);
        }
        else if(Time.time >= startTime + spawnData.cooldownTimer && !isSkill)
        {
            amountHealing = 0;
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
        else if(isHurt && stateMachine.currentState != HurtState && stateMachine.currentState != HealingSkillState && stateMachine.currentState != SkillSpawnState)
        {
            stateMachine.ChangeState(HurtState);
        }
    }

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
    }
}
