using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalCheckUI : MonoBehaviour
{
    public GameStartController gameStartController;
    public Text initialUI; // �ŏ��ɕ\������UI
    public Text readyGoText;     // "READY GO"�e�L�X�g��\������UI
    public Text ClearText; // �ŏ��ɕ\������UI
    public GoalCheck goalCheck;

    void Start()
    {
        // ������UI��\��
        initialUI.enabled = false;
        ClearText.enabled = false;
        readyGoText.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if(gameStartController.GameStart)
        {
            initialUI.enabled = true;
            readyGoText.gameObject.SetActive(true);
        }
        if(goalCheck._MissionClear)
        {
            readyGoText.gameObject.SetActive(false);
            ClearText.enabled = true;
        }
    }
}
