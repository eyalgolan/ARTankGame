using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform target;
    public float speed = 0.0000001f;
    // Start is called before the first frame update
    void Start()
    {
        target = WayPoint.point;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed *Time.deltaTime,Space.World);
    }
}
