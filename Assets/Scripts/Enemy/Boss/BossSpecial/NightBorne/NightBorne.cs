using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NightBorne : Boss
{
    public B6_MoveState MoveState { get; private set; }
    public B6_IdleState IdleState { get; private set; }
    public B6_PlayerDetectedState PlayerDetectedState { get; private set; }
    public B6_MeleeAttackState MeleeAttackState { get; private set; }
    public B6_HurtState HurtState { get; private set; }
    public B6_DeadState DeadState { get; private set; }
    public B6_BoltRainSkillState BoltRainSkillState { get;private set; }

    [SerializeField] private BossMoveData moveData;
    [SerializeField] private BossPlayerDetectedData detectedData;
    [SerializeField] private BossMeleeAttackData meleeAttackData;
    [SerializeField] private BossHurtData hurtData;
    [SerializeField] private BossDeathData deathData;
    [SerializeField] private BossBulletRainSkillData bulletRainSkillData;

    [SerializeField] private Transform attackPoint;
    private Transform intrinsic;
    public Transform cam { get; private set; }
    protected override void Start()
    {
        base.Start();
        MoveState = new B6_MoveState(this, stateMachine, "move", moveData, this);
        IdleState = new B6_IdleState(this, stateMachine, "idle", this);
        PlayerDetectedState = new B6_PlayerDetectedState(this, stateMachine, "idle", detectedData, this);
        MeleeAttackState = new B6_MeleeAttackState(this, stateMachine, "attack", attackPoint, meleeAttackData, this);
        BoltRainSkillState = new B6_BoltRainSkillState(this, stateMachine, "skill", bulletRainSkillData, this);
        HurtState = new B6_HurtState(this, stateMachine, "hurt", hurtData, this);
        DeadState = new B6_DeadState(this, stateMachine, "dead", deathData, this);
        stateMachine.Initialize(MoveState);
        cam = GameObject.Find("Main Camera").transform;
        intrinsic = transform.Find("Intrinsic").transform;

    }

    protected override void Update()
    {
        base.Update();
        if (player == null)
        {
            stateMachine.ChangeState(IdleState);
        }
        if(Time.time >= startTime + bulletRainSkillData.cooldownTimer && !isSkill)
        {
            isSkill = true;
        }
    }
    public override void Damage(AttackDetails attackDetails)
    {
        base.Damage(attackDetails);
        if (isDead)
        {
            intrinsic.gameObject.SetActive(false);
            stateMachine.ChangeState(DeadState);
        }
        else if (isHurt && stateMachine.currentState != HurtState && stateMachine.currentState != BoltRainSkillState)
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
