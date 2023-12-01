using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWindSkillState : PlayerState
{
    private SkillCooldownManager skillCooldownManager;
    private Transform checkEnemy;
    private GameObject Go;
    private Wind script;
    public PlayerWindSkillState(Player player, StateMachine stateMachine, PlayerData playerData, string animBoolName, Transform checkEnemy, SkillCooldownManager skillCooldownManager) : base(player, stateMachine, playerData, animBoolName)
    {
        this.checkEnemy = checkEnemy;
        this.skillCooldownManager = skillCooldownManager;
    }

    public override void DoCheck()
    {
        base.DoCheck();
    }

    public override void Enter()
    {
        base.Enter();
        skillCooldownManager.SkillCooldown(playerData.cooldownWind);
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
            stateMachine.ChangeState(player.IdleState);
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }

    public override void TriggerAnimation()
    {
        base.TriggerAnimation();
        int amountSound = 1;
        RaycastHit2D[] hit = Physics2D.BoxCastAll(checkEnemy.position, playerData.checkSize, 0, Vector2.right, 0, playerData.whatIsEnemy);
        foreach(RaycastHit2D col in hit)
        {
            if (col)
            {
                if (amountSound == 1)
                {
                    SoundFXManager.Instance.CreateAudio(playerData.audioClips[5], player.transform, 1);
                    amountSound++;
                }
                Go = GameObject.Instantiate(playerData.windGo, col.transform.position, Quaternion.Euler(0,0,Random.Range(0,360)));
                script = Go.GetComponent<Wind>();
                script.Create(col.transform,playerData.windSkillDamage + player.WeaponDamage());
            }
        }
    }
}
