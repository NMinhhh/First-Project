using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B3_SkillSpawnState : BossSpawnState
{
    private NecromancerBoss necromancer;
    private GameObject GO;
    private Spells script;
    public B3_SkillSpawnState(Boss boss, BossStateMachine stateMachine, string isBoolName, BossSpawnData data, NecromancerBoss necromancer) : base(boss, stateMachine, isBoolName, data)
    {
        this.necromancer = necromancer;
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
            stateMachine.ChangeState(necromancer.PlayerDetectedState);
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }

    public override void TriggerAnimation()
    {
        base.TriggerAnimation();
        Spawn(Random.Range(necromancer.cam.position.x + 12, necromancer.cam.transform.position.x - 12), data.point.y);
        Spawn(Random.Range(necromancer.cam.position.x + 12, necromancer.cam.transform.position.x - 12), data.point.y);
    }
    public void Spawn(float pointX, float pointY)
    {
        float dir;
        GO = GameObject.Instantiate(data.spawnGO, new Vector3(pointX,boss.transform.position.y + pointY, 0), Quaternion.identity);
        script = GO.GetComponent<Spells>();
        if(GO.transform.position.x >= boss.player.transform.position.x)
        {
            dir = -1;
        }
        else
        {
            dir = 1;
        }
        script.CreateSpells(data.damage, data.enemy[Random.Range(0, data.enemy.Length)], dir);
    }
}
