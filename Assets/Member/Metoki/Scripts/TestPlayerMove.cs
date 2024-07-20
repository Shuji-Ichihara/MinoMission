using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerMove : MonoBehaviour
{

    private GameObject followingMino = null; // ���ݒǏ]���Ă���mino�^�O�t���I�u�W�F�N�g

    // �Ǐ]������I�u�W�F�N�g���i�[����ϐ�
    [SerializeField]
    private GameObject followObject;

    public float moveDistance = 1f; // �ړ����鋗��
    private bool isMoving = false; // ���݈ړ������ǂ���
    private bool isRotating = false; // ���݉�]�����ǂ���

    void Update()
    {
        // �L�[���͂ɂ��ړ�����
        if (Input.GetKeyDown(KeyCode.A) && !isMoving && !isRotating)
        {
            Move(Vector3.left);
        }
        else if (Input.GetKeyDown(KeyCode.D) && !isMoving && !isRotating)
        {
            Move(Vector3.right);
        }
        else if (Input.GetKeyDown(KeyCode.W) && !isMoving && !isRotating)
        {
            Move(Vector3.up);
        }
        else if (Input.GetKeyDown(KeyCode.S) && !isMoving && !isRotating)
        {
            Move(Vector3.down);
        }

        // �L�[���͂ɂ���]����
        if (Input.GetKeyDown(KeyCode.R) && !isMoving && !isRotating)
        {
            Rotate();
        }

        // �L�[���͂ɂ���]����
        if (Input.GetKeyDown(KeyCode.T) && !isMoving && !isRotating)
        {
            ReverseRotate();
        }

        // P�L�[�������ꂽ�Ƃ�
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (followObject != null)
            {
                // �Ǐ]�t���O���g�O������
                followObject.GetComponent<FollowPlayer>().ToggleFollow();
            }
        }
    }


    void Move(Vector3 direction)
    {
        isMoving = true; // �ړ��J�n
        Vector3 targetPosition = transform.position + direction * moveDistance;

        StartCoroutine(SmoothMove(transform.position, targetPosition, 0.5f));
    }

    IEnumerator SmoothMove(Vector3 startPos, Vector3 endPos, float duration)
    {
        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(startPos, endPos, (elapsedTime / duration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = endPos;
        isMoving = false; // �ړ�����
    }

    void Rotate()
    {
        isRotating = true; // ��]�J�n
        Vector3 targetEulerAngles = transform.eulerAngles + new Vector3(0, 0, 90); // Y�������90�x��]

        StartCoroutine(SmoothRotate(transform.eulerAngles, targetEulerAngles, 0.5f));
    }

    void ReverseRotate()
    {
        isRotating = true; // ��]�J�n
        Vector3 targetEulerAngles = transform.eulerAngles + new Vector3(0, 0, -90); // Y�������90�x��]

        StartCoroutine(SmoothRotate(transform.eulerAngles, targetEulerAngles, 0.5f));
    }

    IEnumerator SmoothRotate(Vector3 startAngles, Vector3 endAngles, float duration)
    {
        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            transform.eulerAngles = Vector3.Lerp(startAngles, endAngles, (elapsedTime / duration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.eulerAngles = endAngles;
        isRotating = false; // ��]����
    }
    // �Ǐ]������I�u�W�F�N�g���ڐG�����Ƃ�
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Mino"))
        {
            followObject = other.gameObject;
        }
    }

    // �Ǐ]������I�u�W�F�N�g�����ꂽ�Ƃ�
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Mino"))
        {
            followObject = null;
        }
    }
}
