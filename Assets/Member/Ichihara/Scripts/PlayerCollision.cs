using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    // プレイヤーが現在触れているミノ
    private GameObject _holdMinoObj = null;
    public GameObject holdMinoObj => _holdMinoObj;

    private void OnCollisionStay2D(Collision2D other)
    {
        var minoObj = other.gameObject;
        Debug.LogError($"{minoObj.name}");
        if (minoObj.CompareTag("Mino") && _holdMinoObj == null)
        {
            _holdMinoObj = minoObj;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        var minoObj = other.gameObject;
        if (minoObj.CompareTag("Mino"))
        {
            _holdMinoObj = null;
        }
    }
}
