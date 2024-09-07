﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputUI : MonoBehaviour
{
    private MinoMission _inputAction = null;
    private UICotroller _controller = null;


    private void Awake()
    {
        _inputAction = new MinoMission();
        _controller = GetComponent<UICotroller>();
        // InputSystem有効化
        _inputAction.Enable();
        // UIのアクションマップを有効にする
        _inputAction.UI.Enable();
        _inputAction.UI.ToNextScene.performed += OnToNextScene;
        //_inputAction.UI.SelectStageUp.performed += OnStageSelectUp;
        //_inputAction.UI.SelectStageDown.performed += OnStageSelectDown;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    private void OnToNextScene(InputAction.CallbackContext context)
    {
        _controller.ChangePlayScene();
    }

    /*
    private void OnStageSelectUp(InputAction.CallbackContext context)
    {

    }

    private void OnStageSelectDown(InputAction.CallbackContext context)
    {

    }
    */
}
