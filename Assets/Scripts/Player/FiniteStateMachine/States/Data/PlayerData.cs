using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "newPlayerData", menuName = "Data/Base Data/Player Data")]
public class PlayerData : ScriptableObject
{
    [Header("Move State")]
    public float movementSpeed = 5f;

    [Header("Check Ground")]
    public float radius = 0.2f;
    public LayerMask whatIsGround;

    [Header("Jump State")]
    public float jumpForce = 12f;
    public int amountOfJump = 2;
    public float jumpCooldown = 0.5f;
    public float coyoteJumpTime = 0.5f;

    [Header("Attack State")]    
    public Vector2 attackSize;
    public LayerMask whatIsEnemy;
    public float resetAttackTime = 1.5f;
    public float attackRadius = 0.2f;
    public float attackDamage = 10f;

    [Header("Dash State")]
    public float dashSpeed = 10f;
    public float dashTime = 0.5f;
    public float cooldownDash = 3f;

    [Header("Heavy Attack State")]
    public float heavyAttackRadius = 0.2f;
    public float heavyAttackDamage = 20f;
    public float cooldownHeavyAttack = 5f;
    public GameObject goEffect;

    [Header("Hurt State")]
    public float maxHealth = 100f;
    public float defense = 10f;
    public Vector2 knockBackSpeed;

    [Header("Dead State")]
    public float overDeadTime = 1f;

    [Header("Jump Attack State")]
    public Vector2 jumpAttackSize;
    public float jumpAttackRad = 0.3f;

    [Header("Water Blast Skill State")]
    public float waterBlastSpeed = 6f;
    public float waterBlastdamage = 60f;
    public float waterBlastOverTimeLife = 8f;
    public float cooldownWaterBlast = 10f;
    public GameObject waterGo;

    [Header("Wind Skill State")]
    public GameObject windGo;
    public float windSkillDamage = 60f;
    public float cooldownWind = 5f;
    public Vector2 checkSize;

    [Header("Sound FX")]
    public AudioClip[] audioClips;
}
