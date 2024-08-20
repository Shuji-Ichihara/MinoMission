using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectMove : MonoBehaviour
{
    public float targetY = -5f;  // ��~�ʒu��Y���W
    public float speed = 1f;     // �I�u�W�F�N�g�����Ɉړ����鑬�x
    public Text uiText;          // �\����������UI�e�L�X�g

    private bool isMoving = true;

    void Start()
    {
        // �ŏ���UI�e�L�X�g���\���ɂ���
        if (uiText != null)
        {
            uiText.gameObject.SetActive(false);
        }
    }

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
            if (uiText != null)
            {
                uiText.gameObject.SetActive(true);
            }
        }
    }
}
