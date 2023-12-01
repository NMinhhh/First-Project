using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Guardian : Boss
{
    public B4_IdleState IdleState { get; private set; }
    public B4_MoveState MoveState { get; private set; }
    public B4_PlayerDetectedState PlayerDetectedState { get; private set; }
    public B4_MeleeAttackState MeleeAttackState { get; private set; }
    public B4_HurtState HurtState { get; private set; }
    public B4_DeadState DeadState { get; private set; }

    [SerializeField] private BossMoveData moveData;
    [SerializeField] private BossPlayerDetectedData detectedData;
    [SerializeField] private BossMeleeAttackData meleeAttackData;
    [SerializeField] private BossHurtData hurtData;
    [SerializeField] private BossDeathData deathData;

    [SerializeField] private Transform attackPoint;
    [SerializeField] private Transform rangeAttackPoint;
    private Transform tube;
    public Transform cam { get; private set; }
    protected override void Start()
    {
        base.Start();
        if (gameObject.activeInHierarchy)
        {
            UpdateHealth();
        }
        tube = transform.Find("Tube");
        MoveState = new B4_MoveState(this, stateMachine, "move", moveData, this);
        IdleState = new B4_IdleState(this, stateMachine, "idle", this);
        PlayerDetectedState = new B4_PlayerDetectedState(this, stateMachine, "idle", detectedData, this);
        MeleeAttackState = new B4_MeleeAttackState(this, stateMachine, "meleeAttack", attackPoint, meleeAttackData, this);
        HurtState = new B4_HurtState(this, stateMachine, "hurt", hurtData, this);
        DeadState = new B4_DeadState(this, stateMachine, "dead", deathData, this);
        stateMachine.Initialize(MoveState);
        cam = GameObject.Find("Main Camera").transform;
    }


    protected override void Update()
    {
        base.Update();
    }

    public override void Damage(AttackDetails attackDetails)
    {
        base.Damage(attackDetails);
        if (isDead)
        {
            Destroy(tube.gameObject);
            stateMachine.ChangeState(DeadState);
        }
        else if(isHurt && stateMachine.currentState != HurtState)
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
