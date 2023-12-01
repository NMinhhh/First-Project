using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B2_HurtState : BossHurtState
{
    private BringerOfDeath bringerOfDeath;
    public B2_HurtState(Boss boss, BossStateMachine stateMachine, string isBoolName, BossHurtData data, BringerOfDeath bringerOfDeath) : base(boss, stateMachine, isBoolName, data)
    {
        this.bringerOfDeath = bringerOfDeath;
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
        if(isFinishAnimation)
        {
            stateMachine.ChangeState(bringerOfDeath.PlayerDetectedState);
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
