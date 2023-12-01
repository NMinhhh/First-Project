using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E2_LookForPlayer : EnemyLookForPlayerState
{
    private Enemy2 enemy;
    public E2_LookForPlayer(EnemyStateMachine stateMachine, Entity entity, string isBoolName, EnemyLookForPlayerData data, Enemy2 enemy) : base(stateMachine, entity, isBoolName, data)
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
        else if(isFlipOver && !isPlayerDetected)
        {
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
