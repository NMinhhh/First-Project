using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using static Cinemachine.DocumentationSortingAttribute;

public class InfoPlayer : MonoBehaviour
{
    [SerializeField] private WeaponsData weaponData;
    [SerializeField] private PlayerData playerData;

    [SerializeField] private GameObject lockUpgradeAttack;
    [SerializeField] private GameObject lockUpgradeDefense;
    [SerializeField] private GameObject lockUpgradeHealth;

    [Header("Info")]
    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField] private TextMeshProUGUI exText;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI damageText;
    [SerializeField] private TextMeshProUGUI defenseText;
    [SerializeField] private TextMeshProUGUI healthText;

    [Header("Upgrade Damage")]
    [SerializeField] private TextMeshProUGUI levelSwordText;
    [SerializeField] private TextMeshProUGUI amountDamageCurrent;
    [SerializeField] private TextMeshProUGUI amountDamageNext;
    [SerializeField] private TextMeshProUGUI priceAttack;    

    [Header("Upgrade Defense")]
    [SerializeField] private TextMeshProUGUI levelDefenseText;
    [SerializeField] private TextMeshProUGUI amountDefenseCurrent;
    [SerializeField] private TextMeshProUGUI amountDefenseNext;
    [SerializeField] private TextMeshProUGUI priceDefense;    

    [Header("Upgrade Health")]
    [SerializeField] private TextMeshProUGUI levelHealthText;
    [SerializeField] private TextMeshProUGUI amountHealthCurrent;
    [SerializeField] private TextMeshProUGUI amountHealthNext;
    [SerializeField] private TextMeshProUGUI priceHealth;

    [Header("Audio")]
    [SerializeField] private AudioClip buy;
    private void Awake()
    {
        SetInfo();
        SetInfoAttack();
        SetInfoDefense();
        SetInfoHealth();
    }
    private void Update()
    {
        CheckUnlock(weaponData.levelAttack, lockUpgradeAttack,weaponData.priceDamage);
        CheckUnlock(weaponData.levelDefense, lockUpgradeDefense,weaponData.priceDefense);
        CheckUnlock(weaponData.levelHealth, lockUpgradeHealth,weaponData.priceHealth);
    }

    void CheckUnlock(float level,GameObject lockBG,float price)
    {
        if(level <= GameManager.instance.level && price <= GameManager.instance.coin)
        {
            lockBG.SetActive(false);
        }
        else
        {
            lockBG.SetActive(true);
        }
    }

    void SetInfo()
    {
        coinText.SetText("" + GameManager.instance.coin);
        exText.SetText("Ex:" + (int)GameManager.instance.currentEx + "/" + GameManager.instance.maxEx);
        levelText.SetText("Lv:" + GameManager.instance.level);
    }


    public void SetInfoAttack()
    {
        string level = weaponData.levelAttack.ToString();
        string amount = weaponData.amountAttack.ToString();
        string index = weaponData.indexDamage.ToString();
        string price = weaponData.priceDamage.ToString(); 
        damageText.SetText((playerData.attackDamage + weaponData.amountAttack).ToString());
        levelSwordText.SetText(level);
        amountDamageCurrent.SetText("+" + amount);
        amountDamageNext.SetText("+" + index);
        priceAttack.SetText(price);
        coinText.SetText("" + GameManager.instance.coin);
        
    }
    public void UpgradeAttack()
    {
        SoundFXManager.Instance.CreateAudio(buy, priceAttack.gameObject.transform, 1);
        weaponData.levelAttack += 1;
        GameManager.instance.DecreaseCoin((int)weaponData.priceDamage);
        weaponData.amountAttack += weaponData.indexDamage;
        weaponData.indexDamage += 1;
        weaponData.priceDamage = weaponData.priceDamage + (int)(weaponData.priceDamage * 0.3f);
        string s = "";
        s += weaponData.levelAttack.ToString() + "|";
        s += weaponData.amountAttack.ToString() + "|";
        s += weaponData.indexDamage.ToString() + "|";
        s += weaponData.priceDamage.ToString();
        PlayerPrefs.SetString("SaveSword", s);
        SetInfoAttack();
    }

    public void SetInfoDefense()
    {
        string level = weaponData.levelDefense.ToString();
        string amount = weaponData.amountDefense.ToString();
        string index = weaponData.indexDefense.ToString();
        string price = weaponData.priceDefense.ToString();
        defenseText.SetText((playerData.defense + weaponData.amountDefense).ToString());
        levelDefenseText.SetText(level);
        amountDefenseCurrent.SetText("+" + amount);
        amountDefenseNext.SetText("+" + index);
        priceDefense.SetText(price);
        coinText.SetText("" + GameManager.instance.coin);
    }

    public void UpgradeDefense()
    {
        SoundFXManager.Instance.CreateAudio(buy, priceDefense.gameObject.transform, 1);
        weaponData.levelDefense += 1;
        GameManager.instance.DecreaseCoin((int)weaponData.priceDefense);
        weaponData.amountDefense += weaponData.indexDefense;
        weaponData.indexDefense += 1;
        weaponData.priceDefense = weaponData.priceDefense + (int)(weaponData.priceDefense * 0.3f);
        string s = "";
        s += weaponData.levelDefense.ToString() + "|";
        s += weaponData.amountDefense.ToString() + "|";
        s += weaponData.indexDefense.ToString() + "|";
        s += weaponData.priceDefense.ToString();
        PlayerPrefs.SetString("SaveDefense", s);
        SetInfoDefense();
    }

    public void SetInfoHealth()
    {
        string level = weaponData.levelHealth.ToString();
        string amount = weaponData.amountHelth.ToString();
        string index = weaponData.indexHealth.ToString();
        string price = weaponData.priceHealth.ToString();
        healthText.SetText((playerData.maxHealth + weaponData.amountHelth).ToString());
        levelHealthText.SetText(level);
        amountHealthCurrent.SetText("+" + amount);
        amountHealthNext.SetText("+" + index);
        priceHealth.SetText(price);
        coinText.SetText("" + GameManager.instance.coin);
    }
     
    
    public void UpgradeHealth()
    {
        SoundFXManager.Instance.CreateAudio(buy, priceHealth.gameObject.transform, 1);
        weaponData.levelHealth += 1;
        GameManager.instance.DecreaseCoin((int)weaponData.priceHealth);
        weaponData.amountHelth += weaponData.indexHealth;
        weaponData.indexHealth += 50;
        weaponData.priceHealth = weaponData.priceHealth + (int)(weaponData.priceHealth * 0.3f);
        string s = "";
        s += weaponData.levelHealth.ToString() + "|";
        s += weaponData.amountHelth.ToString() + "|";
        s += weaponData.indexHealth.ToString() + "|";
        s += weaponData.priceHealth.ToString();
        PlayerPrefs.SetString("SaveHealth", s);
        SetInfoHealth();
    }




    // Update is called once per frame
    
}
