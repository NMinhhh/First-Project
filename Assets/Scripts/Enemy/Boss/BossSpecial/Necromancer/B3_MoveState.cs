using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B3_MoveState : BossMoveState
{
    private NecromancerBoss necromancer;
    public B3_MoveState(Boss boss, BossStateMachine stateMachine, string isBoolName, BossMoveData data, NecromancerBoss necromancer) : base(boss, stateMachine, isBoolName, data)
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
        if (isPlayerDetected)
        {
            stateMachine.ChangeState(necromancer.PlayerDetectedState);
        }else if (isDistance)
        {
            stateMachine.ChangeState(necromancer.IdleState);
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
