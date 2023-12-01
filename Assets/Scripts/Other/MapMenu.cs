using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapMenu : MonoBehaviour
{
    [SerializeField] private Button[] buttons;
    // Start is called before the first frame update
    void Start()
    {
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);
        for(int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
            Image img = buttons[i].transform.Find("Gate").GetComponent<Image>();
            img.color = new Color(0, 0, 0, 1);
        }
        for(int i = 0; i< unlockedLevel; i++)
        {
            buttons[i].interactable = true;
            Image img = buttons[i].transform.Find("Gate").GetComponent<Image>();
            img.color = new Color(1, 0.4685534f, 0.4685534f, 1);

        }
    }
    
    public void LoadLevel(string levelName)
    {
        Loading.Instance.LoadScene(levelName);
    }
}
