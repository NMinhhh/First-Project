using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    protected Player player;
    protected StateMachine stateMachine;
    protected PlayerData playerData;
    protected bool isFinishAnimation;
    protected float startTime;

    protected string animBoolName;
    public PlayerState(Player player, StateMachine stateMachine, PlayerData playerData,string animBoolName)
    {
        this.player = player;
        this.stateMachine = stateMachine;
        this.playerData = playerData;
        this.animBoolName = animBoolName;
    }

    public virtual void Enter() 
    {
        isFinishAnimation = false;
        startTime = Time.time;
        player.Anim.SetBool(animBoolName, true);
        DoCheck();
    }
    public virtual void Exit() 
    {
        player.Anim.SetBool(animBoolName, false);
    }
    public virtual void LogicUpdate() { }
    public virtual void PhysicUpdate() => DoCheck();

    public virtual void DoCheck() { }

    public virtual void FinishAnimation() => isFinishAnimation = true;

    public virtual void TriggerAnimation() { }
}
