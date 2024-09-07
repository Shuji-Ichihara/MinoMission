using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UICotroller : MonoBehaviour
{
    [SerializeField]
    private SceneChange _sceneChange = null;

    /// <summary>
    /// タイトルからゲームシーンへの遷移
    /// </summary>
    public void ChangePlayScene()
    {
        if(SceneManager.GetActiveScene().name == _sceneChange.OnSceneName[0])
        {
            SceneManager.LoadScene(_sceneChange.OnSceneName[1]);
        }
    }

    /*
    private void StageSelect()
    {

    }
    */
}
