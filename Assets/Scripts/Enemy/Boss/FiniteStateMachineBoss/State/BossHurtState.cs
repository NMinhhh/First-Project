using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHurtState : BossState
{
    protected BossHurtData data;
    public BossHurtState(Boss boss, BossStateMachine stateMachine, string isBoolName, BossHurtData data) : base(boss, stateMachine, isBoolName)
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
        boss.SetKhockback(data.knockback);
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
