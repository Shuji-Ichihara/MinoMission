using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[DisallowMultipleComponent]
public class FadeScene : MonoBehaviour
{
    //�t�F�[�h�A�E�g�A�t�F�[�h�C���̊J�n�A�����̊Ǘ�
    private bool FadeOut = false;
    private bool FadeIn = false;
    //�����x�̕ω����x
    public float fadeSpeed = 0.75f;
    //�t�F�[�h�̂��߂̉摜�擾
    [SerializeField]
    private Image fadeImage;
    //�摜�̐F�ⓧ���x�̒l�ݒ�
    float red, green, blue, alfa;
    //�V�[���J�ڂ̂��߂̌^
    string afterScene;
    public int Destorycount;
    void Start()
    {
        DontDestroyOnLoad(this);
        SetRGBA(0, 0, 0, 1);
        //�V�[���J�ڂ����������ۂɃt�F�[�h�C�����J�n����悤�ɐݒ�
        SceneManager.sceneLoaded += fadeInStart;
    }
    //�V�[���J�ڂ����������ۂɃt�F�[�h�C�����J�n����悤�ɐݒ�
    void fadeInStart(Scene scene, LoadSceneMode mode)
    {
        FadeIn = true;
    }
    /// <summary>
    /// �t�F�[�h�A�E�g�J�n���̉摜��RGBA�l�Ǝ��̃V�[�������w��
    /// </summary>
    /// <param name="red">�摜�̐Ԑ���</param>
    /// <param name="green">�摜�̗ΐ���</param>
    /// <param name="blue">�摜�̐���</param>
    /// <param name="alfa">�摜�̓����x</param>
    /// <param name="nextScene">�J�ڐ�̃V�[����</param>
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
            //�s�����x�����X�ɉ�����
            alfa -= fadeSpeed * Time.deltaTime;
            //�ύX���������x���摜�ɔ��f������֐����Ă�
            SetColor();
            if (alfa <= 0)
                FadeIn = false;
        }
        if (FadeOut == true)
        {
            //�s�����x�����X�ɏグ��
            alfa += fadeSpeed * Time.deltaTime;
            //�ύX���������x���摜�ɔ��f������֐����Ă�
            SetColor();
            if (alfa >= 1)
            {
                FadeOut = false;
                SceneManager.LoadScene(afterScene);
            }
        }
    }
    //�摜�ɐF��������֐�
    void SetColor()
    {
        fadeImage.color = new Color(red, green, blue, alfa);
    }
    //�F�̒l��ݒ肷�邽�߂̊֐�
    public void SetRGBA(int r, int g, int b, int a)
    {
        red = r;
        green = g;
        blue = b;
        alfa = a;
    }
}