using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossIdleState : BossState
{
    protected bool isDetected;
    protected bool isDistance;
    public BossIdleState(Boss boss, BossStateMachine stateMachine, string isBoolName) : base(boss, stateMachine, isBoolName)
    {
    }

    public override void DoCheck()
    {
        base.DoCheck();
        isDetected = boss.CheckPlayerDetected();
        isDistance = boss.CheckDistance();
    }

    public override void Enter()
    {
        base.Enter();
        boss.SetVelocityZero();
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
