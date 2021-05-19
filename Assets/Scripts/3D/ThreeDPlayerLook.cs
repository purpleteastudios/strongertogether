
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreeDPlayerLook : MonoBehaviour {

private Vector3 Rot;
public float xRot;
public float InvertxRot;
private float yRot;
private float xCurrRot;
private float yCurrRot;
[SerializeField]
private Camera Camera;
[SerializeField]
private GameObject Player;
public float mouseSensetive;
private float xRotVelocity;
private float yRotVelocity;
[SerializeField]
private float smoothDampTime = 0.1f;
public string invertYString;



// Use this for initialization
void Start () {
mouseSensetive=3f;
}

// Update is called once per frame
void Update () {
MouseMove();
}

private void MouseMove()
{
xRot+=Input.GetAxis("Mouse Y")*mouseSensetive;
yRot+=Input.GetAxis("Mouse X")*mouseSensetive;
xRot=Mathf.Clamp(xRot,-90,90);

InvertxRot = xRot -(xRot*2);

if(SessionData.invertYBool == true){
    //Debug.Log("invertY is true");
    xCurrRot=Mathf.SmoothDamp(xCurrRot, xRot, ref xRotVelocity, smoothDampTime);
} else {
    //Debug.Log("invertY is false");
    xCurrRot=Mathf.SmoothDamp(xCurrRot, InvertxRot, ref xRotVelocity, smoothDampTime);
}






yCurrRot=Mathf.SmoothDamp(yCurrRot, yRot, ref yRotVelocity, smoothDampTime);

Camera.transform.rotation=Quaternion.Euler(xCurrRot,yCurrRot,0f);
Player.transform.rotation=Quaternion.Euler(0f,yCurrRot,0f);

}
}
