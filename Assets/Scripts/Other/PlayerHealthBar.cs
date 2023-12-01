using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    [SerializeField] private float decreaseTimer = 0.25f;

    private Image img;
    private float timer;
    private float tager;
    // Start is called before the first frame update
    void Start()
    {
        tager = 1;
        img = GetComponent<Image>();
        img.fillAmount = 1;
    }

    public void UpdateHealth(float health, float maxHealth)
    {
        tager = health / maxHealth;
        StartCoroutine(Health());
    }

    IEnumerator Health()
    {
        timer = 0;
        float fillAmount = img.fillAmount;
        while(timer < decreaseTimer)
        {
            timer += Time.deltaTime;
            img.fillAmount = Mathf.Lerp(fillAmount, tager, timer/decreaseTimer);
            yield return null;
        }
    }
}
