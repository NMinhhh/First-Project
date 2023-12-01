using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E3_DeadState : EnemyDeadState
{
    private Enemy3 enemy;
    public E3_DeadState(EnemyStateMachine stateMachine, Entity entity, string isBoolName, EnemyDeadData data, Enemy3 enemy) : base(stateMachine, entity, isBoolName, data)
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
