using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStartController : MonoBehaviour
{
    public Text initialUI; // 最初に表示するUI
    public Text readyGoText;     // "READY GO"テキストを表示するUI
    public float initialUIDuration = 2.0f; // 最初のUI表示時間

    void Start()
    {
        // 初期のUIを表示
        initialUI.enabled = true;
        readyGoText.gameObject.SetActive(false);

        // 2秒後に「READY GO」テキストを表示し、ゲーム開始
        Invoke("ShowReadyGo", initialUIDuration);
    }

    void ShowReadyGo()
    {
        // 最初のUIを非表示
        initialUI.enabled = false;

        // 「READY GO」テキストを表示
        StartCoroutine(ShowReadyGoText());
    }

    IEnumerator ShowReadyGoText()
    {
        readyGoText.gameObject.SetActive(true);

        readyGoText.text = "READY";
        yield return new WaitForSeconds(1.0f); // 1秒間表示

        readyGoText.text = "GO";
        yield return new WaitForSeconds(1.0f); // 1秒間表示

        readyGoText.gameObject.SetActive(false);

        // ゲームを開始する処理をここに追加
        StartGame();
    }

    void StartGame()
    {
        // ゲーム開始処理をここに記述
        Debug.Log("Game Started!");
    }
}
