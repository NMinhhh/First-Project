using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextEffect : MonoBehaviour
{
    [SerializeField] private float timer;
    private TextMeshProUGUI text;
    private float startTimer;
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        startTimer = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if(startTimer < timer)
        {
            startTimer += Time.deltaTime;
            text.fontSize += .15f;
        }else if(startTimer > timer)
        {
            startTimer += Time.deltaTime;
            text.fontSize -= .15f;
            if (startTimer >= timer * 2)
            {
                startTimer = 0;
            }
        }
       
    }
}
