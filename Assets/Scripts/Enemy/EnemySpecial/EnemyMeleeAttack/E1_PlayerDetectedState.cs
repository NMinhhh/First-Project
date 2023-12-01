using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_PlayerDetectedState : EnemyPlayerDetectedState
{
    protected Enemy1 enemy;
    public E1_PlayerDetectedState(EnemyStateMachine stateMachine, Entity entity, string isBoolName, EnemyPlayerDetectedData data, Enemy1 enemy) : base(stateMachine, entity, isBoolName, data)
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
        if (isCloseRangePlayerDetected && isDetectedOver)
        {
            stateMachine.ChangeState(enemy.MeleeAttackState);
        }
        else if(isPlayerDetected && isDetectedOver)
        {
            stateMachine.ChangeState(enemy.ChargeState);
        }
        else if (!isPlayerDetected)
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
