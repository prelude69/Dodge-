using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DevTool : MonoBehaviour
{
    private int clickAmount;
    public GameObject yeeObject;
    public Text dodge;
    AudioSource yee;
    // Start is called before the first frame update
    void Start()
    {
        clickAmount = 0;
        dodge.text = "Dodge!";
    }

    // Update is called once per frame
    void Update()
    {
        yeeObject = GameObject.Find("Yee");
        yee = yeeObject.GetComponent<AudioSource>();
    }

    public void DevAccountActivate(){
        clickAmount ++;
        if(clickAmount >= 10){
            PlayerPrefs.SetInt("Coin", 9999);
            PlayerPrefs.SetInt("lvlOpen1", 1);
            PlayerPrefs.SetInt("lvlOpen2", 1);
            PlayerPrefs.SetInt("lvlOpen3", 1);
            PlayerPrefs.SetInt("lvlOpen4", 1);
            yee.Play();
            DontDestroyOnLoad(yeeObject);
            dodge.text = "Yee!";
        }
    }
}
