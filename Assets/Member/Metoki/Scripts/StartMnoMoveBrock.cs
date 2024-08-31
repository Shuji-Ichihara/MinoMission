using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMnoMoveBrock : MonoBehaviour
{
    [SerializeField]
    private Vector3 minoBrockPosition; //移動先の位置決定

    [SerializeField]
    private float delay = 3f;　//n秒後に移動を開始

    [SerializeField]
    private float durateion = 3f;

    private Vector3 startPosition;

    private bool isMoving = true;

    void Start()
    {
        startPosition = transform.position;
        StartCoroutine(MovePosition());
    }
    void Update()
    {

    }
    IEnumerator MovePosition()
    {
        yield return new WaitForSeconds(delay);

        float elapsedTime = 0;

        while(elapsedTime < durateion)
        {
            transform.position = Vector3.Lerp(startPosition,minoBrockPosition,elapsedTime / durateion);
            elapsedTime += Time.deltaTime;
            yield return null;

        }
        transform.position = minoBrockPosition;
    }
}
