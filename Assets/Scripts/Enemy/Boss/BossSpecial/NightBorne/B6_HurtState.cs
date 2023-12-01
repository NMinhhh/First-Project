using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B6_HurtState : BossHurtState
{
    private NightBorne nightBorne;
    public B6_HurtState(Boss boss, BossStateMachine stateMachine, string isBoolName, BossHurtData data, NightBorne nightBorne) : base(boss, stateMachine, isBoolName, data)
    {
        this.nightBorne = nightBorne;
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
        if (isFinishAnimation)
        {
            stateMachine.ChangeState(nightBorne.PlayerDetectedState);
        }
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
