using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntrinsicNightBorne : MonoBehaviour
{
    [SerializeField] private GameObject spawnGo;
    [SerializeField] private float pointY;
    [SerializeField] private float damage;
    [SerializeField] private float cooldownTimer;
    [SerializeField] private Vector2 randomAmountBolt;
    private float amountOfBolt;
    private float startTimer;
    private GameObject GO;
    private Bolt script;
    private Transform cam;
    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
        cam = GameObject.Find("Main Camera").transform;
        startTimer = Time.time;
        amountOfBolt = Random.Range(randomAmountBolt.x, randomAmountBolt.y);
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= startTimer + cooldownTimer)
        {
            startTimer = Time.time;
            Spawn();
        }
    }

    public void Spawn()
    {
        if(amountOfBolt > 0)
        {
            amountOfBolt--;
            GO = Instantiate(spawnGo, new Vector3(Random.Range(cam.position.x + 12, cam.position.x - 12), transform.parent.position.y + pointY, 0), Quaternion.identity);
        }
        else if(amountOfBolt <= 0 & player != null)
        {
            amountOfBolt = Random.Range(randomAmountBolt.x, randomAmountBolt.y);
            GO = Instantiate(spawnGo, new Vector3(player.transform.position.x, transform.parent.position.y + pointY, 0), Quaternion.identity);
        }
        script = GO.GetComponent<Bolt>();
        script.CreateSpells(damage);
    }
}
