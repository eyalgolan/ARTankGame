using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    Rigidbody rb;
    public float speed = 100f;
    public GameObject explosion;

    float damage = 2f;
    public void Seek(Transform tmpTarget)
    {
        target = tmpTarget;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Vector3 forward = new Vector3(-500,500,10);
        rb.AddForce(transform.forward * 200);

    }

    // Update is called once per frame
    void Update()
    {
        /*if(target == null)
        {
            Destroy(gameObject);
            return;
        }
       
        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;
        if(dir.magnitude <= distanceThisFrame)
        {
            return;
        }
        transform.Translate(dir.normalized * distanceThisFrame,Space.World);
        transform.LookAt(target);*/
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("bullt triggered with" + other.gameObject.tag);
        if (other.gameObject.tag == "Player")
        {
            Collider cc = gameObject.GetComponent<Collider>();
            cc.isTrigger = false;
            Damage(other.transform);

            return;
        }
        if (other.gameObject.tag == "Wall")
        {
            Physics.IgnoreCollision(other, GetComponent<Collider>());
            return;
        }
      
        if (other.gameObject.tag == "Floor")
        {
            Collider cc = gameObject.GetComponent<Collider>();
            cc.isTrigger = false;
        }
        Destroy(gameObject,1f);
        return;
    }
    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Wall")
        {
            Physics.IgnoreCollision(other.collider, GetComponent<Collider>());
            return;
        }
    }
    void Damage(Transform player)
    {
        Destroy(gameObject,1f);
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
    void HitTarget()
    {
        GameObject exp = (GameObject)Instantiate(explosion,transform.position,transform.rotation);
        ParticleSystem e = exp.GetComponent<ParticleSystem>();
        e.Play();
        Destroy(e,0.5f);
        Destroy(exp, 0.5f);
    }
}
