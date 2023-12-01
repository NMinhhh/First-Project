using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBlockState : EnemyState
{
    protected EnemyBlockData data;
    protected bool isBlockFinish;
    protected bool isPlayerDetected;
    public EnemyBlockState(EnemyStateMachine stateMachine, Entity entity, string isBoolName, EnemyBlockData data) : base(stateMachine, entity, isBoolName)
    {
        this.data = data;
    }

    public override void DoCheck()
    {
        base.DoCheck();
        isPlayerDetected = entity.CheckPlayerDetected();
    }

    public override void Enter()
    {
        base.Enter();
        isBlockFinish = false;
    }

    public override void Exit()
    {
        base.Exit();
        entity.ResetSkill();
        entity.ResetCooldown();
    }

    public override void FinishAnimation()
    {
        base.FinishAnimation();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(Time.time >= startTime + data.blockTimer)
        {
            isBlockFinish = true;
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
