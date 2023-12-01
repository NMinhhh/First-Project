using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState 
{
    protected EnemyStateMachine stateMachine;
    protected Entity entity;
    protected string isBoolName;
    protected bool isFinishAnimation;
    protected float startTime;
    public EnemyState(EnemyStateMachine stateMachine, Entity entity, string isBoolName)
    {
        this.stateMachine = stateMachine;
        this.entity = entity;
        this.isBoolName = isBoolName;
    }

    public virtual void Enter()
    {
        startTime = Time.time;
        isFinishAnimation = false;
        DoCheck();
        entity.anim.SetBool(isBoolName, true);
    }

    public virtual void LogicUpdate()
    {

    }

    public virtual void PhysicUpdate() => DoCheck();

    public virtual void Exit() => entity.anim.SetBool(isBoolName, false);

    public virtual void DoCheck() { }

    public virtual void FinishAnimation() => isFinishAnimation = true;

    public virtual void TriggerAnimation() { }
}
