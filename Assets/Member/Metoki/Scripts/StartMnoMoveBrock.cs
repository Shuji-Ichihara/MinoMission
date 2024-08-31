using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMnoMoveBrock : MonoBehaviour
{
    public float targetY = -5f;  // 停止位置のY座標
    public float speed = 1f;     // オブジェクトが下に移動する速度

    private bool isMoving = true;

    void Update()
    {
        // オブジェクトが移動中で、現在位置が目標位置よりも上の場合
        if (isMoving && transform.position.y > targetY)
        {
            // 下方向にゆっくり移動する
            transform.position += Vector3.down * speed * Time.deltaTime;
        }
        else if (isMoving)
        {
            // 移動を止め、UIテキストを表示する
            isMoving = false;
        }
    }
}
