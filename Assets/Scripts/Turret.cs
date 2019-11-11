using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{

    [Header("UnitySetupFields")]
    private Transform target;
    public Transform partToRotate;
    public float speed = 2f;
    public GameObject bulletPrefab;
    public Transform firePoint;
    string playersTag = "Player";
    public EndGame gameEnded;

    [Header("Attributes")]
    public float range = 2.5f;
    public float fireRate = 2f;
    public float fireCountdown = 0f;

    // Start is called before the first frame update
    void Start()
    {
        GameObject tmp = GameObject.Find("EndGame");
        if(tmp != null)
        {
            gameEnded = tmp.GetComponent<EndGame>();
        }
        speed = 2f;
        playersTag = "Player";
        InvokeRepeating("UpdateTarget",13f,4.5f);
    }
    void UpdateTarget()
    {

        GameObject[] players = GameObject.FindGameObjectsWithTag(playersTag);
        if(players.Length == 0)
        {
            Debug.Log("no players");
            return;
        }
        float shortestDistance = Mathf.Infinity;
        GameObject nearestPlayer = null;
        foreach(GameObject player in players)
        {
            float distanceFromPlayer = Vector3.Distance(transform.position, player.transform.position);
            if(distanceFromPlayer < shortestDistance)
            {
                shortestDistance = distanceFromPlayer;
                nearestPlayer = player;
            }
        }
        if(nearestPlayer != null && shortestDistance <= range)
        {

            target = nearestPlayer.transform;
        }
        else
        {
            target = null;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            return;
        }
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation,lookRotation,Time.deltaTime*speed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        if(fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 2f / fireRate;
        }
        fireCountdown -= Time.deltaTime;
        
    }

    public void Shoot()
    {
        if (gameEnded.ended)
        {
            return;
        }
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        GameObject planeStage = GameObject.Find("Ground Plane Stage");
        if (planeStage != null)
        {
            bulletGO.transform.parent = gameObject.transform;
        }
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        if (bullet != null)
        {
            bullet.Seek(target);
        }
    }
    /*void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,range);
    }*/
}
