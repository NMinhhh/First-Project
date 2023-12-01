using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B4_MeleeAttackState : BossMeleeAttackState
{
    private Guardian guardian;
    public B4_MeleeAttackState(Boss boss, BossStateMachine stateMachine, string isBoolName, Transform attackPoint, BossMeleeAttackData data, Guardian guardian) : base(boss, stateMachine, isBoolName, attackPoint, data)
    {
        this.guardian = guardian;
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
        if(isFinishAnimation)
        {
            stateMachine.ChangeState(guardian.PlayerDetectedState);
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
