using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveLimt : MonoBehaviour
{
    // �v���C���[��������͈͂̐�����ݒ�
    public float minX = -5f;
    public float maxX = 5f;
    public float minY = -5f;
    public float maxY = 5f;

    void Update()
    {
        // �v���C���[�̌��݈ʒu���擾
        Vector3 currentPosition = transform.position;

        // X���͈͓̔��Ɉʒu�𐧌�
        currentPosition.x = Mathf.Clamp(currentPosition.x, minX, maxX);

        // Y���͈͓̔��Ɉʒu�𐧌�
        currentPosition.y = Mathf.Clamp(currentPosition.y, minY, maxY);

        // �ʒu���X�V
        transform.position = currentPosition;
    }
}
