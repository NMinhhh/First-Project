using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : MonoBehaviour
{
    [SerializeField] private GameObject text;
    [SerializeField] private GameObject Map;
    [SerializeField] private LayerMask whatIsPlayer;
    private BoxCollider2D boxCollider;
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CheckPlayer())
        {
            text.SetActive(true);
            OpenMap();
        }
        else
        {
            text.SetActive(false);
        }
    }


    private void OpenMap()
    {
        if (InputManager.Instance.attackInput)
        {
            Map.SetActive(true);
        }
    }

    public bool CheckPlayer()
    {
        return Physics2D.OverlapBox(boxCollider.bounds.center, boxCollider.bounds.size, 0, whatIsPlayer);
    }
}
