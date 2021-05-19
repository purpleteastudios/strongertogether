using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoDPlayerMovement : MonoBehaviour
{
    //Variables
     public float speed = 7.0F;
     public float jumpSpeed = 8.0F; 
     public float gravity = 20.0F;
     private Vector3 moveDirection = Vector3.zero;
 
     void Update() {
         CharacterController controller = GetComponent<CharacterController>();
         
         // is the controller on the ground?
         if (controller.isGrounded) {
             //Feed moveDirection with input.
             moveDirection = new Vector3(0, 0, Input.GetAxis("Horizontal"));
             moveDirection = transform.TransformDirection(moveDirection);
             //Multiply it by speed.
             if(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift) ) {
             moveDirection *= (speed*2);
             } else {
             moveDirection *= speed;}
             //Jumping
             if (Input.GetButton("Jump") || Input.GetKey(KeyCode.UpArrow))
                 moveDirection.y = jumpSpeed;
             
         }
         //Applying gravity to the controller
         moveDirection.y -= gravity * Time.deltaTime;
         //Making the character move
         controller.Move(moveDirection * Time.deltaTime);
     }
 }
