using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverObjectController : MonoBehaviour
{
    public float delayTime = 4f; // 4•b‚Ì’x‰„
    public Vector3 rotationAngle = new Vector3(15f, 0f, 0f); // ŒX‚¯‚éŠp“x

    void Start()
    {
        StartCoroutine(RotateAfterDelayCoroutine());
    }

    IEnumerator RotateAfterDelayCoroutine()
    {
        // 4•b‘Ò‹@
        yield return new WaitForSeconds(delayTime);

        // ƒIƒuƒWƒFƒNƒg‚ğ­‚µŒX‚¯‚é
        transform.Rotate(rotationAngle);
    }
}
