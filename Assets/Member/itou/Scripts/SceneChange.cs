using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[DisallowMultipleComponent]
public class SceneChange : MonoBehaviour
{
    [SerializeField] List<string> SceneName = new List<string>();
    GameObject ManageObject;
    FadeScene fadeSceneManager;
    GameObject _player;
    PlayerController _playercontroller;
    public bool Goal;
    [SerializeField]
    private int Playermoveoutcount;
    int ChangeClick;
    // Start is called before the first frame update
    void Start()
    {
        //SceneFadeManager���A�^�b�`����Ă���I�u�W�F�N�g���擾
        ManageObject = GameObject.Find("SceneChangeObject");
        //�I�u�W�F�N�g�̒���SceneFadeManager���擾
        fadeSceneManager = ManageObject.GetComponent<FadeScene>();
        ChangeClick = 0;
        if (SceneManager.GetActiveScene().name == SceneName[1])
        {
            _player = GameObject.Find("PlayerController");
            _playercontroller =_player.GetComponent<PlayerController>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name != SceneName[1])
        {
            if (Input.GetKeyDown(KeyCode.Space) && ChangeClick == 0)
            {
                ChangeClick++;
                //SceneFadeManager���A�^�b�`����Ă���I�u�W�F�N�g���擾
                ManageObject = GameObject.Find("SceneChangeObject");
                //�I�u�W�F�N�g�̒���SceneFadeManager���擾
                fadeSceneManager = ManageObject.GetComponent<FadeScene>();
                SceneChanges();
            }
        }
        else
        {
            if (Goal == true && ChangeClick == 0)
            {
                ChangeClick++;
                SceneChanges();
            }
            else if(_playercontroller.HoldMinoCount > Playermoveoutcount && ChangeClick == 0)
            {
                ChangeClick++;
                SceneChanges();
            }
        }
    }

    public void SceneChanges()
    {
        if (SceneManager.GetActiveScene().name == SceneName[1])
        {
            if (Goal == true)
            {
                //SceneFadeManager�̒��̃t�F�[�h�A�E�g�J�n�֐����Ăяo��
                fadeSceneManager.fadeOutStart(0, 0, 0, 0, SceneName[2]);
                Goal = false;
            }
            else if(_playercontroller.HoldMinoCount > Playermoveoutcount)
            {
                fadeSceneManager.fadeOutStart(0, 0, 0, 0, SceneName[3]);
            }
        }
        else if (SceneManager.GetActiveScene().name == SceneName[0])
        {
            //SceneFadeManager�̒��̃t�F�[�h�A�E�g�J�n�֐����Ăяo��
            fadeSceneManager.fadeOutStart(0, 0, 0, 0, SceneName[1]);
        }
        else if (SceneManager.GetActiveScene().name == SceneName[2])
        {
            //SceneFadeManager�̒��̃t�F�[�h�A�E�g�J�n�֐����Ăяo��
            fadeSceneManager.fadeOutStart(0, 0, 0, 0, SceneName[0]);
            fadeSceneManager.Destorycount += 1;
        }
        else if (SceneManager.GetActiveScene().name == SceneName[3])
        {
            //SceneFadeManager�̒��̃t�F�[�h�A�E�g�J�n�֐����Ăяo��
            fadeSceneManager.fadeOutStart(0, 0, 0, 0, SceneName[0]);
            fadeSceneManager.Destorycount += 1;
        }
    }
}
