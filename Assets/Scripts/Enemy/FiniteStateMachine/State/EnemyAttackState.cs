using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyState
{
    protected Transform attackPoint;
    protected bool isPlayerDetected;
    protected bool isCloseRangePlayerDetected;
    public EnemyAttackState(EnemyStateMachine stateMachine, Entity entity, string isBoolName, Transform pointAttack) : base(stateMachine, entity, isBoolName)
    {
        this.attackPoint = pointAttack;
    }

    public override void DoCheck()
    {
        base.DoCheck();
        isPlayerDetected = entity.CheckPlayerDetected();
        isCloseRangePlayerDetected = entity.CheckChoseRangePlayerDetected();
    }

    public override void Enter()
    {
        base.Enter();
        entity.SetVelocityZero();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void FinishAnimation()
    {
        base.FinishAnimation();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }

    public override void TriggerAnimation()
    {
        base.TriggerAnimation();
    }
}
