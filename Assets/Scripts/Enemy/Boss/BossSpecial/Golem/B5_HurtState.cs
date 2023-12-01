using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B5_HurtState : BossHurtState
{
    private Golem golem;
    public B5_HurtState(Boss boss, BossStateMachine stateMachine, string isBoolName, BossHurtData data, Golem golem) : base(boss, stateMachine, isBoolName, data)
    {
        this.golem = golem;
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
            stateMachine.ChangeState(golem.PlayerDetectedState);
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
