using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B6_DeadState : BossDeathState
{
    private NightBorne nightBorne;
    public B6_DeadState(Boss boss, BossStateMachine stateMachine, string isBoolName, BossDeathData data, NightBorne nightBorne) : base(boss, stateMachine, isBoolName, data)
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
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (isFinishAnimation)
        {
            boss.DestroyGO(data.timeDes);
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
