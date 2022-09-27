using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI ���� ���̺귯��
using UnityEngine.SceneManagement; // �� ���� ���� ���̺귯��
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject gameoverText; // ���ӿ��� �� Ȱ��ȭ�� �ؽ�Ʈ ���� ������Ʈ
    public TextMeshProUGUI timeText; // ���� �ð��� ǥ���� �ؽ�Ʈ�Ž����� ������Ʈ
    public TextMeshProUGUI recordText; // �ְ� ����� ǥ���� �ؽ�Ʈ�Ž����� ������Ʈ

    private float surviveTime; // ���� �ð�
    private bool isGameover; // ���ӿ��� ����

    void Start()
    {
        surviveTime = 0;
        isGameover = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isGameover)
        {
            // ���� �ð� ����
            surviveTime += Time.deltaTime;
            // ������ ���� �ð��� timeText �ؽ�Ʈ ������Ʈ�� �̿��� ǥ��
            timeText.text = "Time: " + (int)surviveTime;
        }
        else
        {
            // ���ӿ��� ���¿��� R Ű�� ���� ���
            if(Input.GetKeyDown(KeyCode.R))
            {
                // MainScene ���� �ε�
                SceneManager.LoadScene("TestScene");
            }
        }
    }
    // ���� ������ ���ӿ��� ���·� �����ϴ� �޼���
    public void EndGame()
    {
        // ���� ���¸� ���ӿ��� ���·� ��ȯ
        isGameover = true;
        // ���ӿ��� �ؽ�Ʈ ���� ������Ʈ�� Ȱ��ȭ
        gameoverText.SetActive(true);
        // BestTime Ű�� ����� ���������� �ְ� ��� �ڰܿ���
        float bestTime = PlayerPrefs.GetFloat("BestTime");
        // ���������� �ְ� ��Ϻ��� ���� ���� �ð��� �� ũ�ٸ�
        if (surviveTime > bestTime)
        {
            //�ְ� ��� ���� ���� ���� �ð� ������ ����
            bestTime = surviveTime;
            // ����� �ְ� ����� BestTime Ű�� ����
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }

        //�ְ� ����� recordText �ؽ�Ʈ ������Ʈ�� �̿��� ǥ��
        recordText.text = "Best Time:" + (int)bestTime;
    }
}
