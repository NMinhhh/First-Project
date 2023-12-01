using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager Instance;
    [SerializeField] private GameObject settingCV;
    private void Start()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    public void OPSetting()
    {
        PlaySound();
        if (settingCV.activeInHierarchy)
        {
            settingCV.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            settingCV.SetActive(true);
            Time.timeScale = 0;
        }

    }

    public void LoadScence(string scence)
    {
        PlaySound();
        Loading.Instance.LoadScene(scence);
        if(Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
    }

    public void CloseSetting()
    {
        PlaySound();
        settingCV.SetActive(false);
        Time.timeScale = 1;
    }

    public void Open(GameObject go)
    {
        PlaySound();
        go.SetActive(true);
    }
    public void PlaySound()
    {
        SoundFXManager.Instance.CreateAudio(SoundFXManager.Instance.GetAudio(4), gameObject.transform, 1);
    }
    public void Close(GameObject go)
    {
        PlaySound();
        go.SetActive(false);
    }
}
