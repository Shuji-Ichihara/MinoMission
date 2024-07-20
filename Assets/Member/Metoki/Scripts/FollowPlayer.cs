using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private bool isFollowing = false;
    private Transform playerTransform;
    public Vector3 offset = new Vector3(0, -1, 0);  // プレイヤーの少し下あたりに追従させるためのオフセット

    public void ToggleFollow()
    {
        isFollowing = !isFollowing;
        if (isFollowing && playerTransform == null)
        {
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    void Update()
    {
        if (isFollowing && playerTransform != null)
        {
            transform.position = playerTransform.position + offset;
            // プレイヤーの回転を追従
            transform.rotation = Quaternion.Euler(playerTransform.eulerAngles);
        }
    }
}
