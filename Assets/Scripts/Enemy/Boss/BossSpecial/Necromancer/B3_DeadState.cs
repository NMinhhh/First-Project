using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B3_DeadState : BossDeathState
{
    public B3_DeadState(Boss boss, BossStateMachine stateMachine, string isBoolName, BossDeathData data) : base(boss, stateMachine, isBoolName, data)
    {
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
