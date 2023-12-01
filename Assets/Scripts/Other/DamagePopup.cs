using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamagePopup : MonoBehaviour
{
    private TextMesh text;
    [SerializeField] private Vector3 speed;
    [SerializeField] private float disappearTimerMax;
    private float disappearTimer;
    private float attackDir;
    private Color textColor;
    private void Awake()
    {
        text = GetComponent<TextMesh>();
    }
    public void SetDamage(string damage, float attackDir)
    {
        this.text.text = damage;
        textColor = text.color;
        disappearTimer = disappearTimerMax;
        this.attackDir = attackDir;
    }
    public void SetColor(Color color)
    {
        text.color = color;
    }
    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(speed.x * attackDir,speed.y,speed.z) * Time.deltaTime;
        disappearTimer -= Time.deltaTime;
        if (disappearTimer > disappearTimerMax * 0.5f)
        {
            float decrease = 1f;
            transform.localScale += Vector3.one * decrease * Time.deltaTime;
        }
        else
        {
            float encrease = 1f;
            transform.localScale -= Vector3.one * encrease * Time.deltaTime;
        }
        if (disappearTimer < 0)
        {
            textColor.a -= Time.deltaTime;
            text.color = textColor;     
        }
        if(text.color.a <= 0)
        {
            Destroy(gameObject);
        }
    }
}
