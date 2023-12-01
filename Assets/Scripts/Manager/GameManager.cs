using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private PlayerData playerData;
    [SerializeField] private GameObject canvas;
    [SerializeField] private WeaponsData weaponData;
    public int maxEx { get; private set; }
    public float currentEx { get; private set; }
    public int level { get; private set; }
    public int coin { get; private set; }
    
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        if (PlayerPrefs.HasKey("Level"))
        {
            level = PlayerPrefs.GetInt("Level");
        }
        else
        {
            level = 1;
        }
        if (PlayerPrefs.HasKey("Coin"))
        {
            this.coin = PlayerPrefs.GetInt("Coin");
        }
        if (PlayerPrefs.HasKey("Experience"))
        {
            currentEx = PlayerPrefs.GetFloat("Experience");
        }
        if (PlayerPrefs.HasKey("SaveSword"))
        {
            string[] data = PlayerPrefs.GetString("SaveSword").Split('|');
            weaponData.levelAttack = int.Parse(data[0]);
            weaponData.amountAttack = int.Parse(data[1]);
            weaponData.indexDamage = int.Parse(data[2]);
            weaponData.priceDamage = int.Parse(data[3]);
        }
        if (PlayerPrefs.HasKey("SaveDefense"))
        {
            string[] data = PlayerPrefs.GetString("SaveDefense").Split('|');
            weaponData.levelDefense = int.Parse(data[0]);
            weaponData.amountDefense = int.Parse(data[1]);
            weaponData.indexDefense = int.Parse(data[2]);
            weaponData.priceDefense = int.Parse(data[3]);
        }
        if (PlayerPrefs.HasKey("SaveHealth"))
        {
            string[] data = PlayerPrefs.GetString("SaveHealth").Split('|');
            weaponData.levelHealth = int.Parse(data[0]);
            weaponData.amountHelth = int.Parse(data[1]);
            weaponData.indexHealth = int.Parse(data[2]);
            weaponData.priceHealth = int.Parse(data[3]);
        }
        DontDestroyOnLoad(gameObject);
        maxEx = CalculateExperience();
        playerData.maxHealth = CalculateHealth();
        playerData.attackDamage = CalculateDamage();
        playerData.defense = CalculateDefense();

    }

    // Update is called once per frame
    void Update()
    {
        if(currentEx >= maxEx)
        {
            LevelUp();
        }
    }
    public float AmountEx()
    {
        return currentEx/maxEx;
    }
    public void UpdateEx(float ex)
    {
        currentEx += ex;
        PlayerPrefs.SetFloat("Experience", currentEx);
    }

    void LevelUp()
    {
        level++;
        currentEx = currentEx - maxEx;
        playerData.maxHealth = CalculateHealth();
        playerData.defense = CalculateDefense();
        SetDamage();
        maxEx = CalculateExperience();
        PlayerPrefs.SetInt("Level", level);
    }

    void SetDamage()
    {
        playerData.attackDamage = CalculateDamage();
        playerData.heavyAttackDamage = (int)(playerData.attackDamage + playerData.attackDamage * 0.4f);
        playerData.windSkillDamage = (int)(playerData.attackDamage + playerData.attackDamage * 0.5f);
        playerData.waterBlastdamage = (int)(playerData.attackDamage + playerData.attackDamage * 0.6f);
    }

    int CalculateExperience()
    {
        int amountOfExperience = 0;
        for(int level = 1; level <= this.level; level++)
        {
            amountOfExperience += Mathf.FloorToInt(level + 300 * Mathf.Pow(2, (float)level / 7));
        }
        return amountOfExperience/4;
    }

    int CalculateDamage()
    {
        int amountOfDamage = 0;
        for (int level = 1; level <= this.level; level++)
        {
            amountOfDamage = Mathf.FloorToInt(level + 65 * Mathf.Pow(2, (float)level / 7));
        }
        return amountOfDamage / 4;
    }

    int CalculateHealth()
    {
        int amountOfHealth = 0;
        for (int level = 1; level <= this.level; level++)
        {
            amountOfHealth += Mathf.FloorToInt(level + 400 * Mathf.Pow(2, (float)level / 7));
        }
        return amountOfHealth / 4;
    }

    int CalculateDefense()
    {
        int amountOfDefense = 15;
        for (int level = 1; level <= this.level; level++)
        {
            amountOfDefense += 2;
        }
        return amountOfDefense;
    }

    public void EncreaseCoin(int coin)
    {
        this.coin += coin;
        SaveCoin();
    }

    public void DecreaseCoin(int coin)
    {
        this.coin -= coin;
        SaveCoin();
    }

    void SaveCoin()
    {
        PlayerPrefs.SetInt("Coin",this.coin);
    }

    public void EnterGame()
    {
        canvas.SetActive(false);
    }
}
