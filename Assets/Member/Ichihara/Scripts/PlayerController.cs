using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Text minoCountText;  // Textコンポーネントへの参照
    // プレイヤーのスプライト画像
    [SerializeField]
    private GameObject _playerObj = null;
    // プレイヤーの移動速度
    [SerializeField]
    private float _moveForce = 5f;

    private PlayerCollision _playerCollision = null;

    private GameObject _holdMinoBlock = null;

    private Transform _playerObjTransform = null;

    public int HoldMinoCount => _holdMinoCount;
    public int _holdMinoCount = 30;
    public ClearCheck clearCheck;

    // 目時追記
    [SerializeField]
    private GameObject _armOne;
    [SerializeField]
    private GameObject _armTwo;
    [SerializeField]
    private GameObject _armThree;

    public bool _gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        if (_playerObj == null)
            _playerObj = GameObject.Find("PlayerModel");
        if (_playerCollision == null)
            _playerCollision = transform.GetChild(0).GetComponentInChildren<PlayerCollision>();
        if (_playerObjTransform == null)
            _playerObjTransform = _playerObj.transform;
    }

    /// <summary>
    /// プレイヤーの移動
    /// </summary>
    /// <param name="moveValue">プレイヤーの移動量</param>
    public void MovePlayer(Vector2 moveValue)
    {
#if UNITY_EDITOR
        Debug.Log($" up = {_playerObjTransform.up}");
        Debug.Log($" right = {_playerObjTransform.right}");
#endif
        _playerObjTransform.position
            += new Vector3(moveValue.x, moveValue.y, 0f) * _moveForce * Time.deltaTime;
    }

    /// <summary>
    /// プレイヤーの方向転換
    /// </summary>
    /// <param name="angle"></param>
    public void RotatePlayer(float angle)
    {
        _playerObjTransform.Rotate(Vector3.forward * angle);
    }

    /// <summary>
    /// プレイヤーがミノを掴む関数
    /// </summary>
    public void HoldMinoBlock()
    {
        var minoBlock = _playerCollision.holdMinoObj;
        if (minoBlock == null) return;
        _holdMinoBlock = minoBlock.transform.parent.gameObject;
        // 子要素にすることで自然な形で追従しているように見せる
        _holdMinoBlock.transform.SetParent(_playerObjTransform);
        // Iミノのみ別の処理をする
        string minoName = _holdMinoBlock.name;
        SwitchHoldMino(ref _holdMinoBlock, ref minoName);
        //
        _holdMinoCount--;
        // テキストを更新する
        UpdateMinoCountText();
        SoundManager.instance.PlaySE(SoundManager.E_SE.SE04);
    }

    /// <summary>
    /// プレイヤーがミノを離す関数
    /// </summary>
    public void ReleaseMinoBlock()
    {
        if (_holdMinoBlock == null) return;
        // オブジェクトの親子関係を解消し、プレイヤーの影響を受けないようにする
        _holdMinoBlock.transform.SetParent(null);
        _holdMinoBlock = null;
        SoundManager.instance.PlaySE(SoundManager.E_SE.SE03);
    }

    /// <summary>
    /// プレイヤーの回転に応じて、ミノを回転させる関数
    /// </summary>
    /// <param name="angle">回転する角度</param>
    public void RotateMinoBlock(float angle)
    {
        if (_holdMinoBlock == null) return;
        // ミノを回転
        Transform minoTransform = _holdMinoBlock.transform;
        minoTransform.rotation *= Quaternion.Euler(Vector3.forward * angle);
        // Iミノのみ別の処理をする
        string minoName = _holdMinoBlock.name;
        SwitchRotateMino(ref _holdMinoBlock, angle, minoName);


        SoundManager.instance.PlaySE(SoundManager.E_SE.SE01);
    }

    /// <summary>
    /// ミノを消す処理
    /// </summary>
    public void DeleteMinoBlcok()
    {
        // ここにミノを消す関数を追記する
        if(clearCheck.Elimination_completed)
        {
            clearCheck.Clear = true;
        }
        
    }

    /// <summary>
    /// ミノを最初の状態に戻す処理
    /// </summary>
    public void Restart()
    {
        // ここにミノを初期状態に戻す関数を追記する
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void SwitchHoldMino(ref GameObject minoObj, ref string minoName)
    {
        // Iミノとそれ以外で処理を分ける
        bool isMinoBlockI = minoName.StartsWith("block_I");
        // プレイヤーオブジェクトのz回転を取得し、180の余りを算出する
        // このゲームでは90°回転の為
        float dummyAngle = _playerObjTransform.eulerAngles.z;
        float playerAngle = Mathf.Abs(dummyAngle) % 180f;

        // プレイヤーの向きに応じて自然にミノをくっつける
        if (isMinoBlockI == true)
        {
            if (playerAngle == 0f)
            {
                // ミノの構成が横長である為、プレイヤーに対して水平である場合はプレイヤーとミノの中心座標の距離を短くする。
                if (_playerObjTransform.eulerAngles.z > 0f)
                    minoObj.transform.localPosition
                            = Vector3.zero - _playerObjTransform.up.normalized * _playerObjTransform.localScale.y;
                else if (_playerObjTransform.eulerAngles.z <= 0f)
                    minoObj.transform.localPosition
                            = Vector3.zero + _playerObjTransform.up.normalized * _playerObjTransform.localScale.y;
            }
            else if (playerAngle == 90f)
            {
                // プレイヤーに対して垂直である場合はプレイヤーとミノの中心座標の距離を長くする。
                if (_playerObjTransform.eulerAngles.z > 180f)
                    minoObj.transform.localPosition
                            = Vector3.zero - _playerObjTransform.right.normalized * _playerObjTransform.localScale.x * 2.5f;
                else if (_playerObjTransform.eulerAngles.z < 180f)
                    minoObj.transform.localPosition
                            = Vector3.zero + _playerObjTransform.right.normalized * _playerObjTransform.localScale.x * 2.5f;
            }
        }
        else if (isMinoBlockI == false)
        {
            if (playerAngle == 0f)
            {
                // ミノの構成が横長である為、プレイヤーに対して水平である場合はプレイヤーとミノの中心座標の距離を短くする。
                if (_playerObjTransform.eulerAngles.z > 0f)
                    minoObj.transform.localPosition
                            = Vector3.zero - _playerObjTransform.up.normalized * _playerObjTransform.localScale.y * 2f;
                else if (_playerObjTransform.eulerAngles.z <= 0f)
                    minoObj.transform.localPosition
                            = Vector3.zero + _playerObjTransform.up.normalized * _playerObjTransform.localScale.y * 2f;
            }
            else if (playerAngle == 90f)
            {
                // プレイヤーに対して垂直である場合はプレイヤーとミノの中心座標の距離を長くする。
                if (_playerObjTransform.eulerAngles.z > 180f)
                    minoObj.transform.localPosition
                            = Vector3.zero - _playerObjTransform.right.normalized * _playerObjTransform.localScale.x * 2f;
                else if (_playerObjTransform.eulerAngles.z < 180f)
                    minoObj.transform.localPosition
                            = Vector3.zero + _playerObjTransform.right.normalized * _playerObjTransform.localScale.x * 2f;
            }
        }
    }

    private void SwitchRotateMino(ref GameObject minoObj, float angle, string minoName)
    {
        // Iミノとそれ以外で処理を分ける
        bool isMinoBlockI = minoName.StartsWith("block_I");
        // ミノ、プレイヤーの回転を90°かそれ以外で分別
        float minoAngle = Mathf.Abs(angle % 180f), playerAngle = Mathf.Abs(angle % 180f);
        if (isMinoBlockI == true)
        {
            if (minoAngle == 90f)
            {
                // ミノの構成が横長である為、プレイヤーに対して水平である場合はプレイヤーとミノの中心座標の距離を短くする。
                if (playerAngle == 90f)
                    minoObj.transform.localPosition = Vector3.up;
                // プレイヤーに対して垂直である場合はプレイヤーとミノの中心座標の距離を長くする。
                else
                    minoObj.transform.localPosition = Vector3.up * 2.5f;
            }
            else
            {
                // ミノの構成が横長である為、プレイヤーに対して水平である場合はプレイヤーとミノの中心座標の距離を短くする。
                if (playerAngle == 90f)
                    minoObj.transform.localPosition = Vector3.up * 2.5f;
                // プレイヤーに対して垂直である場合はプレイヤーとミノの中心座標の距離を長くする。
                else
                    minoObj.transform.localPosition = Vector3.up;
            }
        }
        else if (isMinoBlockI == false)
        {
            if (minoAngle == 90f)
                minoObj.transform.localPosition = Vector3.up * 2f;
            else
                minoObj.transform.localPosition = Vector3.up;
        }
    }

    private void UpdateMinoCountText()
    {
        minoCountText.text = _holdMinoCount.ToString();
        if(_holdMinoCount <= 20)
        {
            _armOne.SetActive(false);
            _armTwo.SetActive(true);
        }
        if(_holdMinoCount <= 10)
        {
            _armTwo.SetActive(false);
            _armThree.SetActive(true);
        }
        if(_holdMinoCount < 1)
        {
            _armThree.SetActive(false);
            _gameOver = true;
        }
    }
}
