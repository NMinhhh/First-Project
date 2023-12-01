using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E5_SleepState : EnemySleepState
{
    private Enemy5 enemy;
    public E5_SleepState(EnemyStateMachine stateMachine, Entity entity, string isBoolName, Enemy5 enemy) : base(stateMachine, entity, isBoolName)
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
        entity.anim.SetBool("spawn", false);
    }

    public override void FinishAnimation()
    {
        base.FinishAnimation();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (isLongRangePlayerDetected && !isFinishAnimation)
        {
            entity.anim.SetBool("spawn", true);   
        }else if (isFinishAnimation)
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
