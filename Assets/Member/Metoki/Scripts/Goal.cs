using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public SceneChange sceneChange;
    // Start is called before the first frame update
    // ���̃I�u�W�F�N�g���g���K�[�ɓ������Ƃ��ɌĂ΂��
    private void OnTriggerEnter2D(Collider2D other)
    {
        // �g���K�[�ɓ������I�u�W�F�N�g�̖��O���擾���ă��O�ɕ\��
        Debug.Log("Triggered by: " + other.gameObject.name);

        // ����̃^�O�̃I�u�W�F�N�g���g���K�[�ɓ������ꍇ�̏���
        if (other.gameObject.CompareTag("Player"))
        {
            // �����ɏ���������
            sceneChange.Goal = true;
        }
    }
    
}
