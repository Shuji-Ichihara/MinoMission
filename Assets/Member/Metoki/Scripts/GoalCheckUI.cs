using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalCheckUI : MonoBehaviour
{
    public GameStartController gameStartController;
    public Text initialUI; // 最初に表示するUI
    public Text readyGoText;     // "READY GO"テキストを表示するUI
    public Text ClearText; // 最初に表示するUI
    public GoalCheck goalCheck;

    void Start()
    {
        // 初期のUIを表示
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
