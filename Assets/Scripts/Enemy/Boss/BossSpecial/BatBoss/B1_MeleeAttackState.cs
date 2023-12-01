using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B1_MeleeAttackState : BossMeleeAttackState
{
    private BatBoss batBoss;
    public B1_MeleeAttackState(Boss boss, BossStateMachine stateMachine, string isBoolName, Transform attackPoint, BossMeleeAttackData data, BatBoss batBoss) : base(boss, stateMachine, isBoolName, attackPoint, data)
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
        if(isFinishAnimation)
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
