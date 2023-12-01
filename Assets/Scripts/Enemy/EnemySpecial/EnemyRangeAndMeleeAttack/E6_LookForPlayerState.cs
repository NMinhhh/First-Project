using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E6_LookForPlayerState : EnemyLookForPlayerState
{
    private Enemy6 enemy;
    public E6_LookForPlayerState(EnemyStateMachine stateMachine, Entity entity, string isBoolName, EnemyLookForPlayerData data, Enemy6 enemy) : base(stateMachine, entity, isBoolName, data)
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
            stateMachine.ChangeState(enemy.PlayerDetectedState);
        }else if(isFlipOver && !isPlayerDetected)
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
