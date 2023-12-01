using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BringerOfDeath : Boss
{
    public B2_MoveState MoveState { get; private set; }
    public B2_IdleState IdleState { get; private set; }
    public B2_PlayerDetectedState PlayerDetectedState { get; private set; }
    public B2_MeleeAttackState MeleeAttackState { get; private set; }
    public B2_HurtState HurtState { get; private set; }
    public B2_DeadState DeadState { get; private set; }
    public B2_SkillState SkillState { get; private set; }

    [SerializeField] private BossMoveData moveData;
    [SerializeField] private BossPlayerDetectedData detectedData;
    [SerializeField] private BossMeleeAttackData meleeAttackData;
    [SerializeField] private BossHurtData hurtData;
    [SerializeField] private BossDeathData deathData;
    [SerializeField] private BossSpawnData spawnData;

    [SerializeField] private Transform attackPoint;
    public Transform cam { get; private set; }
    protected override void Start()
    {
        base.Start();
        MoveState = new B2_MoveState(this, stateMachine, "move", moveData, this);
        IdleState = new B2_IdleState(this, stateMachine, "idle", this);
        PlayerDetectedState = new B2_PlayerDetectedState(this, stateMachine, "idle", detectedData, this);
        MeleeAttackState = new B2_MeleeAttackState(this, stateMachine, "attack", attackPoint,meleeAttackData, this);
        HurtState = new B2_HurtState(this, stateMachine, "hurt", hurtData, this);
        DeadState = new B2_DeadState(this, stateMachine, "dead", deathData, this);
        SkillState = new B2_SkillState(this, stateMachine, "skill", spawnData, this);
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
        if(Time.time >= startTime + spawnData.cooldownTimer && !isSkill)
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
        else if(isHurt && stateMachine.currentState != HurtState && stateMachine.currentState != SkillState)
        {
            stateMachine.ChangeState(HurtState);
        }
    }

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.DrawWireSphere(attackPoint.position, meleeAttackData.radius);
    }
}
