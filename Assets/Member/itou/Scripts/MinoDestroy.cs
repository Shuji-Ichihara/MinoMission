using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinoDestroy : MonoBehaviour
{
    [SerializeField]
    ClearCheck clearCheck;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (clearCheck.Clear)
        {
            Destroy(this.gameObject);
        }
    }
}
