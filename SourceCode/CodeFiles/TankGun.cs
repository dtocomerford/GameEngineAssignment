using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankGun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject explosionPrefab;
    public Transform gunEnd;
    public int numberOfBullets = 10;
    public ArrayList bulletsList = new ArrayList();
    public AudioSource gunSound;

    private void Start()
    {
        gunSound = GetComponentInParent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && bulletsList.Count < numberOfBullets)
        {
            
            GameObject bullet = Instantiate(bulletPrefab, gunEnd.position, TankMovement.wantedRotation);
            GameObject explosion = Instantiate(explosionPrefab, gunEnd.position, TankMovement.wantedRotation);
            if (gunSound != null)
            {
                gunSound.Play();
            }
        }

    }
}
