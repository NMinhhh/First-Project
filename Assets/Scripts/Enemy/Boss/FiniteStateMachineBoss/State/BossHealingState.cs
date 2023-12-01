using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealingState : BossState
{
    protected BossHealingData data;
    public BossHealingState(Boss boss, BossStateMachine stateMachine, string isBoolName, BossHealingData data) : base(boss, stateMachine, isBoolName)
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
        boss.SetVelocityZero();
    }

    public override void Exit()
    {
        base.Exit();
        boss.isSkill = false;
        boss.ResetCooldownTimer(Time.time);
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
        boss.Healing(data.amountHealth);
    }
}
