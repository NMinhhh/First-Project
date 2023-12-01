using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E2_MoveState : EnemyMoveState
{
    private Enemy2 enemy;
    public E2_MoveState(EnemyStateMachine stateMachine, Entity entity, string isBoolName, EnemyMoveData data, Enemy2 enemy) : base(stateMachine, entity, isBoolName, data)
    {
        this.enemy = enemy;
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
            stateMachine.ChangeState(enemy.PlayerDetected);
        }
        if(!isLedge || isWall)
        {
            stateMachine.ChangeState(enemy.IdleState);
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
