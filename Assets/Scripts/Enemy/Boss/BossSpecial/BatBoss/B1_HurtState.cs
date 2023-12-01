using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B1_HurtState : BossHurtState
{
    private BatBoss batBoss;
    public B1_HurtState(Boss boss, BossStateMachine stateMachine, string isBoolName, BossHurtData data, BatBoss batBoss) : base(boss, stateMachine, isBoolName, data)
    {
        this.batBoss = batBoss;
    }

    public override void DoCheck()
    {
        base.DoCheck();
    }

    public override void Enter()
    {
        base.Enter();
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
        if (isFinishAnimation)
        {
            stateMachine.ChangeState(batBoss.DetectedPlayerState);
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
}
