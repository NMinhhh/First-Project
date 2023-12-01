using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "newBossBulletRainSkillData", menuName = "Data/Boss/Bullet Rain Skill Data")]
public class BossBulletRainSkillData : ScriptableObject
{
    public GameObject bullet;
    public Vector2 randomSkillPointX;
    public float skillPointY = 1f;
    public float amountOfBullet = 30f;
    public float speed = 5f;
    public float overTimeFly = 5f;
    public float damage = 20f;
    public float cooldownTimer = 10f;
    public float timeDelayBulletFall = 0.2f;
}
