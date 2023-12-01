using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePopupManager : MonoBehaviour
{
    public static DamagePopupManager Instance { get; private set; }

    [SerializeField] private GameObject damagePopupGO;
    private DamagePopup damagePopup;

    private void Start()
    {
        if(Instance == null)
            Instance = this;
    }

    public void Create(Transform transform, string damage, float attackDir)
    {
        GameObject gameObject = Instantiate(damagePopupGO, transform.position ,Quaternion.identity);
        damagePopup = gameObject.GetComponent<DamagePopup>();
        damagePopup.SetDamage(damage,attackDir);
    }

    public void CreateHealing(Transform transform, string damage, float attackDir, Color color)
    {
        GameObject gameObject = Instantiate(damagePopupGO, transform.position, Quaternion.identity);
        damagePopup = gameObject.GetComponent<DamagePopup>();
        damagePopup.SetColor(color);
        damagePopup.SetDamage(damage, attackDir);
    }
}
