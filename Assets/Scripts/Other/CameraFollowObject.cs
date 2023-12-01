using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowObject : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float flipRotationTime;

    private Coroutine _turnCorotine;

    private Player player;

    private bool isFacingDir;
    void Awake()
    {
        player = playerTransform.GetComponent<Player>();
        isFacingDir = player.isFacingRight;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = playerTransform.position;
    }

    public void CallTurn()
    {
        StartCoroutine(FlipYLerp());
    }

    IEnumerator FlipYLerp()
    {
        float startRotation = playerTransform.localEulerAngles.y;
        float endRotationAmount = DetermineEndRotation();
        float yRotation = 0f;
        float eslapsedTime = 0f;
        while(eslapsedTime < flipRotationTime)
        {
            eslapsedTime+= Time.deltaTime;
            yRotation = Mathf.Lerp(startRotation, endRotationAmount, eslapsedTime/flipRotationTime);
            transform.rotation = Quaternion.Euler(0f,yRotation, 0f);
            yield return null;
        }

    }

    private float DetermineEndRotation()
    {
        isFacingDir = !isFacingDir;
        if(isFacingDir)
        {
            return 180;
        }
        else
        {
            return 0;
        }
    }
}
