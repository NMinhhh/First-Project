using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B6_MeleeAttackState : BossMeleeAttackState
{
    private NightBorne nightBorne;
    public B6_MeleeAttackState(Boss boss, BossStateMachine stateMachine, string isBoolName, Transform attackPoint, BossMeleeAttackData data, NightBorne nightBorne) : base(boss, stateMachine, isBoolName, attackPoint, data)
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
            stateMachine.ChangeState(nightBorne.PlayerDetectedState);
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
