using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    GameObject menu;
    // Start is called before the first frame update
    void Start()
    {
        menu = GameObject.Find("Pause Menu");
        menu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            {
                if(menu.activeSelf){
                    menu.SetActive(false);
                }else {
                    menu.SetActive(true);
                }
            }
    }

    public void closeMenu() {
        menu.SetActive(false);
    }

    public void backToLevelSelect() {
        SceneManager.LoadScene("LevelSelect", LoadSceneMode.Single);
    }

    public void backToMainMenu() {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}
