using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    public static Transform point;
    // Start is called before the first frame update
    void Awake()
    {
        point = gameObject.transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
