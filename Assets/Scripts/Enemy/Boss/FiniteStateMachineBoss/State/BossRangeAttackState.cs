using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRangeAttackState : BossState
{
    protected BossRangeAttackData data;
    protected Transform attackPoint;
    public BossRangeAttackState(Boss boss, BossStateMachine stateMachine, string isBoolName, Transform attackPoint, BossRangeAttackData data) : base(boss, stateMachine, isBoolName)
    {
        this.attackPoint = attackPoint;
        this.data = data;
    }

    public override void DoCheck()
    {
        base.DoCheck();
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
