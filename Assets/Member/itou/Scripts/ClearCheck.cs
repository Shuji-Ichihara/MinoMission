using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCheck : MonoBehaviour
{
    public bool Clear;
    bool Elimination_completed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Elimination_completed)
        {
            Clear = true ;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Mino"))
        {
            Elimination_completed = false;
        }
        else
        {
            Elimination_completed = true;
        }
    }
}
