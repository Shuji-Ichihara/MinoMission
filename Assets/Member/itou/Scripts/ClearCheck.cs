using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCheck : MonoBehaviour
{
    public string targetTag = "Mino";  // �����������I�u�W�F�N�g�̃^�O
    public int requiredBlockCount = 10; // �������邽�߂ɕK�v�ȃu���b�N�̐��i�K�v�ɉ����Ē����j
    private List<GameObject> blocksInCollider = new List<GameObject>();
    public bool Clear;
    public bool Elimination_completed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Elimination_completed)
        {
            //Clear = true ;
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
    /*
    // �R���C�_�[�ɉ��������������ɌĂ΂��
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            blocksInCollider.Add(other.gameObject);
            CheckAndDestroyBlocks();
        }
    }

    // �R���C�_�[���牽�����o�����ɌĂ΂��
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            blocksInCollider.Remove(other.gameObject);
        }
    }

    // �R���C�_�[���̃u���b�N�����`�F�b�N���āA��������������Ă�����S�Ẵu���b�N������
    private void CheckAndDestroyBlocks()
    {
        if (blocksInCollider.Count >= requiredBlockCount)
        {
            foreach (GameObject Mino in blocksInCollider)
            {
                Destroy(Mino);
                Elimination_completed = true;
            }
            blocksInCollider.Clear();
        }
    }*/
}
