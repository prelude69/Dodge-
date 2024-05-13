using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinChanger : MonoBehaviour
{
    public GameObject selectButton;
    public GameObject unlockButton;
    public Text skinEffectText;

    public Material[] skinMat = new Material[8];
    public int skinIdx = 0;
    public int[] skinCost = new int[8]{0, 10, 25, 50, 75, 100, 125, 111};

    private void SelOrUnlock(int idx){
        switch(idx){
            case 0 :
                selectButton.SetActive(true);
                unlockButton.SetActive(false);
                break;
            case 1 :
                if(PlayerPrefs.GetInt("Mat1Unlock") == 1){
                    selectButton.SetActive(true);
                    unlockButton.SetActive(false);
                }
                else{
                    selectButton.SetActive(false);
                    unlockButton.SetActive(true);
                }
                break;
            case 2 :
                if(PlayerPrefs.GetInt("Mat2Unlock") == 1){
                    selectButton.SetActive(true);
                    unlockButton.SetActive(false);
                }
                else{
                    selectButton.SetActive(false);
                    unlockButton.SetActive(true);
                }
                break;
            case 3 :
                if(PlayerPrefs.GetInt("Mat3Unlock") == 1){
                    selectButton.SetActive(true);
                    unlockButton.SetActive(false);
                }
                else{
                    selectButton.SetActive(false);
                    unlockButton.SetActive(true);
                }
                break;
            case 4 :
                if(PlayerPrefs.GetInt("Mat4Unlock") == 1){
                    selectButton.SetActive(true);
                    unlockButton.SetActive(false);
                }
                else{
                    selectButton.SetActive(false);
                    unlockButton.SetActive(true);
                }
                break;
            case 5 :
                if(PlayerPrefs.GetInt("Mat5Unlock") == 1){
                    selectButton.SetActive(true);
                    unlockButton.SetActive(false);
                }
                else{
                    selectButton.SetActive(false);
                    unlockButton.SetActive(true);
                }
                break;
            // case 6 :
            //     if(PlayerPrefs.GetInt("Mat6Unlock") == 1){
            //         selectButton.SetActive(true);
            //         unlockButton.SetActive(false);
            //     }
            //     else{
            //         selectButton.SetActive(false);
            //         unlockButton.SetActive(true);
            //     }
            //     break;
            // case 7 :
            //     if(PlayerPrefs.GetInt("Mat7Unlock") == 1){
            //         selectButton.SetActive(true);
            //         unlockButton.SetActive(false);
            //     }
            //     else{
            //         selectButton.SetActive(false);
            //         unlockButton.SetActive(true);
            //     }
            //     break;
        }
    }
    public void ChangeSkin(){
        //PlayerPrefs.SetInt("PlayerSkinIdx", 6);
        skinIdx = PlayerPrefs.GetInt("PlayerSkinIdx");
        gameObject.GetComponent<MeshRenderer>().material = skinMat[skinIdx];
    }
    public void NextSkin(){
        skinIdx = ++skinIdx % 6;
        gameObject.GetComponent<MeshRenderer>().material = skinMat[skinIdx];
        SelOrUnlock(skinIdx);
    }
    public void PrevSkin(){
        skinIdx = (skinIdx + 5) % 6;
        gameObject.GetComponent<MeshRenderer>().material = skinMat[skinIdx];
        SelOrUnlock(skinIdx);
    }
    public void SelectSkin(){
        PlayerPrefs.SetInt("PlayerSkinIdx", skinIdx);
    }
    public void UnlockSkin(){
        int curCoin = PlayerPrefs.GetInt("Coin");
        int unlockCondition = PlayerPrefs.GetInt("skin1");
        if(curCoin >= skinCost[skinIdx]){
            curCoin -= skinCost[skinIdx];
            PlayerPrefs.SetInt("Coin", curCoin);
            switch(skinIdx){
                case 0 :
                    PlayerPrefs.SetInt("Mat0Unlock", 1);
                    break;
                case 1 :
                    PlayerPrefs.SetInt("Mat1Unlock", 1);
                    break;
                case 2 :
                    PlayerPrefs.SetInt("Mat2Unlock", 1);
                    break;
                case 3 :
                    PlayerPrefs.SetInt("Mat3Unlock", 1);
                    break;
                case 4 :
                    PlayerPrefs.SetInt("Mat4Unlock", 1);
                    break;
                case 5 :
                    PlayerPrefs.SetInt("Mat5Unlock", 1);
                    break;
                // case 6 :
                //     PlayerPrefs.SetInt("Mat6Unlock", 1);
                //     break;
                // case 7 :
                //     PlayerPrefs.SetInt("Mat7Unlock", 1);
                //     break;
            }
        }
        SelOrUnlock(skinIdx);
    }
    
    void ShowSkinEffect(){
        switch(skinIdx){
            case 0:
                skinEffectText.text = "A Good Plain Blue\nCost : " + (int)skinCost[skinIdx] + "\nThis skin does Literally NOTHING.";
                break;
            case 1:
                skinEffectText.text = "You Feal Swifter!\nCost : " + (int)skinCost[skinIdx] + "\nThis skin increases your skin a little bit.";
                break;
            case 2:
                skinEffectText.text = "I Am Neo\nCost : " + (int)skinCost[skinIdx] + "\nThis sking gives you ability to make all bullet slower.";
                break;
            case 3:
                skinEffectText.text = "Tekkai!\nCost : " + (int)skinCost[skinIdx] + "\nThis skin gives you ability to be invincible for a short time.";
                break;
            case 4:
                skinEffectText.text = "I'm Alive!\nCost : " + (int)skinCost[skinIdx] + "\nThis skin gives you second chance.";
                break;
            case 5:
                skinEffectText.text = "EMP!\nCost : " + (int)skinCost[skinIdx] + "\nThis skin give you abilty to erase EVERY bullet on field.";
                break;
            // case 6:
            //     skinEffectText.text = "Beyond The Horizon!\nCost : 75\nThis skin can make ";
            //     break;
            // case 7:
            //     skinEffectText.text = "Zombie\nCost : 100\nThis skin can give you a chance of being revived.";
            //     break;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        ChangeSkin();
        PlayerPrefs.SetInt("Mat0Unlock", 0);
    }

    public float rotationSpeed = 60f;

    void Update() {
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
        ShowSkinEffect();
    }
}
