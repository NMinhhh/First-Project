using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnState : EnemyState
{
    protected EnemySpawnData data;
    protected Transform spawnPoint;
    private GameObject Go;
    public EnemySpawnState(EnemyStateMachine stateMachine, Entity entity, string isBoolName, EnemySpawnData data, Transform spawnPoint) : base(stateMachine, entity, isBoolName)
    {
        this.data = data;
        this.spawnPoint = spawnPoint;
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
        entity.ResetCooldown();
        entity.ResetSkill();
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
        if(entity.facingDir == 1)
        {
            Go = GameObject.Instantiate(data.spawnGO, spawnPoint.position, Quaternion.identity);
        }
        else
        {
            Go = GameObject.Instantiate(data.spawnGO, spawnPoint.position, Quaternion.Euler(0,180f,0));
        }
    }
}
