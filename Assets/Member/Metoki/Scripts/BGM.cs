using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SoundManager.instance.PlayBGM(SoundManager.E_BGM.BGM01);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}