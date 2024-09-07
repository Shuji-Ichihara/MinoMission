using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[DisallowMultipleComponent]
public class SceneChange : MonoBehaviour
{
    // 市原追記
    public List<string> OnSceneName => SceneName;
    [SerializeField] List<string> SceneName = new List<string>();
    GameObject ManageObject;
    // 市原追記
    public FadeScene FadeScene => FadeScene;
    FadeScene fadeSceneManager;
    GameObject _player;
    PlayerController _playercontroller;
    public bool Goal;
    [SerializeField]
    private int Playermoveoutcount;
    [SerializeField]
    GameObject senis;
    int ChangeClick;
    // Start is called before the first frame update
    void Start()
    {
        //SceneFadeManagerがアタッチされているオブジェクトを取得
        ManageObject = GameObject.Find("SceneChangeObject");
        //オブジェクトの中のSceneFadeManagerを取得
        fadeSceneManager = ManageObject.GetComponent<FadeScene>();
        ChangeClick = 0;
        if(SceneManager.GetActiveScene().name == SceneName[2] || SceneManager.GetActiveScene().name == SceneName[3])
        {
            senis.SetActive(false);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (SceneManager.GetActiveScene().name == SceneName[2] && _player == null)
        {
            _player = GameObject.Find("PlayerController");
            _playercontroller = _player.GetComponent<PlayerController>();
        }
        else if (SceneManager.GetActiveScene().name == SceneName[2])
        {
            if (Goal == true && ChangeClick == 0)
            {
                ChangeClick++;
                senis.SetActive(true);
            }
            else if (_playercontroller._holdMinoCount >= Playermoveoutcount && ChangeClick == 0)
            {
                ChangeClick++;
                Go_to_Gameover();
            }
        }
        else if (SceneManager.GetActiveScene().name == SceneName[3])
        {
            if (Goal == true && ChangeClick == 0)
            {
                ChangeClick++;
                senis.SetActive(true);
            }
            else if (_playercontroller._holdMinoCount >= Playermoveoutcount && ChangeClick == 0)
            {
                ChangeClick++;
                Go_to_Gameover();
            }
        }
        */
        if (_playercontroller._gameOver)
        {
            Debug.Log("作動");
            ChangeClick++;
            Go_to_Gameover();
        }
    }


    public void Go_to_StageSelect()
    {
        if(ChangeClick == 0)
        {
            //SceneFadeManagerの中のフェードアウト開始関数を呼び出し
            fadeSceneManager.fadeOutStart(0, 0, 0, 0, SceneName[1]);
            ChangeClick = 1;
        }
    }
    public void Go_to_Stage1()
    {
        if (ChangeClick == 0)
        {
            //SceneFadeManagerの中のフェードアウト開始関数を呼び出し
            fadeSceneManager.fadeOutStart(0, 0, 0, 0, SceneName[2]);
            ChangeClick = 1;
        }
    }
    public void Go_to_Stage2()
    {
        if (ChangeClick == 0)
        {
            //SceneFadeManagerの中のフェードアウト開始関数を呼び出し
            fadeSceneManager.fadeOutStart(0, 0, 0, 0, SceneName[3]);
            ChangeClick = 1;
        }
    }

    public void Go_to_Title()
    {
        if (ChangeClick == 0)
        {
            //SceneFadeManagerの中のフェードアウト開始関数を呼び出し
            fadeSceneManager.fadeOutStart(0, 0, 0, 0, SceneName[0]);
            ChangeClick = 1;
        }
    }

    public void Go_to_Result()
    {
        if (ChangeClick == 0)
        {
            //SceneFadeManagerの中のフェードアウト開始関数を呼び出し
            fadeSceneManager.fadeOutStart(0, 0, 0, 0, SceneName[4]);
            ChangeClick = 1;
        }
    }

    void Go_to_Gameover()
    {
        if (ChangeClick == 0)
        {
            //SceneFadeManagerの中のフェードアウト開始関数を呼び出し
            fadeSceneManager.fadeOutStart(0, 0, 0, 0, SceneName[5]);
            ChangeClick = 1;
        }
    }
}
