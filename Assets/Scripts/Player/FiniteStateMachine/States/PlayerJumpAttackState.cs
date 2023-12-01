using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpAttackState : PlayerState
{
    private Transform jumpAttackPoint;
    public PlayerJumpAttackState(Player player, StateMachine stateMachine, PlayerData playerData, string animBoolName, Transform jumpAttackPoint) : base(player, stateMachine, playerData, animBoolName)
    {
        this.jumpAttackPoint = jumpAttackPoint;
    }

    public override void DoCheck()
    {
        base.DoCheck();
    }

    public override void Enter()
    {
        base.Enter();
        player.SetVelocityZero();
        player.SetGravityScale(0);
        player.Anim.SetInteger("jumpAttackCount", player.AmountOfJumpAttack);
    }

    public override void Exit()
    {
        base.Exit();
        player.ComboJumpAttack();
        InputManager.Instance.UseAttackInput();
        player.SetGravityScale(player.currentGravity);
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
            stateMachine.ChangeState(player.InAirState);
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }

    public override void TriggerAnimation()
    {
        base.TriggerAnimation();
        player.attackDetails.attackPos = player.transform;
        player.attackDetails.attackDamage = player.AmountDamage();
        int amountSound = 1;
        if(player.AmountOfJumpAttack < 2)
        {
            RaycastHit2D[] hit = Physics2D.BoxCastAll(jumpAttackPoint.position, playerData.jumpAttackSize, 0, Vector2.right, 0, playerData.whatIsEnemy);
            foreach(RaycastHit2D col in hit)
            {
                if (col)
                {
                    if (amountSound == 1)
                    {
                        SoundFXManager.Instance.CreateAudio(playerData.audioClips[0], player.transform, 1);
                        amountSound++;
                    }
                    col.transform.SendMessage("Damage", player.attackDetails);
                }
            }
        }
        else
        {
            Collider2D[] hit = Physics2D.OverlapCircleAll(jumpAttackPoint.position, playerData.jumpAttackRad, playerData.whatIsEnemy);
            foreach (Collider2D col in hit)
            {
                if (col)
                {
                    if (amountSound == 1)
                    {
                        SoundFXManager.Instance.CreateAudio(playerData.audioClips[0], player.transform, 1);
                        amountSound++;
                    }
                    col.transform.SendMessage("Damage", player.attackDetails);
                }
            }
        }
    }
}
