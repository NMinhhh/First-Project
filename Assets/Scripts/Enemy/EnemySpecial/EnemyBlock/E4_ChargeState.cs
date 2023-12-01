using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E4_ChargeState : EnemyChargeState
{
    private Enemy4 enemy;
    public E4_ChargeState(EnemyStateMachine stateMachine, Entity entity, string isBoolName, EnemyChargeData data, Enemy4 enemy) : base(stateMachine, entity, isBoolName, data)
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
        }else if (isCloseRangPlayer)
        {
            stateMachine.ChangeState(enemy.MeleeAttackState);
        }else if (!isPlayerDetected)
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
