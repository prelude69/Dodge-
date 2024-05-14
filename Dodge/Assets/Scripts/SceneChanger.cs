using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public GameObject yeeObject;
    AudioSource yee;
    // Start is called before the first frame update
    void Start()
    {
        //SceneManager.LoadScene("TitleScreen");
    }

    // Update is called once per frame
    void Update()
    {
        
        yeeObject = GameObject.Find("Yee");
        yee = yeeObject.GetComponent<AudioSource>();
    }

    public void Scene2Main(){
        yee.Play();
        DontDestroyOnLoad(yeeObject);
        SceneManager.LoadScene("TitleScreen");
    }
    public void Scene2LvlOne(){
        yee.Play();
        DontDestroyOnLoad(yeeObject);
        SceneManager.LoadScene("Level1");
    }
    public void Scene2LvlTwo(){
        yee.Play();
        DontDestroyOnLoad(yeeObject);
        SceneManager.LoadScene("Level2");
    }
    public void Scene2LvlThree(){
        yee.Play();
        DontDestroyOnLoad(yeeObject);
        SceneManager.LoadScene("Level3");
    }
    public void Scene2LvlFour(){
        yee.Play();
        DontDestroyOnLoad(yeeObject);
        SceneManager.LoadScene("Level4");
    }
    public void Scene2LvlInf(){
        yee.Play();
        DontDestroyOnLoad(yeeObject);
        SceneManager.LoadScene("LevelInfinity");
    }
    public void Scene2SkinSelect(){
        yee.Play();
        DontDestroyOnLoad(yeeObject);
        SceneManager.LoadScene("SkinSelect");
    }
    public void Scene2LeaderBorad(){
        yee.Play();
        DontDestroyOnLoad(yeeObject);
        SceneManager.LoadScene("LeaderBorad");
    }
}
