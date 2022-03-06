using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Scene = UnityEngine.SceneManagement.Scene;

public class UIMenu : MonoBehaviour
{

    public GameObject UIMenuManager;
    public bool QuitActif = false;
    public float timerAnim;
    public float tempsAnim;
    public bool doingStartAnim = false;

    public string LEGrandBuild = "LEGrandBuild";


    void Start()
    {
        UIMenuManager.SetActive(true);
        Time.timeScale = 0;
        doingStartAnim = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(doingStartAnim == true)
        {
            SceneManager.LoadScene("LEGrandBuild");
        }
    }

    public void Début()
    {
        SceneManager.LoadScene(LEGrandBuild);
        doingStartAnim = true;
        timerAnim += Time.deltaTime;
        Time.timeScale = 1;
        if (timerAnim >= tempsAnim)
        {
            UIMenuManager.SetActive(false);
            QuitActif = true;
            doingStartAnim = true;
        }
    }
    
    public void Quit()
    {
        
        Application.Quit();
    }
    
}
