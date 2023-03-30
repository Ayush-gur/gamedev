using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShooter : MonoBehaviour
{
    public GameObject[] BulletPrefabs;
    public Transform bulletPos;
    public float bulletSpeed = 10f;

    bool shoot = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
           Shoot();
        }
    }
    void FixedUpdate()
    {
        if (shoot)
        {
            Shoot();
            shoot = false;
        }
    }
    void Shoot()  
    {
        GameObject bulletSpawn = Instantiate(BulletPrefabs[0], bulletPos.position, Quaternion.identity);
        bulletSpawn.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, bulletSpeed);
        
    }
    

}
