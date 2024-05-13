using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        //SceneManager.LoadScene("TitleScreen");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Scene2Main(){
        SceneManager.LoadScene("TitleScreen");
    }
    public void Scene2LvlOne(){
        SceneManager.LoadScene("Level1");
    }
    public void Scene2LvlTwo(){
        SceneManager.LoadScene("Level2");
    }
    public void Scene2LvlThree(){
        SceneManager.LoadScene("Level3");
    }
    public void Scene2LvlFour(){
        SceneManager.LoadScene("Level4");
    }
    public void Scene2LvlInf(){
        SceneManager.LoadScene("LevelInfinity");
    }
    public void Scene2SkinSelect(){
        SceneManager.LoadScene("SkinSelect");
    }
    public void Scene2LeaderBorad(){
        SceneManager.LoadScene("LeaderBorad");
    }
}
