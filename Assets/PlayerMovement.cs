using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 3.0f;
    public float rotationSpeed = 10.0f;
    public float playerNumber;
    float translation;
    float rotation;
    void Update()
    {
        if(playerNumber==1) {
            translation = CrossPlatformInputManager.GetAxis("Player1Vertical") * speed;
            rotation = CrossPlatformInputManager.GetAxis("Player1Horizontal") * rotationSpeed;
        }
        else {
            translation = CrossPlatformInputManager.GetAxis("Player2Vertical") * speed;
            rotation = CrossPlatformInputManager.GetAxis("Player2Horizontal") * rotationSpeed;
        }
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);
    }
}
