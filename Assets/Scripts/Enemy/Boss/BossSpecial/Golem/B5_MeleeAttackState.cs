using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B5_MeleeAttackState : BossMeleeAttackState
{
    private Golem golem;
    public B5_MeleeAttackState(Boss boss, BossStateMachine stateMachine, string isBoolName, Transform attackPoint, BossMeleeAttackData data, Golem golem) : base(boss, stateMachine, isBoolName, attackPoint, data)
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
