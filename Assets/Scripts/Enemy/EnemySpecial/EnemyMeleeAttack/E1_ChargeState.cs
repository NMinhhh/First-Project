using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_ChargeState : EnemyChargeState
{
    private Enemy1 enemy;
    public E1_ChargeState(EnemyStateMachine stateMachine, Entity entity, string isBoolName, EnemyChargeData data, Enemy1 enemy) : base(stateMachine, entity, isBoolName, data)
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
        if(!isPlayerDetected)
        {
            stateMachine.ChangeState(enemy.LookForPlayerState);
        }else if(!isLedge || isWall)
        {
            stateMachine.ChangeState(enemy.IdleState);
        }else if (isCloseRangPlayer)
        {
            stateMachine.ChangeState(enemy.MeleeAttackState);
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
