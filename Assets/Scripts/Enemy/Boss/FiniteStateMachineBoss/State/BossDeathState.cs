using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDeathState : BossState
{
    protected BossDeathData data;
    public BossDeathState(Boss boss, BossStateMachine stateMachine, string isBoolName, BossDeathData data) : base(boss, stateMachine, isBoolName)
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
        GameManager.instance.EncreaseCoin((int)data.coin);
        boss.SetKhockback(data.knockbackForce);
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
