using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapManager : MonoBehaviour
{
    [SerializeField] private int map;
    [SerializeField] private GameObject winCV;
    [SerializeField] private GameObject loseCV;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject doorBoss;
    [SerializeField] private GameObject transitionGO;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private List<GameObject> enemys;
    private Animator transitionAnim;
    private bool isWin;
    private bool isLose;
    // Start is called before the first frame update
    void Start()
    {
        transitionAnim = transitionGO.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if(CheckWin() <= 1 )
        {
            doorBoss.SetActive(true);
        }
        if (CheckWin() <= 0 && !isWin)
        {
            isWin = true;
            if (!PlayerPrefs.HasKey("Map" + map))
            {
                FinishLevel.instance.Finish(SceneManager.GetActiveScene().buildIndex);
                PlayerPrefs.SetString("Map" + map, "isfinish");
            }
            StartCoroutine(Transition(winCV));
        }
        if (player == null && !isLose)
        {
            isLose = true;
            StartCoroutine(Transition(loseCV));
        }
    }
    IEnumerator Transition(GameObject canvasGo)
    {
        transitionGO.SetActive(true);
        yield return new WaitForSeconds(1);
        CanvasManager.Instance.Open(canvasGo);
        transitionAnim.SetBool("end", true);
        yield return new WaitForSeconds(1);
        transitionAnim.SetBool("end", false);
        transitionGO.SetActive(false);
        Time.timeScale = 0;
    }
    public float CheckWin()
    {
        for(int i = 0; i < enemys.Count; i++)
        {
            if (enemys[i] == null)
            {
                enemys.Remove(enemys[i]);
            }
        }
        if(enemys.Count <= 0)
        {
            text.SetText(":" + enemys.Count);
        }
        else
        {
            text.SetText(":"+(enemys.Count - 1));
        }
        return enemys.Count;
    }
}
