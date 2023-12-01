using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E4_IdleState : EnemyIdleState
{
    private Enemy4 enemy;
    public E4_IdleState(EnemyStateMachine stateMachine, Entity entity, string isBoolName, EnemyIdleData data, Enemy4 enemy) : base(stateMachine, entity, isBoolName, data)
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
        if (isFlipAfterIdle)
        {
            FlipAfterIdle(true);
            stateMachine.ChangeState(enemy.MoveState);
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
