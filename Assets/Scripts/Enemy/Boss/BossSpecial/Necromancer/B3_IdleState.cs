using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B3_IdleState : BossIdleState
{
    private NecromancerBoss necromancer;
    public B3_IdleState(Boss boss, BossStateMachine stateMachine, string isBoolName, NecromancerBoss necromancer) : base(boss, stateMachine, isBoolName)
    {
        this.necromancer = necromancer;
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
        if(boss.player == null)
        {
            return;
        }
        else if (!isDistance)
        {
            stateMachine.ChangeState(necromancer.MoveState);
        }
        else if (isDetected && boss.player != null)
        {
            stateMachine.ChangeState(necromancer.PlayerDetectedState);
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
