using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectMove : MonoBehaviour
{
    public float targetY = -5f;  // 停止位置のY座標
    public float speed = 1f;     // オブジェクトが下に移動する速度
    public Text uiText;          // 表示させたいUIテキスト

    private bool isMoving = true;

    void Start()
    {
        // 最初はUIテキストを非表示にする
        if (uiText != null)
        {
            uiText.gameObject.SetActive(false);
        }
    }

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
            if (uiText != null)
            {
                uiText.gameObject.SetActive(true);
            }
        }
    }
}
