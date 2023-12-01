using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlayerDetectedState : EnemyState
{
    protected EnemyPlayerDetectedData _data;
    protected bool isPlayerDetected;
    protected bool isDetectedOver;
    protected bool isCloseRangePlayerDetected;
    protected bool isLongRangePlayerDetected;
    public EnemyPlayerDetectedState(EnemyStateMachine stateMachine, Entity entity, string isBoolName, EnemyPlayerDetectedData data) : base(stateMachine, entity, isBoolName)
    {
        _data = data;
    }

    public override void DoCheck()
    {
        base.DoCheck();
        isPlayerDetected = entity.CheckPlayerDetected();
        isCloseRangePlayerDetected = entity.CheckChoseRangePlayerDetected();
        isLongRangePlayerDetected = entity.CheckLongRangePlayerDetected();
    }

    public override void Enter()
    {
        base.Enter();
        isDetectedOver = false;
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
        if(Time.time >= startTime + _data.detectedTimeOver)
        {
            isDetectedOver = true;
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
