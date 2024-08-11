using Cysharp.Threading.Tasks;
using UnityEngine;


public class SoundTest : MonoBehaviour
{
    void Update()
    {
        // Uを押したらBGMを再生
        if (Input.GetKeyDown(KeyCode.U))
        { 
            SoundManager.instance.PlayBGM(SoundManager.E_BGM.BGM01);
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
