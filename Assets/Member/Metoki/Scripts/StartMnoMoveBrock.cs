using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMnoMoveBrock : MonoBehaviour
{
    public float targetY = -5f;  // ��~�ʒu��Y���W
    public float speed = 1f;     // �I�u�W�F�N�g�����Ɉړ����鑬�x

    private bool isMoving = true;

    void Update()
    {
        // �I�u�W�F�N�g���ړ����ŁA���݈ʒu���ڕW�ʒu������̏ꍇ
        if (isMoving && transform.position.y > targetY)
        {
            // �������ɂ������ړ�����
            transform.position += Vector3.down * speed * Time.deltaTime;
        }
        else if (isMoving)
        {
            // �ړ����~�߁AUI�e�L�X�g��\������
            isMoving = false;
        }
    }
}
