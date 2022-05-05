using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    //this script is all about move & input


    public float Speed = 2.0f;
    public float MaxMovement = 2.0f;//boundry

    void Update()
    {
        //****************** Input & Move *********************
        float input = Input.GetAxis("Horizontal");            

        Vector3 pos = transform.position;
        // delclare a NEW vector3
        // initialized with the pose of gameobject at every frame

        pos.x = pos.x + (input * Speed * Time.deltaTime);

        if (pos.x > MaxMovement)
        { pos.x = MaxMovement; }
        if (pos.x < -MaxMovement)
        { pos.x = -MaxMovement; }

        transform.position = pos;
 
        //*****************************************************

    }
}
