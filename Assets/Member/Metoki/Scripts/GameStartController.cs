using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStartController : MonoBehaviour
{
    public Text initialUI; // �ŏ��ɕ\������UI
    public Text readyGoText;     // "READY GO"�e�L�X�g��\������UI
    public float initialUIDuration = 2.0f; // �ŏ���UI�\������

    void Start()
    {
        // ������UI��\��
        initialUI.enabled = true;
        readyGoText.gameObject.SetActive(false);

        // 2�b��ɁuREADY GO�v�e�L�X�g��\�����A�Q�[���J�n
        Invoke("ShowReadyGo", initialUIDuration);
    }

    void ShowReadyGo()
    {
        // �ŏ���UI���\��
        initialUI.enabled = false;

        // �uREADY GO�v�e�L�X�g��\��
        StartCoroutine(ShowReadyGoText());
    }

    IEnumerator ShowReadyGoText()
    {
        readyGoText.gameObject.SetActive(true);

        readyGoText.text = "READY";
        yield return new WaitForSeconds(1.0f); // 1�b�ԕ\��

        readyGoText.text = "GO";
        yield return new WaitForSeconds(1.0f); // 1�b�ԕ\��

        readyGoText.gameObject.SetActive(false);

        // �Q�[�����J�n���鏈���������ɒǉ�
        StartGame();
    }

    void StartGame()
    {
        // �Q�[���J�n�����������ɋL�q
        Debug.Log("Game Started!");
    }
}
