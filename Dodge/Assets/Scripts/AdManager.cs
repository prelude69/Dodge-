using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class AdManager : MonoBehaviour
{
    public GameObject adPanel;
    public GameObject adExit;
    public VideoPlayer adPlayer;
    public GameObject skinViewer;
    public Text coinAmount;

    private int coin;
    //private bool adOn = false;
    
    public const int coinPerSec = 1;

    public void AdCall(){
        adPanel.SetActive(true);
        //adOn = true;
        adExit.SetActive(false);
        skinViewer.SetActive(false);
        adPlayer.Play();
    }
    public void AdClose(){
        adPanel.SetActive(false);
        adExit.SetActive(false);
        skinViewer.SetActive(true);
        adPlayer.Stop();
        //adOn = false;
    }
    public void CoinReward(){
        coin += coinPerSec * 30;
        PlayerPrefs.SetInt("Coin", coin);
    }
    public void CoinRewardTime(){
        float time = PlayerPrefs.GetFloat("CoinTime");
        coin += (int)(time * coinPerSec);
        PlayerPrefs.SetInt("Coin", coin);
    }

    void EndReached(VideoPlayer vp){
        adExit.SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {
        adPlayer.loopPointReached += EndReached;
        coin = PlayerPrefs.GetInt("Coin");
        coinAmount.text = " " + coin;
    }

    // Update is called once per frame
    void Update()
    {
        coin = PlayerPrefs.GetInt("Coin");
        coinAmount.text = " " + coin;
    }
}
