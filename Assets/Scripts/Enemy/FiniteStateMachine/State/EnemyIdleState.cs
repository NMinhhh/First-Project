using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyState
{
    protected EnemyIdleData data;
    protected bool isFlipAfterIdle;
    protected bool isIdleOver;
    public EnemyIdleState(EnemyStateMachine stateMachine, Entity entity, string isBoolName, EnemyIdleData data) : base(stateMachine, entity, isBoolName)
    {
        this.data = data;
    }

    public override void DoCheck()
    {
        base.DoCheck();
    }

    public override void Enter()
    {
        base.Enter();
        isFlipAfterIdle = false;
        isIdleOver = false;
        entity.SetVelocityZero();
    }

    public override void Exit()
    {
        base.Exit();
        if (isIdleOver)
        {
            entity.Flip();
        }
    }

    public override void FinishAnimation()
    {
        base.FinishAnimation();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (Time.time >= startTime + data.idleTime)
        {
            isFlipAfterIdle = true;
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }

    public override void TriggerAnimation()
    {
        base.TriggerAnimation();
    }

    public void FlipAfterIdle(bool isFlip)
    {
        isIdleOver = isFlip;
    }
}
