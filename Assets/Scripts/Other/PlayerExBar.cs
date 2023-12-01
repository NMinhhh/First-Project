using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerExBar : MonoBehaviour
{
    [SerializeField] private float increaseTime = 0.25f;
    [SerializeField] private TextMeshProUGUI levelText;
    private Player player;
    private Image img;
    private float timer;
    private float tager;
    // Start is called before the first frame update
    void Start()
    {
        img= GetComponent<Image>();
        levelText.SetText(GameManager.instance.level + "");
        tager = GameManager.instance.AmountEx();
        img.fillAmount = tager;
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    public void UpdateExBar(float ex)
    {
        GameManager.instance.UpdateEx(ex);
        tager = GameManager.instance.AmountEx();
        StartCoroutine(Ex());
    }

    private IEnumerator Ex()
    {
        timer = 0;
        float fillAmount = img.fillAmount;
        while (timer < increaseTime) 
        {
            timer += Time.deltaTime;
            img.fillAmount = Mathf.Lerp(fillAmount, tager, timer / increaseTime);
            if(img.fillAmount >= 1)
            {
                img.fillAmount = 0;
                if(GameManager.instance.AmountEx() > 0)
                {
                    tager = GameManager.instance.AmountEx();
                    StartCoroutine(Ex());
                }
                levelText.SetText(GameManager.instance.level + "");
                player.LevelUp();
            }
            yield return null;
        }

    }
}
