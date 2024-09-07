using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverObjectController : MonoBehaviour
{
    public float delayTime = 4f; // 4�b�̒x��
    public Vector3 rotationAngle = new Vector3(15f, 0f, 0f); // �X����p�x

    void Start()
    {
        StartCoroutine(RotateAfterDelayCoroutine());
    }

    IEnumerator RotateAfterDelayCoroutine()
    {
        // 4�b�ҋ@
        yield return new WaitForSeconds(delayTime);

        // �I�u�W�F�N�g�������X����
        transform.Rotate(rotationAngle);
    }
}
