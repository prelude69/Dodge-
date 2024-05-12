using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Scene2Main(){
        SceneManager.LoadScene("TitleScreen");
    }
    public void Scene2LvlOne(){
        //SceneManager.LoadScene("");
    }
    public void Scene2LvlTwo(){
        //SceneManager.LoadScene("");
    }
    public void Scene2LvlThree(){
        //SceneManager.LoadScene("");
    }
    public void Scene2LvlFour(){
        //SceneManager.LoadScene("");
    }
    public void Scene2LvlInf(){
        SceneManager.LoadScene("LevelInfinity");
    }
    public void Scene2SkinSelect(){
        SceneManager.LoadScene("SkinSelect");
    }
}
