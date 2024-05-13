using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderBoardManager : MonoBehaviour
{
    public Text lb1N;
    public Text lb2N;
    public Text lb3N;
    public Text lb4N;
    public Text lb5N;

    public Text lb1S;
    public Text lb2S;
    public Text lb3S;
    public Text lb4S;
    public Text lb5S;

    public void PrintLeaderBoard(){
        lb1N.text = "  " + PlayerPrefs.GetString("lb1N");
        lb2N.text = "  " + PlayerPrefs.GetString("lb2N");
        lb3N.text = "  " + PlayerPrefs.GetString("lb3N");
        lb4N.text = "  " + PlayerPrefs.GetString("lb4N");
        lb5N.text = "  " + PlayerPrefs.GetString("lb5N");

        lb1S.text = (float) PlayerPrefs.GetFloat("lb1S") + "  ";
        lb2S.text = (float) PlayerPrefs.GetFloat("lb2S") + "  ";
        lb3S.text = (float) PlayerPrefs.GetFloat("lb3S") + "  ";
        lb4S.text = (float) PlayerPrefs.GetFloat("lb4S") + "  ";
        lb5S.text = (float) PlayerPrefs.GetFloat("lb5S") + "  ";
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PrintLeaderBoard();
    }
}
