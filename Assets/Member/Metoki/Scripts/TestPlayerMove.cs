using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerMove : MonoBehaviour
{

    private GameObject followingMino = null; // 現在追従しているminoタグ付きオブジェクト

    // 追従させるオブジェクトを格納する変数
    [SerializeField]
    private GameObject followObject;

    public float moveDistance = 1f; // 移動する距離
    private bool isMoving = false; // 現在移動中かどうか
    private bool isRotating = false; // 現在回転中かどうか

    void Update()
    {
        // キー入力による移動処理
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

        // キー入力による回転処理
        if (Input.GetKeyDown(KeyCode.R) && !isMoving && !isRotating)
        {
            Rotate();
        }

        // キー入力による回転処理
        if (Input.GetKeyDown(KeyCode.T) && !isMoving && !isRotating)
        {
            ReverseRotate();
        }

        // Pキーが押されたとき
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (followObject != null)
            {
                // 追従フラグをトグルする
                followObject.GetComponent<FollowPlayer>().ToggleFollow();
            }
        }
    }


    void Move(Vector3 direction)
    {
        isMoving = true; // 移動開始
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
        isMoving = false; // 移動完了
    }

    void Rotate()
    {
        isRotating = true; // 回転開始
        Vector3 targetEulerAngles = transform.eulerAngles + new Vector3(0, 0, 90); // Y軸周りに90度回転

        StartCoroutine(SmoothRotate(transform.eulerAngles, targetEulerAngles, 0.5f));
    }

    void ReverseRotate()
    {
        isRotating = true; // 回転開始
        Vector3 targetEulerAngles = transform.eulerAngles + new Vector3(0, 0, -90); // Y軸周りに90度回転

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
        isRotating = false; // 回転完了
    }
    // 追従させるオブジェクトが接触したとき
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Mino"))
        {
            followObject = other.gameObject;
        }
    }

    // 追従させるオブジェクトが離れたとき
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Mino"))
        {
            followObject = null;
        }
    }
}
