using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetProgress : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetAllData(){
        PlayerPrefs.SetInt("Coin", 0);
        PlayerPrefs.SetInt("Mat0Unlock", 1);
        PlayerPrefs.SetInt("Mat1Unlock", 0);
        PlayerPrefs.SetInt("Mat2Unlock", 0);
        PlayerPrefs.SetInt("Mat3Unlock", 0);
        PlayerPrefs.SetInt("Mat4Unlock", 0);
        PlayerPrefs.SetInt("Mat5Unlock", 0);
        PlayerPrefs.SetInt("Mat6Unlock", 0);
        PlayerPrefs.SetInt("Mat7Unlock", 0);
        PlayerPrefs.SetInt("PlayerSkinIdx", 0);
        PlayerPrefs.SetInt("lvlOpen1", 0);
        PlayerPrefs.SetInt("lvlOpen2", 0);
        PlayerPrefs.SetInt("lvlOpen3", 0);
        PlayerPrefs.SetInt("lvlOpen4", 0);
    }
}
