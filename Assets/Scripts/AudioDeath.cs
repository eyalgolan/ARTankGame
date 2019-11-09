using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioDeath : MonoBehaviour
{
    AudioSource audioBoom;
    Transform paren;
    // Start is called before the first frame update
    void Start()
    {
        paren = gameObject.transform.parent.parent;
        audioBoom = GetComponent<AudioSource>();
        gameObject.transform.position = transform.parent.position;
    }
    public void Activate()
    {
        if(paren != null)
        {
            transform.parent = paren;
            
        }
        else
        {
            Debug.Log("nullas");
        }
        audioBoom.Play();
        Destroy(gameObject, 3f);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
