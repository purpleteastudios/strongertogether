using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Startup : MonoBehaviour
{
    GameObject debugClean;
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    // Update is called once per frame

    void Update() {
        
        //Remove URP [Debug Updater]
        debugClean = GameObject.Find("[Debug Updater]");
        Destroy (debugClean);
    }
}
