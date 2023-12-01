using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E3_MoveState : EnemyMoveState
{
    private Enemy3 enemy;
    public E3_MoveState(EnemyStateMachine stateMachine, Entity entity, string isBoolName, EnemyMoveData data, Enemy3 enemy) : base(stateMachine, entity, isBoolName, data)
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
        if(!isLedge || isWall)
        {
            stateMachine.ChangeState(enemy.IdleState);
        }else if (isPlayerDetected)
        {
            stateMachine.ChangeState(enemy.PlayerDetectedState);
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
