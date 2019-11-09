using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [Header("UnitySetupFields")]
    public float speed = 2f;
    public GameObject bulletPrefab;
    public Transform firePoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Shoot(float amount)
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        GameObject planeStage = GameObject.Find("Ground Plane Stage");
        if (planeStage != null)
        {
            bulletGO.transform.parent = gameObject.transform;
        }
        Bullet bullet = bulletGO.GetComponent<Bullet>(); 
        if (bullet != null)
        {
            bullet.ShootByForce(amount);
        }
    }
}
