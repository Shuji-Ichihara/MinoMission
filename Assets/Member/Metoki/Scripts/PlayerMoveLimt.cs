using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveLimt : MonoBehaviour
{
    // プレイヤーが動ける範囲の制限を設定
    public float minX = -5f;
    public float maxX = 5f;
    public float minY = -5f;
    public float maxY = 5f;

    void Update()
    {
        // プレイヤーの現在位置を取得
        Vector3 currentPosition = transform.position;

        // X軸の範囲内に位置を制限
        currentPosition.x = Mathf.Clamp(currentPosition.x, minX, maxX);

        // Y軸の範囲内に位置を制限
        currentPosition.y = Mathf.Clamp(currentPosition.y, minY, maxY);

        // 位置を更新
        transform.position = currentPosition;
    }
}
