using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E3_SpawnState : EnemySpawnState
{
    private Enemy3 enemy;
    public E3_SpawnState(EnemyStateMachine stateMachine, Entity entity, string isBoolName, EnemySpawnData data, Transform spawnPoint, Enemy3 enemy) : base(stateMachine, entity, isBoolName, data, spawnPoint)
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
        if (isFinishAnimation)
        {
            stateMachine.ChangeState(enemy.PlayerDetectedState);
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
