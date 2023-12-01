using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E2_PlayerDetected : EnemyPlayerDetectedState
{
    private Enemy2 enemy;
    public E2_PlayerDetected(EnemyStateMachine stateMachine, Entity entity, string isBoolName, EnemyPlayerDetectedData data, Enemy2 enemy) : base(stateMachine, entity, isBoolName, data)
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
        entity.SetVelocityZero();
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
        if(isCloseRangePlayerDetected && isDetectedOver)
        {
            stateMachine.ChangeState(enemy.RangeAttackState);
        }
        else if(isDetectedOver && isPlayerDetected)
        {
            stateMachine.ChangeState(enemy.ChargeState);
        }
        else if (!isPlayerDetected)
        {
            stateMachine.ChangeState(enemy.LookForPlayer);
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
