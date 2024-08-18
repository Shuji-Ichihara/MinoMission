using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerController))]
public class PlayerInputAction : MonoBehaviour
{
    private MinoMission _inputMinoMission = null;

    private PlayerController _controller = null;

    #region InputSystem の入力値を受け取る変数
    // プレイヤーの移動の値の大きさ
    private Vector2 _movePlayerBase = Vector2.zero;
    // ミノを掴む、離す状態を管理
    private bool _isHolding = false;
    // プレイヤーの回転角度
    private float _rotatePlayerBase = 90f;
    #endregion

    private void Awake()
    {
        _inputMinoMission = new MinoMission();
        _controller = GetComponent<PlayerController>();
        // InputSystem のコールバック関数を追加
        _inputMinoMission.Player.Move.started += OnMovePlayer;
        _inputMinoMission.Player.Move.performed += OnMovePlayer;
        _inputMinoMission.Player.Move.canceled += OnMovePlayer;
        _inputMinoMission.Player.HoldAndRelease.performed += OnHoldAndReleaseMinoBlock;
        _inputMinoMission.Player.PlayerRotateLeft.performed += OnPlayerRotationLeft;
        _inputMinoMission.Player.PlayerRotateRight.performed += OnPlayerRotationRight;
        _inputMinoMission.Player.MinoRotateLeft.performed += OnMinoBlockRotationLeft;
        _inputMinoMission.Player.MinoRotateRight.performed += OnMinoBlockRotationRight;
        // InputSystem 有効化
        _inputMinoMission.Enable();
        _inputMinoMission.Player.Enable();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    private void FixedUpdate()
    {
        _controller.MovePlayer(_movePlayerBase);
    }

    #region InputSystem のコールバック関数群
    private void OnMovePlayer(InputAction.CallbackContext context)
    {
        _movePlayerBase = context.ReadValue<Vector2>();
    }

    private void OnHoldAndReleaseMinoBlock(InputAction.CallbackContext context)
    {
        if (_isHolding == false)
        {
            _isHolding = context.ReadValueAsButton();
            _controller.HoldMinoBlock();
        }
        else if (_isHolding == true)
        {
            _isHolding = !context.ReadValueAsButton();
            _controller.ReleaseMinoBlock();
        }
    }

    private void OnPlayerRotationLeft(InputAction.CallbackContext context)
    {
        _controller.RotatePlayer(_rotatePlayerBase);
    }

    private void OnPlayerRotationRight(InputAction.CallbackContext context)
    {
        _controller.RotatePlayer(-_rotatePlayerBase);
    }

    private void OnMinoBlockRotationLeft(InputAction.CallbackContext context)
    {
        _controller.RotateMinoBlock(_rotatePlayerBase);
    }

    private void OnMinoBlockRotationRight(InputAction.CallbackContext context)
    {
        _controller.RotateMinoBlock(_rotatePlayerBase);
    }


    #endregion

    #region InputSystem の有効化、無効化
    private void OnEnable()
    {
        _inputMinoMission.Enable();
    }

    private void OnDisable()
    {
        _inputMinoMission.Disable();
    }

    private void OnDestroy()
    {
        _inputMinoMission.Player.Move.performed -= OnMovePlayer;
        _inputMinoMission?.Dispose();
    }
    #endregion
}
