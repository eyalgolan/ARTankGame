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

    void OnCollisionEnter(Collision c)
    {
        // force is how forcefully we will push the player away from the enemy.
        float force = 3;
 
        // If the object we hit is the enemy
        if (c.gameObject.tag == "enemy")
        {
            // Calculate Angle Between the collision point and the player
             Vector3 dir = c.contacts[0].point - transform.position;
             // We then get the opposite (-Vector3) and normalize it
            dir = -dir.normalized;
             // And finally we add force in the direction of dir and multiply it by force. 
             // This will push back the player
            GetComponent<Rigidbody>().AddForce(dir*force);
        }
    }
}
