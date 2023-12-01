using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeadState : EnemyState
{
    protected EnemyDeadData data;
    public EnemyDeadState(EnemyStateMachine stateMachine, Entity entity, string isBoolName, EnemyDeadData data) : base(stateMachine, entity, isBoolName)
    {
        this.data = data;
    }

    public override void DoCheck()
    {
        base.DoCheck();
    }

    public override void Enter()
    {
        base.Enter();
        GameManager.instance.EncreaseCoin((int)Random.Range(data.randomCoin.x,data.randomCoin.y));
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
        if (isFinishAnimation)
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
