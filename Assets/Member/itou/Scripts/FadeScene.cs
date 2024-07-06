using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[DisallowMultipleComponent]
public class FadeScene : MonoBehaviour
{
    //フェードアウト、フェードインの開始、完了の管理
    private bool FadeOut = false;
    private bool FadeIn = false;
    //透明度の変化速度
    public float fadeSpeed = 0.75f;
    //フェードのための画像取得
    [SerializeField]
    private Image fadeImage;
    //画像の色や透明度の値設定
    float red, green, blue, alfa;
    //シーン遷移のための型
    string afterScene;
    public int Destorycount;
    void Start()
    {
        DontDestroyOnLoad(this);
        SetRGBA(0, 0, 0, 1);
        //シーン遷移が完了した際にフェードインを開始するように設定
        SceneManager.sceneLoaded += fadeInStart;
    }
    //シーン遷移が完了した際にフェードインを開始するように設定
    void fadeInStart(Scene scene, LoadSceneMode mode)
    {
        FadeIn = true;
    }
    /// <summary>
    /// フェードアウト開始時の画像のRGBA値と次のシーン名を指定
    /// </summary>
    /// <param name="red">画像の赤成分</param>
    /// <param name="green">画像の緑成分</param>
    /// <param name="blue">画像の青成分</param>
    /// <param name="alfa">画像の透明度</param>
    /// <param name="nextScene">遷移先のシーン名</param>
    public void fadeOutStart(int red, int green, int blue, int alfa, string nextScene)
    {
        SetRGBA(red, green, blue, alfa);
        SetColor();
        FadeOut = true;
        afterScene = nextScene;
    }
    // Update is called once per frame
    void Update()
    {
        if (Destorycount == 1)
        {
            if (SceneManager.GetActiveScene().name == "Title")
            {
                Destroy(this.gameObject);
            }
        }
        if (FadeIn == true)
        {
            //不透明度を徐々に下げる
            alfa -= fadeSpeed * Time.deltaTime;
            //変更した透明度を画像に反映させる関数を呼ぶ
            SetColor();
            if (alfa <= 0)
                FadeIn = false;
        }
        if (FadeOut == true)
        {
            //不透明度を徐々に上げる
            alfa += fadeSpeed * Time.deltaTime;
            //変更した透明度を画像に反映させる関数を呼ぶ
            SetColor();
            if (alfa >= 1)
            {
                FadeOut = false;
                SceneManager.LoadScene(afterScene);
            }
        }
    }
    //画像に色を代入する関数
    void SetColor()
    {
        fadeImage.color = new Color(red, green, blue, alfa);
    }
    //色の値を設定するための関数
    public void SetRGBA(int r, int g, int b, int a)
    {
        red = r;
        green = g;
        blue = b;
        alfa = a;
    }
}