using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length;
    private float startPos;
    private GameObject cam;
    private GameObject cam2;
    [SerializeField] private float parallaxEffect;
    [SerializeField] private float y;
    void Start()
    {
        cam = GameObject.Find("PlayerCamera");
        cam2 = GameObject.Find("Main Camera");

        startPos = cam.transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
 
    }

    // Update is called once per frame
    void Update()
    {
        float temp = (cam.transform.position.x * (1 - parallaxEffect));
        float distance = (cam.transform.position.x * parallaxEffect);
        transform.position = new Vector3(startPos + distance, cam.transform.position.y + y, transform.position.z);

        if (temp > startPos + length)
        {
            startPos += length;
        }
        else if (temp < startPos - length)
        {
            startPos -= length;
        }
    }
}
