using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossState 
{
    protected Boss boss;
    protected BossStateMachine stateMachine;
    protected string isBoolName;
    protected float startTime;
    protected bool isFinishAnimation;

    public BossState(Boss boss, BossStateMachine stateMachine, string isBoolName)
    {
        this.boss = boss;
        this.stateMachine = stateMachine;
        this.isBoolName = isBoolName;
    }

    public virtual void Enter()
    {
        startTime = Time.time;
        isFinishAnimation = false;
        DoCheck();
        boss.anim.SetBool(isBoolName, true);
    }
    
    public virtual void LogicUpdate()
    {

    }

    public virtual void PhysicUpdate() => DoCheck();

    public virtual void Exit() => boss.anim.SetBool(isBoolName, false);

    public virtual void DoCheck() {  }
    
    public virtual void FinishAnimation() => isFinishAnimation = true;
    public virtual void TriggerAnimation() { }
}
