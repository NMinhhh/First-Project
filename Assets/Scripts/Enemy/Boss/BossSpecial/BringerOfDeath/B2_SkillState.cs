using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B2_SkillState : BossSpawnState
{
    private BringerOfDeath bringerOfDeath;
    private GameObject GO;
    private Spells spells;
    public B2_SkillState(Boss boss, BossStateMachine stateMachine, string isBoolName, BossSpawnData data, BringerOfDeath bringerOfDeath) : base(boss, stateMachine, isBoolName, data)
    {
        this.bringerOfDeath = bringerOfDeath;
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
        if(isFinishAnimation)
        {
            stateMachine.ChangeState(bringerOfDeath.PlayerDetectedState);
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }

    public override void TriggerAnimation()
    {
        base.TriggerAnimation();
        Spawn(boss.player.transform.position.x, data.point.y);
        Spawn(Random.Range(bringerOfDeath.cam.transform.position.x - 12,bringerOfDeath.cam.transform.position.x + 12), data.point.y);
        Spawn(Random.Range(bringerOfDeath.cam.transform.position.x - 12,bringerOfDeath.cam.transform.position.x + 12), data.point.y);

    }
    public void Spawn(float pointX,float pointY)
    {
        float dir;
        GO = GameObject.Instantiate(data.spawnGO,new Vector3(pointX,boss.transform.position.y + pointY,0),Quaternion.identity);
        spells = GO.GetComponent<Spells>();
        if(GO.transform.position.x < boss.player.transform.position.x)
        {
            dir = 1;
        }
        else
        {
            dir = -1;
        }
        spells.CreateSpells(data.damage,data.enemy[Random.Range(0,data.enemy.Length)],dir);
    }
}
