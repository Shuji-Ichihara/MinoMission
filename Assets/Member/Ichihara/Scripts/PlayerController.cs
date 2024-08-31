using Cysharp.Threading.Tasks;
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
    /// <param name="moveValue"></param>
    public void MovePlayer(Vector2 moveValue)
    {
        Debug.Log($" up = {_playerObjTransform.up}");
        Debug.Log($" right = {_playerObjTransform.right}");
        if (_holdMinoBlock != null)
        {
            Debug.Log($" mino localrotation = {_holdMinoBlock.transform.localRotation}");
            Debug.Log($" mino rotation = {_holdMinoBlock.transform.rotation}");
        }
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
        // 子要素にすることで自然な形で追従しているように見える
        _holdMinoBlock.transform.SetParent(_playerObjTransform);
        // プレイヤーオブジェクトのz回転を取得し、180の余りを算出する
        // このゲームでは90°回転の為
        float dummyAngle = _playerObjTransform.eulerAngles.z;
        float playerAngle = Mathf.Abs(dummyAngle) % 180f;
        // 掴むミノのz回転
        float minoAngle = Mathf.Abs(_holdMinoBlock.transform.eulerAngles.z);
        // プレイヤーの向きに応じて自然にミノをくっつける
        if (playerAngle == 0f)
        {
            // ミノの構成が横長である為、水平である場合はプレイヤーとの距離を短くする。
            if (minoAngle <= 0f)
                _holdMinoBlock.transform.localPosition
                        = Vector3.zero - _playerObjTransform.up.normalized * _playerObjTransform.localScale.y;
            else if (minoAngle > 0f)
                _holdMinoBlock.transform.localPosition
                        = Vector3.zero + _playerObjTransform.up.normalized * _playerObjTransform.localScale.y;
            // 
            if (Mathf.Abs(minoAngle) == 90f)
                _holdMinoBlock.transform.localPosition = Vector3.up * 2f;

        }
        else if (playerAngle == 90f)
        {
            // 垂直である場合はプレイヤーとの距離を長くする。
            if (minoAngle <= 0f)
                _holdMinoBlock.transform.localPosition
                        = Vector3.zero - _playerObjTransform.right.normalized * _playerObjTransform.localScale.x * 2f;
            else if (minoAngle > 0f)
                _holdMinoBlock.transform.localPosition
                        = Vector3.zero + _playerObjTransform.right.normalized * _playerObjTransform.localScale.x * 2f;
        }

        _holdMinoCount--;
        // テキストを更新する
        //UpdateMinoCountText();
        //SoundManager.instance.PlaySE(SoundManager.E_SE.SE04);
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
    /// <param name="angle"></param>
    public void RotateMinoBlock(float angle)
    {
        if (_holdMinoBlock == null) return;
        _holdMinoBlock.transform.rotation *= Quaternion.Euler(Vector3.forward * angle);
        var minoAngle = Mathf.Abs(angle % 180f);
        if (minoAngle == 90)
            _holdMinoBlock.transform.localPosition = Vector3.up * 2f;
        else
            _holdMinoBlock.transform.localPosition = Vector3.up;

        SoundManager.instance.PlaySE(SoundManager.E_SE.SE01);
    }

    /// <summary>
    /// ミノを消す処理
    /// </summary>
    public void DeleteMinoBlcok()
    {
        // ここにミノを消す関数を追記する
        clearCheck.Clear = true;
    }

    /// <summary>
    /// ミノを最初の状態に戻す処理
    /// </summary>
    public void Restart()
    {
        // ここにミノを初期状態に戻す関数を追記する
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void UpdateMinoCountText()
    {
        minoCountText.text = _holdMinoCount.ToString();
    }
}
