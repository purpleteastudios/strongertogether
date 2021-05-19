using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ThreeDPlayerCameras : MonoBehaviour
{
    
    GameObject mainCamera;
    GameObject secondaryCamera;
    // Start is called before the first frame update
    void Start()
    {
       mainCamera = GameObject.Find("Default Camera");
       secondaryCamera = GameObject.Find("Secondary Camera");
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name.Contains("S_")){
            
            if(Input.GetKeyDown(KeyCode.I)) {
            secondaryCamera.SetActive(true);
            mainCamera.SetActive(false);
        }
        if(Input.GetKeyUp(KeyCode.I)) {
            secondaryCamera.SetActive(false);
            mainCamera.SetActive(true);
        }
        }
    }
}
