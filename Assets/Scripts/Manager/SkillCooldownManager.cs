using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillCooldownManager : MonoBehaviour
{
    [SerializeField] private Image backGround;
    [SerializeField] private int levelToUnlock;
    [SerializeField] private TextMeshProUGUI text;
    private float cooldownTimer;
    private float currentTimer;
    private bool isUnlock;

    private void Start()
    {
        text.SetText(levelToUnlock.ToString());
    }

    private void Update()
    {
        if(GameManager.instance.level >= levelToUnlock && !isUnlock)
        {
            isUnlock = true;
            backGround.gameObject.SetActive(false);
            text.gameObject.SetActive(false);
        }
    }
    // Update is called once per frame
    public void SkillCooldown(float timer)
    {
        backGround.gameObject.SetActive(true);
        cooldownTimer = timer;
        backGround.fillAmount = 1;
        currentTimer = timer;
        StartCoroutine(CheckCooldown());

    }

    IEnumerator CheckCooldown()
    {
        yield return new WaitForSeconds(Time.deltaTime);
        currentTimer -= Time.deltaTime;
        backGround.fillAmount = currentTimer/cooldownTimer;
        if(currentTimer > 0)
        {
            StartCoroutine(CheckCooldown());
        }
        else
        {
            backGround.gameObject.SetActive(false);
        }
    }
}
