using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B1_BulletRainSkillState : BossBulletRainSkillState
{
    private BatBoss batBoss;
    private GameObject bullet;
    private GameObject bgSkill;
    private FireBall fireBall;
    public B1_BulletRainSkillState(Boss boss, BossStateMachine stateMachine, string isBoolName, BossBulletRainSkillData data, BatBoss batBoss, GameObject bgSkill) : base(boss, stateMachine, isBoolName, data)
    {
        this.batBoss = batBoss;
        this.bgSkill = bgSkill;
    }

    public override void DoCheck()
    {
        base.DoCheck();
    }

    public override void Enter()
    {
        base.Enter();
        bgSkill.SetActive(true);
        SoundFXManager.Instance.CreateAudio(SoundFXManager.Instance.GetAudio(1), boss.transform, 1);
    }

    public override void Exit()
    {
        base.Exit();
        boss.gameObject.layer = 7;
        boss.anim.SetBool("finishSkill", false);
        bgSkill.SetActive(false);
        isFinishSkill = true;
    }

    public override void FinishAnimation()
    {
        base.FinishAnimation();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(!isFinishSkill)
        {
            if(Time.time >= startTime + data.timeDelayBulletFall && currentAmountOfBullet > 0 && boss.player != null)
            {
                currentAmountOfBullet -= 1;
                startTime = Time.time;
                bullet = GameObject.Instantiate(data.bullet, new Vector3(Random.Range(batBoss.cam.transform.position.x + data.randomSkillPointX.x,batBoss.cam.transform.position.x + data.randomSkillPointX.y),batBoss.transform.position.y + data.skillPointY, 0), Quaternion.Euler(0, 0, -90));
                fireBall = bullet.GetComponent<FireBall>();
                fireBall.SetFireBall(data.speed, data.damage, data.overTimeFly);
            }
            else if(currentAmountOfBullet <= 0 || boss.player == null)
            {
                bgSkill.SetActive(false);
                boss.anim.SetBool("finishSkill", true);
                SoundFXManager.Instance.CreateAudio(SoundFXManager.Instance.GetAudio(1), boss.transform, 1);
                isFinishSkill = true;
            }
        }else if (isFinishAnimation)
        {
            stateMachine.ChangeState(batBoss.IdleState);
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
