using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    public GameObject yeeObject;
    AudioSource yee;
    public Button lvl2Button;
    public Button lvl3Button;
    public Button lvl4Button;
    public Button lvl5Button;
    public Button skinButton;
    // Start is called before the first frame update
    void Start()
    {
        yeeObject = GameObject.Find("Yee");
        yee = yeeObject.GetComponent<AudioSource>();
        int lvlOpen1 = PlayerPrefs.GetInt("lvlOpen1");
        int lvlOpen2 = PlayerPrefs.GetInt("lvlOpen2");
        int lvlOpen3 = PlayerPrefs.GetInt("lvlOpen3");
        int lvlOpen4 = PlayerPrefs.GetInt("lvlOpen4");
        if(lvlOpen1 == 1){
            lvl2Button.interactable = true;
        }
        else{
            lvl2Button.interactable = false;
        }
        if(lvlOpen2 == 1){
            lvl3Button.interactable = true;
        }
        else{
            lvl3Button.interactable = false;
        }
        if(lvlOpen3 == 1){
            lvl4Button.interactable = true;
        }
        else{
            lvl4Button.interactable = false;
        }
        if(lvlOpen4 == 1){
            lvl5Button.interactable = true;
            skinButton.interactable = true;
        }
        else{
            lvl5Button.interactable = false;
            skinButton.interactable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        int lvlOpen1 = PlayerPrefs.GetInt("lvlOpen1");
        int lvlOpen2 = PlayerPrefs.GetInt("lvlOpen2");
        int lvlOpen3 = PlayerPrefs.GetInt("lvlOpen3");
        int lvlOpen4 = PlayerPrefs.GetInt("lvlOpen4");
        if(lvlOpen1 == 1){
            lvl2Button.interactable = true;
        }
        else{
            lvl2Button.interactable = false;
        }
        if(lvlOpen2 == 1){
            lvl3Button.interactable = true;
        }
        else{
            lvl3Button.interactable = false;
        }
        if(lvlOpen3 == 1){
            lvl4Button.interactable = true;
        }
        else{
            lvl4Button.interactable = false;
        }
        if(lvlOpen4 == 1){
            lvl5Button.interactable = true;
            skinButton.interactable = true;
        }
        else{
            lvl5Button.interactable = false;
            skinButton.interactable = false;
        }
    }
}
