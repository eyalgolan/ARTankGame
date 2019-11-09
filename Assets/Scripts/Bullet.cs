using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Utilities")]
    private Transform target;
    Rigidbody rb;
    public GameObject explosion;
    public GameObject hitEffect;
    public string objectToIgnore;
    public AudioSource smallExplosion;
    public LongClickButton buttonTimer;
    GameObject hit;
    public GameObject soundPrefab;

    [Header("measures")]
    public float speed = 100f;
    float damage = 9f;
    public float force;
    public float radius = 1f;
    public float explosionForce = 10f;

    public void Seek(Transform tmpTarget)
    {
        target = tmpTarget;
    }
    void Awake()
    {
        
    }
    // Start is called before the first frame update
    public void Start()
    {
        /*string playerName = "";
        if (gameObject.transform.parent.name.Contains("P1"))
        {
            playerName = "player1";
        }
        if (gameObject.transform.parent.name.Contains("P2"))
        {
            playerName = "player2";
        }
        
        GameObject tmp = GameObject.Find("Fire" + playerName);
        if (tmp != null)
        {
            buttonTimer = tmp.GetComponent<LongClickButton>();
        }
        if (buttonTimer == null)
        {
            Debug.Log("button is null");
        }
        else
        {
            force = buttonTimer.force;
        }*/
        if(force == 0)
        {
            Debug.Log("force is" + force);
            force = 300;
        }
        smallExplosion = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * force);
    }
    public void ShootByForce(float amount)
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * amount);
    }
    // Update is called once per frame
    void Update()
    {
    
    }
    void OnTriggerEnter(Collider other)
    {
        hit = other.gameObject;
        Debug.Log("bullet trigger with " + other.name);
        if (other.gameObject.name.Equals(objectToIgnore) || other.gameObject.tag == "Wall")
        {
            Physics.IgnoreCollision(other, GetComponent<Collider>());
            return;
        }
        if (other.gameObject.tag == "Floor")
        {
            Collider cc = gameObject.GetComponent<Collider>();
            cc.isTrigger = false;
        }
        if (other.gameObject.tag == "Player")
        {
            Collider cc = gameObject.GetComponent<Collider>();
            cc.isTrigger = false;
            Damage(other.transform);
        }
        Explode();
        Destroy(gameObject);
        return;
    }
    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.name.Equals(objectToIgnore))
        {
            Physics.IgnoreCollision(other.collider, GetComponent<Collider>());
            return;
        }
        if (other.gameObject.tag == "Wall")
        {
            Physics.IgnoreCollision(other.collider, GetComponent<Collider>());
            return;
        }
    }
    void OnCollisionEnter(Collision other)
    {
        hit = other.gameObject;
        Debug.Log("bullet trigger with " + other.gameObject.name);
        if (other.gameObject.name.Equals(objectToIgnore) || other.gameObject.tag == "Wall")
        {
            Physics.IgnoreCollision(other.collider, GetComponent<Collider>());
            return;
        }
        if (other.gameObject.tag == "Floor")
        {
            Collider cc = gameObject.GetComponent<Collider>();
            cc.isTrigger = false;
        }
        if (other.gameObject.tag == "Player")
        {
            Collider cc = gameObject.GetComponent<Collider>();
            cc.isTrigger = false;
            Damage(other.transform);
        }
        Explode();
        Destroy(gameObject);
        return;
        /* 
        Debug.Log("bullet collision enter");
        Explode();
        Physics.IgnoreCollision(other.collider, GetComponent<Collider>());
        if (other.gameObject.Equals(objectToIgnore)){
            Physics.IgnoreCollision(other.collider, GetComponent<Collider>());
            return;
        }
        */
    }
    void Damage(Transform player)
    {
        if (player.gameObject.name.Equals(objectToIgnore))
        {
            Debug.Log("same object");
            return;
        }
        PlayerDamage pd = player.GetComponent<PlayerDamage>();
        if(pd == null)
        {
            return;
        }
        pd.TakeDamage(damage);
        if(pd.health <= 0)
        {
            HitTarget();
        }
    }
    void Explode()
    {
        GameObject newSound = Instantiate(soundPrefab,hit.transform.position,hit.transform.rotation);
        if(smallExplosion != null)
        {
            SoundObj so = newSound.GetComponent<SoundObj>();
            if(so != null)
            {
                so.GotHit();
            }

        }
        else
        {
            Debug.Log("smallExplosion is null as");
        }
        GameObject explode = (GameObject)Instantiate(hitEffect, transform.position, transform.rotation);
        Collider[] colliders = Physics.OverlapSphere(transform.position,radius);
        foreach(Collider nearbyObject in colliders)
        {
            Rigidbody rigi = nearbyObject.GetComponent<Rigidbody>();
            if(rigi != null)
            {
                rb.AddExplosionForce(explosionForce,transform.position,radius);
                if(rigi.gameObject.tag == "Player")
                {
                    PlayerDamage pd = rigi.gameObject.GetComponent<PlayerDamage>();
                    pd.TakeDamage(0.5f);
                }
            }

        }
        Destroy(explode, 0.5f);
    }
    void HitTarget()
    {
        GameObject exp = (GameObject)Instantiate(explosion,transform.position,transform.rotation);
        ParticleSystem e = exp.GetComponent<ParticleSystem>();
        e.Play();
        Destroy(e,0.5f);
        Destroy(exp, 0.5f);
    }
}
