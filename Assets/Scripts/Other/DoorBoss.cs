using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DoorBoss : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private GameObject boss;
    [SerializeField] private GameObject healthBar;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private CompositeCollider2D confiner;
    [SerializeField] private CinemachineConfiner2D confinerConfiner;
    [SerializeField] private GameObject transitionGO;
    [SerializeField] private Transform teleport;
    private Animator transitionAnim;
    private void Start()
    {
        transitionAnim = transitionGO.GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            StartCoroutine(Transition());
        }
    }
    IEnumerator Transition()
    {
        transitionGO.SetActive(true);
        yield return new WaitForSeconds(1);
        player.position = teleport.position;
        confinerConfiner.m_BoundingShape2D = confiner;
        boss.SetActive(true);
        healthBar.SetActive(true);
        text.SetText(boss.name);
        transitionAnim.SetBool("end", true);
        yield return new WaitForSeconds(1);
        transitionAnim.SetBool("end", false);
        transitionGO.SetActive(false);
    }
}
