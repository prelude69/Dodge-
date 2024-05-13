using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI 관련 라이브러리
using UnityEngine.SceneManagement; // 씬 관리 관련 라이브러리

public class GameManager : MonoBehaviour {
    public GameObject gameoverText; // 게임오버시 활성화 할 텍스트 게임 오브젝트
    public GameObject gameclearText;
    public GameObject belowRecord;
    public GameObject overRecord;
    public PlayerController playerController;
    public AdManager adManager;
    public InputField playerNameInput;
    public Text timeText; // 생존 시간을 표시할 텍스트 컴포넌트
    public Text recordText; // 최고 기록을 표시할 텍스트 컴포넌트
    public bool skillAble;
    public bool skillOn;
    
    public int levelNo;

    private float surviveTime; // 생존 시간
    private bool isGameover; // 게임 오버 상태
    private string playerName;
    private float timeB4Ad;
    private float skillCounter;

    void Start() {
        Time.timeScale = 1;
        // 생존 시간과 게임 오버 상태를 초기화
        surviveTime = 0;
        timeB4Ad = 0.0f;
        skillCounter = 0.0f;
        isGameover = false;
        skillAble = true;
        skillOn = false;
    }

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
            if(PlayerPrefs.GetInt("PlayerSkinIdx") == 3){
                if(skillCounter < 1.0f){
                    PlayerPrefs.SetInt("isInvincible" , 1);
                    skillCounter += Time.deltaTime;
                }
                else{
                    PlayerPrefs.SetInt("isInvincible" , 0);
                    skillOn = false;
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
            switch(levelNo){
                case 1 :
                    if(surviveTime >= 10){
                        GameClear();
                    }
                    break;
                case 2 :
                    if(surviveTime >= 15){
                        GameClear();
                    }
                    break;
                case 3 :
                    if(surviveTime >= 20){
                        GameClear();
                    }
                    break;
                case 4 :
                    if(surviveTime >= 25){
                        GameClear();
                    }
                    break;
            }
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
                skillOn = true;
                skillCounter = 0.0f;
                ContinueGame();
            }
        }
    }
    public void GameClear(){
        isGameover = true;
        PlayerPrefs.SetFloat("CoinTime", surviveTime - timeB4Ad);
        adManager.CoinRewardTime();
        gameclearText.SetActive(true);
        switch(levelNo){
                case 1 :
                    PlayerPrefs.SetInt("lvlOpen1", 1);
                    break;
                case 2 :
                    PlayerPrefs.SetInt("lvlOpen2", 1);
                    break;
                case 3 :
                    PlayerPrefs.SetInt("lvlOpen3", 1);
                    break;
                case 4 :
                    PlayerPrefs.SetInt("lvlOpen4", 1);
                    break;
            }
    }
    public void ContinueGame(){
        timeB4Ad = surviveTime;
        Time.timeScale = 1;
        isGameover = false;
        gameoverText.SetActive(false);
        playerController.Revive();
    }
    // 현재 게임을 게임 오버 상태로 변경하는 메서드
    public void EndGame() {
        // 현재 상태를 게임 오버 상태로 전환
        isGameover = true;
        //PlayerPrefs.SetFloat("SurviveTime", surviveTime);
        PlayerPrefs.SetFloat("CoinTime", surviveTime - timeB4Ad);
        adManager.CoinRewardTime();
        
        // 게임 오버 텍스트 게임 오브젝트를 활성화
        gameoverText.SetActive(true);
        
        if(levelNo == 5){
            float lb1S = PlayerPrefs.GetFloat("lb1S");
            float lb2S = PlayerPrefs.GetFloat("lb2S");
            float lb3S = PlayerPrefs.GetFloat("lb3S");
            float lb4S = PlayerPrefs.GetFloat("lb4S");
            float lb5S = PlayerPrefs.GetFloat("lb5S");
            if(surviveTime >= lb5S){
                overRecord.SetActive(true);
                playerName = playerNameInput.GetComponent<InputField>().text;
            }
            else{
                belowRecord.SetActive(true);
            }
            // // BestTime 키로 저장된, 이전까지의 최고 기록 가져오기
            // float bestTime = PlayerPrefs.GetFloat("BestTime");

            // // 이전까지의 최고 기록보다 현재 생존 시간이 더 크다면
            // if (surviveTime > bestTime)
            // {
            //     // 최고 기록의 값을 현재 생존 시간의 값으로 변경 
            //     bestTime = surviveTime;
            //     // 변경된 최고 기록을 BestTime 키로 저장
            //     PlayerPrefs.SetFloat("BestTime", bestTime);
            // }

            // // 최고 기록을 recordText 텍스트 컴포넌트를 통해 표시
            // recordText.text = "Best Time: " + (int) bestTime;
        
        }
    }
    public void LeaderBoardSave(){
        string lb1N = PlayerPrefs.GetString("lb1N");
        string lb2N = PlayerPrefs.GetString("lb2N");
        string lb3N = PlayerPrefs.GetString("lb3N");
        string lb4N = PlayerPrefs.GetString("lb4N");
        string lb5N = PlayerPrefs.GetString("lb5N");
        float lb1S = PlayerPrefs.GetFloat("lb1S");
        float lb2S = PlayerPrefs.GetFloat("lb2S");
        float lb3S = PlayerPrefs.GetFloat("lb3S");
        float lb4S = PlayerPrefs.GetFloat("lb4S");
        float lb5S = PlayerPrefs.GetFloat("lb5S");
        playerName = playerNameInput.text;
        if(surviveTime >= lb1S){
            PlayerPrefs.SetString("lb1N", playerName);
            PlayerPrefs.SetString("lb2N", lb1N);
            PlayerPrefs.SetString("lb3N", lb2N);
            PlayerPrefs.SetString("lb4N", lb3N);
            PlayerPrefs.SetString("lb5N", lb4N);
            PlayerPrefs.SetFloat("lb1S", surviveTime);
            PlayerPrefs.SetFloat("lb2S", lb1S);
            PlayerPrefs.SetFloat("lb3S", lb2S);
            PlayerPrefs.SetFloat("lb4S", lb3S);
            PlayerPrefs.SetFloat("lb5S", lb4S);
        }
        else if(surviveTime >= lb2S){
            PlayerPrefs.SetString("lb2N", playerName);
            PlayerPrefs.SetString("lb3N", lb2N);
            PlayerPrefs.SetString("lb4N", lb3N);
            PlayerPrefs.SetString("lb5N", lb4N);
            PlayerPrefs.SetFloat("lb2S", surviveTime);
            PlayerPrefs.SetFloat("lb3S", lb2S);
            PlayerPrefs.SetFloat("lb4S", lb3S);
            PlayerPrefs.SetFloat("lb5S", lb4S);
        }
        else if(surviveTime >= lb3S){
            PlayerPrefs.SetString("lb3N", playerName);
            PlayerPrefs.SetString("lb4N", lb3N);
            PlayerPrefs.SetString("lb5N", lb4N);
            PlayerPrefs.SetFloat("lb3S", surviveTime);
            PlayerPrefs.SetFloat("lb4S", lb3S);
            PlayerPrefs.SetFloat("lb5S", lb4S);
        }
        else if(surviveTime >= lb4S){
            PlayerPrefs.SetString("lb4N", playerName);
            PlayerPrefs.SetString("lb5N", lb4N);
            PlayerPrefs.SetFloat("lb4S", surviveTime);
            PlayerPrefs.SetFloat("lb5S", lb4S);
        }
        else if(surviveTime >= lb5S){
            PlayerPrefs.SetString("lb5N", playerName);
            PlayerPrefs.SetFloat("lb5S", surviveTime);
        }
    }
}