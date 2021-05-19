using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpItem : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isCollected;
    public string collectedBy;

    public Sprite itemSprite;
    public string itemName;
    public string itemDescription;
    public int itemValue;

    public GameObject[] allSceneObjects;


    public List<GameObject> InvSlots = new List<GameObject>();
    public List<GameObject> EmptySlots = new List<GameObject>();

    public GameObject childOfItem;
    public Image gameItem;

    public bool InvSlotsCalculated;
    
    void Start()
    {
        allSceneObjects = FindObjectsOfType<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
    
    }

     void OnTriggerEnter(Collider collision)
    {
        GameObject pickupitem = this.gameObject;
        Debug.Log("Triggered:" + this.gameObject.name);
        foreach (GameObject item in allSceneObjects){
            if(Vector3.Distance(item.transform.position, pickupitem.transform.position) < 1.5f && item.name != pickupitem.name){
                Debug.Log("Triggered By:" + item.name);
                collectedBy = item.name;
                SessionData.PickUpItem(pickupitem);
                
            }
        }
        
        
        
        isCollected = true;

    }

}
