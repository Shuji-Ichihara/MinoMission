using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurtrialImage : MonoBehaviour
{
    [SerializeField]
    private Image turtrialImage;
    [SerializeField]
    private Image turtrialBackImage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space))
        {
            turtrialBackImage.enabled = true;
            turtrialImage.enabled = true;
        }

        if(Input.GetKeyUp(KeyCode.Escape))
        {
            turtrialBackImage.enabled = false;
            turtrialImage.enabled = false;
        }
    }
}
