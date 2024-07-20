using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private bool isFollowing = false;
    private Transform playerTransform;

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
            // プレイヤーの位置に追従
            transform.position = playerTransform.position;
        }
    }
}
