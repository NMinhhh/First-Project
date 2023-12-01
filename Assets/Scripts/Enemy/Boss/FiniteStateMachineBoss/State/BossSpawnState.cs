using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawnState : BossState
{
    protected BossSpawnData data;
    public BossSpawnState(Boss boss, BossStateMachine stateMachine, string isBoolName, BossSpawnData data) : base(boss, stateMachine, isBoolName)
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
        boss.ResetCooldownTimer(Time.time);
        boss.isSkill = false;
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
