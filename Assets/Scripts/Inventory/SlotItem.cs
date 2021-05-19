using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotItem : MonoBehaviour
{
    
    public string itemName;
    public string itemDescription;
    public int itemValue;
    public Sprite spriteImage;

    // Start is called before the first frame update
    void Start()
    {
        spriteImage = null;
        itemName= "";
        itemDescription = "";
        itemValue = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
