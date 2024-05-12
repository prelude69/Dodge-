using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI 관련 라이브러리
using UnityEngine.SceneManagement; // 씬 관리 관련 라이브러리

public class GameManager : MonoBehaviour {
    public GameObject gameoverText; // 게임오버시 활성화 할 텍스트 게임 오브젝트
    public PlayerController playerController;
    public Text timeText; // 생존 시간을 표시할 텍스트 컴포넌트
    public Text recordText; // 최고 기록을 표시할 텍스트 컴포넌트
    public bool skillAble;
    public bool skillOn;

    private float surviveTime; // 생존 시간
    private bool isGameover; // 게임 오버 상태

    void Start() {
        Time.timeScale = 1;
        // 생존 시간과 게임 오버 상태를 초기화
        surviveTime = 0;
        isGameover = false;
        skillAble = true;
        skillOn = false;
    }

    private float skillCounter = 0.0f;

    void Update() {
        if(Input.GetKeyDown(KeyCode.Space) && skillAble == true){
            if(PlayerPrefs.GetInt("PlayerSkinIdx") == 2){
                skillAble = false;
                skillOn = true;
                skillCounter = 0.0f;
            }
            if(PlayerPrefs.GetInt("PlayerSkinIdx") == 3){
                skillAble = false;
                skillOn = true;
                skillCounter = 0.0f;
            }
            
            if(PlayerPrefs.GetInt("PlayerSkinIdx") == 5){
                skillAble = false;
                skillOn = true;
                skillCounter = 0.0f;
            }
        }
        if(skillOn == true){
            if(PlayerPrefs.GetInt("PlayerSkinIdx") == 2){
                if(skillCounter < 1.5f){
                    Time.timeScale = 0.5f;
                    skillCounter += Time.deltaTime;
                }
                else if(skillCounter < 11.5f){
                    skillOn = false;
                    Time.timeScale = 1.0f;
                    skillCounter += Time.deltaTime;
                }
                else{
                    skillAble = true;
                }
            }
            if(PlayerPrefs.GetInt("PlayerSkinIdx") == 3){
                if(skillCounter < 1.0f){
                    PlayerPrefs.SetInt("isInvincible" , 1);
                    skillCounter += Time.deltaTime;
                }
                else if(skillCounter < 11.0f){
                    PlayerPrefs.SetInt("isInvincible" , 0);
                    skillOn = false;
                    skillCounter += Time.deltaTime;
                }
                else{
                    skillAble = true;
                }
            }
            if(PlayerPrefs.GetInt("PlayerSkinIdx") == 5){
                if(skillCounter == 0.0f){
                    PlayerPrefs.SetInt("killBullet" , 1);
                    skillCounter += Time.deltaTime;
                }
                else if(skillCounter < 10.0f){
                    PlayerPrefs.SetInt("killBullet" , 0);
                    skillCounter += Time.deltaTime;
                }
                else{
                    skillAble = true;
                }
            }
        }
        
        // 게임 오버가 아닌 동안
        if (!isGameover)
        {
            // 생존 시간 갱신
            surviveTime += Time.deltaTime;
            // 갱신한 생존 시간을 timeText 텍스트 컴포넌트를 통해 표시
            timeText.text = "Time: " + (int) surviveTime;
            if(surviveTime >= 30){
                int difficulty = (int)(surviveTime/30);
                BulletSpawner bulSpawner = new BulletSpawner();
                bulSpawner.DifficultySet(difficulty);
            }
        }
        else
        {
            Time.timeScale = 0;
            if(PlayerPrefs.GetInt("PlayerSkinIdx") == 4 && skillAble == true){
                skillAble = false;
                ContinueGame();
            }
        }
    }
    
    public void ContinueGame(){
        Time.timeScale = 1;
        isGameover = false;
        gameoverText.SetActive(false);
        playerController.Revive();
    }
    // 현재 게임을 게임 오버 상태로 변경하는 메서드
    public void EndGame() {
        // 현재 상태를 게임 오버 상태로 전환
        isGameover = true;
        // 게임 오버 텍스트 게임 오브젝트를 활성화
        gameoverText.SetActive(true);

        // BestTime 키로 저장된, 이전까지의 최고 기록 가져오기
        float bestTime = PlayerPrefs.GetFloat("BestTime");

        // 이전까지의 최고 기록보다 현재 생존 시간이 더 크다면
        if (surviveTime > bestTime)
        {
            // 최고 기록의 값을 현재 생존 시간의 값으로 변경 
            bestTime = surviveTime;
            // 변경된 최고 기록을 BestTime 키로 저장
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }

        // 최고 기록을 recordText 텍스트 컴포넌트를 통해 표시
        recordText.text = "Best Time: " + (int) bestTime;
        
    }
}