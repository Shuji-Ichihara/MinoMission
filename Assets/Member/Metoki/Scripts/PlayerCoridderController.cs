using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCoridderController : MonoBehaviour
{
    private Collider2D objectCollider;

    void Start()
    {
        // �I�u�W�F�N�g�̃R���C�_�[���擾
        objectCollider = GetComponent<Collider2D>();

        // �R���C�_�[�𖳌���
        objectCollider.enabled = false;

        // 5�b��ɃR���C�_�[��L��������
        Invoke("EnableCollider", 4.5f);
    }

    void EnableCollider()
    {
        // �R���C�_�[��L����
        objectCollider.enabled = true;
    }
}
