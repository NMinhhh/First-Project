using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E6_DeadState : EnemyDeadState
{
    private Enemy6 enemy;
    public E6_DeadState(EnemyStateMachine stateMachine, Entity entity, string isBoolName, EnemyDeadData data, Enemy6 enemy) : base(stateMachine, entity, isBoolName, data)
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
        if(isFinishAnimation)
        {
            entity.Dead(data.overDeadTime);
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
