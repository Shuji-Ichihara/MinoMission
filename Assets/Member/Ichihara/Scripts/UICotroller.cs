using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UICotroller : MonoBehaviour
{
    [SerializeField]
    private SceneChange _sceneChange = null;
    [SerializeField]
    private FadeScene _fadeScene = null;
    //
    private bool _doOnce = false;

    private void Start()
    {
        if (_sceneChange == null)
            _sceneChange = GameObject.Find("SceneChangeManager").GetComponent<SceneChange>();
        if(_fadeScene == null)
            _fadeScene = GameObject.Find("SceneChangeObject").GetComponent<FadeScene>();
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
        else if (sceneName.Contains("Clear") || sceneName.Contains("Over") && _doOnce == false)
        {
            _fadeScene.fadeOutStart(0, 0, 0, 0, _sceneChange.OnSceneName[0]);
            _doOnce= true;
        }
    }

    /*
    private void StageSelect()
    {

    }
    */
}
