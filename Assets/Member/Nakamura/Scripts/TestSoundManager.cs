using Cysharp.Threading.Tasks;
using UnityEngine;
using static SoundManager;


public class SoundTest : MonoBehaviour
{
    [SerializeField]
    private E_BGM _playBGM;


    void Update()
    {
        // Uを押したらBGMを再生
        if (Input.GetKeyDown(KeyCode.U))
        { 
            SoundManager.instance.PlayBGM(_playBGM,false);
        }
        // Iを押したらフェードアウト
        if (Input.GetKeyDown(KeyCode.I))
        {
            SoundManager.instance.FadeIOut(null,3).Forget();
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            SoundManager.instance.PlaySE(SoundManager.E_SE.SE01);
        }
            
    }
}
