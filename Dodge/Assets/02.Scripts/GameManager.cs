using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI 관련 라이브러리
using UnityEngine.SceneManagement; // 씬 관리 관련 라이브러리
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject gameoverText; // 게임오버 시 활성화할 텍스트 게임 오브젝트
    public TextMeshProUGUI timeText; // 생존 시간을 표시할 텍스트매시프로 컴포넌트
    public TextMeshProUGUI recordText; // 최고 기록을 표시할 텍스트매시프로 컴포넌트

    private float surviveTime; // 생존 시간
    private bool isGameover; // 게임오버 상태

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
            // 생존 시간 갱신
            surviveTime += Time.deltaTime;
            // 갱신한 생존 시간을 timeText 텍스트 컴포넌트를 이용해 표시
            timeText.text = "Time: " + (int)surviveTime;
        }
        else
        {
            // 게임오버 상태에서 R 키를 누른 경우
            if(Input.GetKeyDown(KeyCode.R))
            {
                // MainScene 씬을 로드
                SceneManager.LoadScene("MainScene");
            }
        }
    }
    // 현재 게임을 게임오버 상태로 변경하는 메서드
    public void EndGame()
    {
        // 현재 상태를 게임오버 상태로 전환
        isGameover = true;
        // 게임오버 텍스트 게임 오브젝트를 활성화
        gameoverText.SetActive(true);
    }
}
