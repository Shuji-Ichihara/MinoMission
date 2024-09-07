using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UICotroller : MonoBehaviour
{
    [SerializeField]
    private SceneChange _sceneChange = null;
    [SerializeField]
    private FadeScene _fadeScene = null;

    [SerializeField]
    private int _buttonCount = 2;
    private List<Button> _stageSelectButtons = new List<Button>();
    private Button _selectButton;

    //
    private bool _doOnce = false;

    private void Start()
    {
        if (_sceneChange == null)
            _sceneChange = GameObject.Find("SceneChangeManager").GetComponent<SceneChange>();
        if (_fadeScene == null)
            _fadeScene = GameObject.Find("SceneChangeObject").GetComponent<FadeScene>();
        string sceneName = SceneManager.GetActiveScene().name;
        if (sceneName.Contains("StageSelect"))
        {
            for (int i = 0; i < _buttonCount; i++)
            {
                var obj = FindObjectsOfType<Button>();
                _stageSelectButtons.Add(obj[i]);
            }
        }
    }

    /// <summary>
    /// 各シーンへの遷移
    /// </summary>
    public void ChangePlayScene()
    {
        string sceneName = SceneManager.GetActiveScene().name;

        if (sceneName.Contains("Title") && _doOnce == false)
        {
            _fadeScene.fadeOutStart(0, 0, 0, 0, _sceneChange.OnSceneName[1]);
            _doOnce = true;
        }
        else if (sceneName.Contains("StageSelect") && _doOnce == false)
        {
            // 選択されているボタンの処理呼び出し
            _selectButton?.onClick.Invoke();
        }
        else if (sceneName.Contains("Clear") || sceneName.Contains("Over") && _doOnce == false)
        {
            _fadeScene.fadeOutStart(0, 0, 0, 0, _sceneChange.OnSceneName[0]);
            _doOnce = true;
        }
    }

    /// <summary>
    /// ステージの遷移ボタンを選択する
    /// </summary>
    /// <param name="index">選択するボタン</param>
    public void SelectStage(int index)
    {
        _selectButton = _stageSelectButtons[index];
        _selectButton.Select();
        var image = _selectButton.image;
        image.color = Color.yellow;
    }

    public void ClearButtonColor(int index)
    {
        _stageSelectButtons[index].image.color = Color.white;
    }
}
