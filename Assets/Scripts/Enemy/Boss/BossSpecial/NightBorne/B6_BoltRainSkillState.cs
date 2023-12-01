using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B6_BoltRainSkillState : BossBulletRainSkillState
{
    private NightBorne nightBorne;
    private GameObject Go;
    private Bolt script;
    public B6_BoltRainSkillState(Boss boss, BossStateMachine stateMachine, string isBoolName, BossBulletRainSkillData data, NightBorne nightBorne) : base(boss, stateMachine, isBoolName, data)
    {
        this.nightBorne = nightBorne;
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
        boss.anim.SetBool("finishSkill", false);
    }

    public override void FinishAnimation()
    {
        base.FinishAnimation();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (!isFinishSkill)
        {
            if (Time.time >= startTime + data.timeDelayBulletFall && currentAmountOfBullet > 0 && boss.player != null)
            {
                currentAmountOfBullet -= 1;
                startTime = Time.time;
                Go = GameObject.Instantiate(data.bullet, new Vector3(boss.player.transform.position.x, boss.transform.position.y + data.skillPointY, 0), Quaternion.identity);
                script = Go.GetComponent<Bolt>();
                script.CreateSpells(data.damage);

            }
            else if (currentAmountOfBullet <= 0 || boss.player == null)
            {
                boss.anim.SetBool("finishSkill", true);
                isFinishSkill = true;
            }
        }
        else if (isFinishAnimation)
        {
            stateMachine.ChangeState(nightBorne.PlayerDetectedState);
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
