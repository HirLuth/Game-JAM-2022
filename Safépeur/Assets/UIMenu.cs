using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMenu : MonoBehaviour
{

    public GameObject UIMenuManager;
    public bool QuitActif = false;
    public float timerAnim;
    public float tempsAnim;
    public bool doingStartAnim = false;
    
    
    void Start()
    {
        UIMenuManager.SetActive(true);
      //  UIMenuManager.SetActive(true);
        Time.timeScale = 0;
        doingStartAnim = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(doingStartAnim == true)
        {
            Début();
        }
    }

    public void Début()
    {
        Debug.Log("ahhhhhhhhhhhh");
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
