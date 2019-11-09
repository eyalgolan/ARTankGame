using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundObj : MonoBehaviour
{
    public AudioSource audioS;
    float timeNow = 4.5f;
    AudioSource boom;
    bool isActive;
    // Start is called before the first frame update
    void Start()
    {
        boom = GetComponent<AudioSource>();
        Debug.Log(boom);
    }
    public void GotHit()
    {
        isActive = true;
        //boom.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        timeNow -= Time.deltaTime;
        if(timeNow <= 0)
        {
            Destroy(gameObject);
        }
    }
    Component CopyComponent(Component original, GameObject destination)
    {
        System.Type type = original.GetType();
        Component copy = destination.AddComponent(type);
        // Copied fields can be restricted with BindingFlags
        System.Reflection.FieldInfo[] fields = type.GetFields();
        foreach (System.Reflection.FieldInfo field in fields)
        {
            field.SetValue(copy, field.GetValue(original));
        }
        return copy;
    }
}
