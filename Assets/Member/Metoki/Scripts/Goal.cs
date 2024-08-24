using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public SceneChange sceneChange;
    // Start is called before the first frame update
    // 他のオブジェクトがトリガーに入ったときに呼ばれる
    private void OnTriggerEnter2D(Collider2D other)
    {
        // トリガーに入ったオブジェクトの名前を取得してログに表示
        Debug.Log("Triggered by: " + other.gameObject.name);

        // 特定のタグのオブジェクトがトリガーに入った場合の処理
        if (other.gameObject.CompareTag("Player"))
        {
            // ここに処理を書く
            sceneChange.Goal = true;
        }
    }
    
}
