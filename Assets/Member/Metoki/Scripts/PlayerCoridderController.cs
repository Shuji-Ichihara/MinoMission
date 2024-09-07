using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCoridderController : MonoBehaviour
{
    private Collider2D objectCollider;

    void Start()
    {
        // オブジェクトのコライダーを取得
        objectCollider = GetComponent<Collider2D>();

        // コライダーを無効化
        objectCollider.enabled = false;

        // 5秒後にコライダーを有効化する
        Invoke("EnableCollider", 4.5f);
    }

    void EnableCollider()
    {
        // コライダーを有効化
        objectCollider.enabled = true;
    }
}
