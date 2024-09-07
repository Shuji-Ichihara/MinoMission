using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCheck : MonoBehaviour
{
    public string targetTag = "Mino";  // 消去したいオブジェクトのタグ
    public int requiredBlockCount = 10; // 消去するために必要なブロックの数（必要に応じて調整）
    private List<GameObject> blocksInCollider = new List<GameObject>();
    public bool Clear;
    public bool Elimination_completed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Elimination_completed)
        {
            //Clear = true ;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Mino"))
        {
            Elimination_completed = false;
        }
        else
        {
            Elimination_completed = true;
        }
    }
    /*
    // コライダーに何かが入った時に呼ばれる
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            blocksInCollider.Add(other.gameObject);
            CheckAndDestroyBlocks();
        }
    }

    // コライダーから何かが出た時に呼ばれる
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            blocksInCollider.Remove(other.gameObject);
        }
    }

    // コライダー内のブロック数をチェックして、条件が満たされていたら全てのブロックを消去
    private void CheckAndDestroyBlocks()
    {
        if (blocksInCollider.Count >= requiredBlockCount)
        {
            foreach (GameObject Mino in blocksInCollider)
            {
                Destroy(Mino);
                Elimination_completed = true;
            }
            blocksInCollider.Clear();
        }
    }*/
}
