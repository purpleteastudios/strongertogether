using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SessionData : MonoBehaviour
{

    //Debug

    public GameObject DebugCanvas;
    public GameObject[] DebugUI;

    //Options Menu
    public int mainVolume;
    public Slider mainVolumeSlider;
    string graphicsQuality;

    public static string invertY;
    public static bool invertYBool;
    public GameObject invertYGameObject;

    public Toggle invertYToggle;

    

    //Loading Screen

    public GameObject loadingScreen;
    public GameObject loadingSlider;
    public Slider loadingProgressBar;

    //Inventory
    public GameObject KeyPressInventoryCanvas;

    public GameObject AlwaysInventoryCanvas;
    public static GameObject[] InvSlots;
    public GameObject[] InvSlotsVis;

    public static List<GameObject> EmptyInvSlots = new List<GameObject>();
    public GameObject childOfItem;
    public Image gameItem;
    public static int slotcount = 6;
    public int NumberEmptyInvSlots;
    


    // Start is called before the first frame update
    void Start()
    {
        
        InvSlots = GameObject.FindGameObjectsWithTag("InvSlots");
        DebugCanvas.SetActive(false);
        AlwaysInventoryCanvas.SetActive(false);
        KeyPressInventoryCanvas.SetActive(false);
        mainVolume = PlayerPrefs.GetInt("mainVolume", 50);
        loadingScreen = GameObject.Find("LoadingScreen");
        loadingSlider = GameObject.Find("LoadingSlider");
        loadingProgressBar = loadingSlider.GetComponent<Slider>();
        loadingScreen.SetActive(false);
        invertY = PlayerPrefs.GetString("invertY", "false");
        if(invertY == "false"){
            invertYBool = false;
        } else {invertYBool = true;}
        
        

    }

    // Update is called once per frame
    void Update()
    {
        //DEBUG SETUP
        DebugUI = GameObject.FindGameObjectsWithTag("Debug");
        foreach (var item in DebugUI)
        {
            if(item.name == "mainVolume"){
                item.GetComponent<TextMeshProUGUI>().text = mainVolume.ToString();
            }
            if(item.name == "invertY"){
                item.GetComponent<TextMeshProUGUI>().text = invertYBool.ToString();
            }
        }
        if(Input.GetKeyDown(KeyCode.Tab)) {
            DebugCanvas.SetActive(true);
        }
        if(Input.GetKeyUp(KeyCode.Tab)) {
            DebugCanvas.SetActive(false);
        }


        //OPTIONS MENU
        if(SceneManager.GetActiveScene().name == "Options"){
            //GET COMPONENTS
            GameObject mainVolumeGameObject;
            mainVolumeGameObject = GameObject.Find("MainVolumeSlider");
            mainVolumeSlider = mainVolumeGameObject.GetComponent<Slider>();

            invertYGameObject = GameObject.Find("InvertYToggle");
            invertYToggle = invertYGameObject.GetComponent<Toggle>();

            //SET VALUES
            if(mainVolumeSlider.value != mainVolume){
                mainVolumeSlider.value = (float)mainVolume;
            }

            if(invertYToggle.isOn != invertYBool){
                invertYToggle.isOn = invertYBool;
            }

            //CHECK FOR VALUE CHANGE
            mainVolumeSlider.onValueChanged.AddListener (delegate {ValueChangeCheck (mainVolumeSlider.name);});
            invertYToggle.onValueChanged.AddListener (delegate {ValueChangeCheck (invertYToggle.name);});
        }

        //INVENTORY
            

        if(SceneManager.GetActiveScene().name.Contains("S_")){



            AlwaysInventoryCanvas.SetActive(true);

            
            InvSlotsVis = InvSlots;
            foreach (var item in InvSlots)
                {
                    
                    childOfItem = item.transform.GetChild(0).gameObject;
                    gameItem = childOfItem.GetComponent<Image>();
                    if(item.GetComponent<SlotItem>().spriteImage !=null){
                        gameItem.sprite = item.GetComponent<SlotItem>().spriteImage;
                        Debug.Log("Sprite is not null");
                    }else {
                        //gameItem.color = new Color(0, 0, 0, 0);
                        EmptyInvSlots.Add(item);
                    }
                }
            
            if(Input.GetKeyDown(KeyCode.I)) {
            KeyPressInventoryCanvas.SetActive(true);
            
        }
        if(Input.GetKeyUp(KeyCode.I)) {
            KeyPressInventoryCanvas.SetActive(false);
        }

        if(Input.GetKeyUp(KeyCode.Alpha1)) {
            GameObject.Find("Slot1Bottom").GetComponent<Button>().Select();
            Debug.Log("You pressed 1");
        }
        if(Input.GetKeyUp(KeyCode.Alpha2)) {
            GameObject.Find("Slot2Bottom").GetComponent<Button>().Select();
            Debug.Log("You pressed 2");
        }
        if(Input.GetKeyUp(KeyCode.Alpha3)) {
            GameObject.Find("Slot3Bottom").GetComponent<Button>().Select();
            Debug.Log("You pressed 3");
        }
        if(Input.GetKeyUp(KeyCode.Alpha4)) {
            GameObject.Find("Slot4Bottom").GetComponent<Button>().Select();
            Debug.Log("You pressed 4");
        }
        if(Input.GetKeyUp(KeyCode.Alpha5)) {
            GameObject.Find("Slot5Bottom").GetComponent<Button>().Select();
            Debug.Log("You pressed 5");
        }
        if(Input.GetKeyUp(KeyCode.Alpha6)) {
            GameObject.Find("Slot6Bottom").GetComponent<Button>().Select();
            Debug.Log("You pressed 6");
        }
        if(Input.GetKeyUp(KeyCode.Alpha7)) {
            GameObject.Find("Slot7Bottom").GetComponent<Button>().Select();
            Debug.Log("You pressed 7");
        }


        }

        
        

        
    }

    //ONDEMAND FUNCTIONS

    //IF A VALUE CHANGES, UPDATE VARIABLES
    public void ValueChangeCheck(string what)
	{   
        if(what== "MainVolumeSlider"){
            mainVolume = (int)mainVolumeSlider.value;
            PlayerPrefs.SetInt("mainVolume", mainVolume);
        }
        if(what== "InvertYToggle"){
            invertYBool = invertYToggle.isOn;
            invertY = invertYToggle.isOn.ToString();
            PlayerPrefs.SetString("invertY", invertYBool.ToString());
        }
        
        
        
	}

    //LOAD SCENE
    public IEnumerator LoadScene(string level)
    {
        yield return null;

        //Begin to load the Scene
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(level, LoadSceneMode.Single);

        //Don't let the Scene activate until you allow it to
        asyncOperation.allowSceneActivation = false;

        //While the load is still in progress
        while (!asyncOperation.isDone)
        {
            //Output the current progress
            loadingProgressBar.value = asyncOperation.progress;

            // Check if the load has finished
            if (asyncOperation.progress >= 0.9f)
            {
                    //Activate the Scene
                    asyncOperation.allowSceneActivation = true;
                    Debug.Log("Scene Loaded");

            yield return null;
        }
    }
    }

    //PICKUP ITEM
    public static void PickUpItem(GameObject item){
        
        if(slotcount < 0){
            slotcount = slotcount+35;
        }
        Debug.Log("You picked up:" + item.name);
        // Debug.Log("EmptySlots:" + EmptyInvSlots.FindLast.ToString());
        //EmptyInvSlots[slotcount].GetComponent<Image>().color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        GameObject childItem = EmptyInvSlots[slotcount].transform.GetChild(0).gameObject;
        Image childitemImage = childItem.GetComponent<Image>();
        childitemImage.sprite = item.GetComponent<PickUpItem>().itemSprite;
        EmptyInvSlots[slotcount].GetComponent<SlotItem>().itemName = item.GetComponent<PickUpItem>().itemName;
        EmptyInvSlots[slotcount].GetComponent<SlotItem>().itemDescription = item.GetComponent<PickUpItem>().itemDescription;
        EmptyInvSlots[slotcount].GetComponent<SlotItem>().itemValue = item.GetComponent<PickUpItem>().itemValue;
        childitemImage.color = new Color(255, 255, 255, 255);
        EmptyInvSlots.RemoveAt(slotcount);
        item.GetComponent<Collider>().isTrigger = false;
        item.transform.position = new Vector3(item.transform.position.x, 10000.0f, item.transform.position.z);
        if(-1 < slotcount && slotcount < 7){
            slotcount--;
        } else{
            slotcount--;
        }
        
        
    }

    //SWAP ITEMS IN INVENTORY

    public static void swapItems() {

        Debug.Log("You clicked this button");

    }


    





}
