using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLookForPlayerState : EnemyState
{
    protected EnemyLookForPlayerData data;
    protected bool isPlayerDetected;
    protected int amountOfFlip;
    protected bool isFlip;
    protected bool isFlipOver;
    public EnemyLookForPlayerState(EnemyStateMachine stateMachine, Entity entity, string isBoolName, EnemyLookForPlayerData data) : base(stateMachine, entity, isBoolName)
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
        isFlip = true;
        isFlipOver = false;
        amountOfFlip = data.amountOfFlip;
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
        if(amountOfFlip > 0 && Time.time >= startTime + data.isOverFlip && isFlip)
        {
            startTime = Time.time;
            Flip();
            amountOfFlip--;
        }else if(amountOfFlip <= 0 && isFlip)
        {
            isFlip = false;
            isFlipOver = true;
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

    public void Flip()
    {
        entity.Flip();
    }
}
