using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject explosionPrefab;
    public Transform gunEnd;
    public float coolDown = 20f;
    public float counter = 0;
    public Quaternion rotation;
    public AudioSource gunSound;


    private void Start()
    {
        gunSound = GetComponentInParent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Transform transformOfTank = gameObject.GetComponentInParent<Transform>();
        rotation = transformOfTank.localRotation;


        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log(hit.collider.tag);
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            Debug.Log("Didnt hit");
        }

        if (hit.collider != null && hit.collider.tag == "PlayerTank" && coolDown < counter)
        {
            counter = 0;
            GameObject bullet = Instantiate(bulletPrefab, gunEnd.position, rotation);
            GameObject explosion = Instantiate(explosionPrefab, gunEnd.position, rotation);
            if (gunSound != null)
            {
                gunSound.Play();
            }
        }
        counter++;
    }
}
