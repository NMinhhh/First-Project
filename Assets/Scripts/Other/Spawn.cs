using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private GameObject spawnGO;
    [SerializeField] private float coolDownTimer;
    [SerializeField] private Vector2 speed;
    [SerializeField] private float damage;
    [SerializeField] private float overTimeFly;
    private GameObject GO;
    private FireBall script;
    private float startTimer;
    // Start is called before the first frame update
    void Start()
    {
        startTimer = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= startTimer + coolDownTimer)
        {
            startTimer = Time.time;
            SpawnDir();
            SpawnProjectile();
        }
    }

    void SpawnProjectile()
    {
        GO = Instantiate(spawnGO, transform.position, transform.rotation);
        script = GO.GetComponent<FireBall>();
        script.SetFireBall(Random.Range(speed.x,speed.y), damage, overTimeFly);
    }
    void SpawnDir()
    {
        transform.rotation = Quaternion.Euler(0,0,Random.Range(45,135));
    }
}
