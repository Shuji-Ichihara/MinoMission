using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalCheck : MonoBehaviour
{
    [SerializeField]
    BoxCollider2D _Goal;
    [SerializeField]
    Image _goallockimage;
    public bool _MissionClear;
    // Start is called before the first frame update
    void Start()
    {
        _Goal.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_MissionClear)
        {
            Destroy(_goallockimage);
            _Goal.enabled = true;
        }
    }
}
