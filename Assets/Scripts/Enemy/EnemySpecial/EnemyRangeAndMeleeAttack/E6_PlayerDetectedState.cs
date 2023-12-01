using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E6_PlayerDetectedState : EnemyPlayerDetectedState
{
    private Enemy6 enemy;
    public E6_PlayerDetectedState(EnemyStateMachine stateMachine, Entity entity, string isBoolName, EnemyPlayerDetectedData data, Enemy6 enemy) : base(stateMachine, entity, isBoolName, data)
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
        if(isDetectedOver && isCloseRangePlayerDetected)
        {
            stateMachine.ChangeState(enemy.MeleeAttackState);
        }else if(isDetectedOver && isLongRangePlayerDetected)
        {
            stateMachine.ChangeState(enemy.RangeAttackState);
        }else if(isDetectedOver && isPlayerDetected)
        {
            stateMachine.ChangeState(enemy.ChargeState);
        }else if(!isPlayerDetected)
        {
            stateMachine.ChangeState(enemy.LookForPlayerState);
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
