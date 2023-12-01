using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    public static Loading Instance;
    [SerializeField] private GameObject loading;
    [SerializeField] private Image loadingBar;
    [SerializeField] private Image backGroundLoading;
    [SerializeField] private Sprite[] bg;
    private void Start()
    {
        
        if (!Instance)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadingSceneBar(sceneName));
    }

    IEnumerator LoadingSceneBar(string sceneName)
    {
        loadingBar.fillAmount = 0;
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);
        asyncOperation.allowSceneActivation = false;
        loading.SetActive(true);
        int i = Random.Range(0, bg.Length);
        backGroundLoading.sprite = bg[i];
        float progress = 0;
        while (!asyncOperation.isDone)
        {
            progress = Mathf.MoveTowards(progress , asyncOperation.progress, Time.deltaTime);
            loadingBar.fillAmount = progress;
            if(progress >= 0.9f)
            {
                loadingBar.fillAmount = 1;
                asyncOperation.allowSceneActivation = true;
            }
            yield return null;
        }

        loading.SetActive(false);
    }

}
