using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 500f;
    public float bulletLifeSpan = 20f;
    public float timer = 0;
    public Rigidbody rb;
    public Vector3 lastVelocity;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(gameObject.transform.forward.normalized * 1000);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        lastVelocity = rb.velocity;
        timer++;

        if (timer > bulletLifeSpan)
        {
            DestroyThisBullet();
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            float speed = lastVelocity.magnitude;
            Vector3 newDirection = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);

            rb.velocity = newDirection * Mathf.Max(speed, 0f);


        }
        if (collision.gameObject.tag == "PlayerTank")
        {
            DestroyThisBullet();
            collision.gameObject.SetActive(false);
            GameManger.playerActive = false;
        }
        if (collision.gameObject.tag == "Tank")
        {
            DestroyThisBullet();
            
            collision.gameObject.SetActive(false);
        }
        if (collision.gameObject.tag == "Bullet")
        {
            DestroyThisBullet();
        }
    }

    public void DestroyThisBullet()
    {
        Destroy(this.gameObject);
    }
}
