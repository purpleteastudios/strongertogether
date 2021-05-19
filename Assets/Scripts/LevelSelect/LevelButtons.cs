using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelButtons : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject child;
    public TextMeshProUGUI childTMP;

    public Component sessionData;
    public GameObject loadingScreen;

    public GameObject loadingSlider;
    public Slider loadingProgressBar;

    public Object LevelScene;
    
    // Start is called before the first frame update
    void Start()
    {
        child = this.transform.GetChild(0).gameObject;
        childTMP = child.gameObject.GetComponent<TextMeshProUGUI>();

        
    }

    void Update(){
        if(LevelScene != null){
        childTMP.text = LevelScene.name;
        }
    }


    



    public void OnPointerEnter(PointerEventData eventData)
     {
         childTMP.color = new Color32(255, 255, 255, 255); 
     }

    public void OnPointerExit(PointerEventData eventData)
     {
         childTMP.color = new Color32(141, 157, 164, 255); 
     }

     public void onClick() {
         StartCoroutine(GameObject.Find("GameData").GetComponent<SessionData>().LoadScene(LevelScene.name));
     }

    
}
