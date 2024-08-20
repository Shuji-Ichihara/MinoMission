using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.Mathematics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private GameObject _playerObj = null;
    [SerializeField]
    private float _moveForce = 5f;
    [SerializeField]
    private float _duration = 0.5f;

    private PlayerCollision _playerCollision = null;

    private GameObject _holdMinoBlock = null;

    private Transform _playerObjTransform = null;

    public int HoldMinoCount => _holdMinoCount;
    private int _holdMinoCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (_playerObj == null)
            _playerObj = GameObject.Find("PlayerModel");
        if (_playerCollision == null)
            _playerCollision = transform.GetComponentInChildren<PlayerCollision>();
        if (_playerObjTransform == null)
            _playerObjTransform = _playerObj.transform;
    }

    /// <summary>
    /// プレイヤーの移動
    /// </summary>
    /// <param name="moveValue"></param>
    public void MovePlayer(Vector2 moveValue)
    {
        Debug.Log($" up = {_playerObjTransform.up}");
        Debug.Log($" right = {_playerObjTransform.right}");
        _playerObjTransform.position
            += new Vector3(moveValue.x, moveValue.y, 0f) * _moveForce * Time.deltaTime;
    }

    /// <summary>
    /// プレイヤーの方向転換
    /// </summary>
    /// <param name="angle"></param>
    public void RotatePlayer(float angle)
    {
        _playerObjTransform.Rotate(Vector3.forward * angle);
    }

    /// <summary>
    /// プレイヤーがミノを掴む関数
    /// </summary>
    public void HoldMinoBlock()
    {
        var minoBlock = _playerCollision.holdMinoObj;
        if (minoBlock == null) return;
        _holdMinoBlock = minoBlock.transform.parent.gameObject;
        // 子要素にすることで自然な形で追従しているように見える
        _holdMinoBlock.transform.SetParent(_playerObjTransform);
        // プレイヤーの向きに応じて自然にミノをくっつける
        if (Mathf.Abs(_playerObjTransform.up.y) >= 1f)
            _holdMinoBlock.transform.localPosition
                = Vector3.zero + _playerObjTransform.up * _playerObjTransform.localScale.y / 2f;
        else if (Mathf.Abs(_playerObjTransform.right.x) >= 1f)
            _holdMinoBlock.transform.localPosition
                = Vector3.zero + _playerObjTransform.right * _playerObjTransform.localScale.x / 2f;
        _holdMinoCount++;
    }

    /// <summary>
    /// プレイヤーがミノを話す関数
    /// </summary>
    public void ReleaseMinoBlock()
    {
        if (_holdMinoBlock == null) return;
        _holdMinoBlock.transform.SetParent(null);
        _holdMinoBlock = null;
    }

    /// <summary>
    /// プレイヤーの回転に応じて、ミノを回転させる関数
    /// </summary>
    /// <param name="angle"></param>
    public void RotateMinoBlock(float angle)
    {
        if (_holdMinoBlock == null) return;
        _holdMinoBlock.transform.rotation *= Quaternion.Euler(Vector3.forward * angle);
    }

    /// <summary>
    /// ミノを消す処理
    /// </summary>
    public void DeleteMinoBlcok()
    {
        // ここにミノを消す関数を追記する
    }

    /// <summary>
    /// ミノを最初の状態に戻す処理
    /// </summary>
    public void Restart()
    {
        // ここにミノを初期状態に戻す関数を追記する
    }
}
