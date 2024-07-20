using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private bool isFollowing = false;
    private Transform playerTransform;
    public Vector3 offset = new Vector3(0, -1, 0);  // �v���C���[�̏�����������ɒǏ]�����邽�߂̃I�t�Z�b�g

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
            // �v���C���[�̉�]��Ǐ]
            transform.rotation = Quaternion.Euler(playerTransform.eulerAngles);
        }
    }
}
