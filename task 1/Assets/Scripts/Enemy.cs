using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float Movespeed;
    private GameObject player;
    //public Transform target;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Champ");

    }
    private void Update()
    {
        if (player == null)
        {
            //Vector3 playerPosition = PlayerController.Instance.transform.position;
            Move();
        }
      
    }
    public virtual void Move() // use of polymorph
    {
        //Vector3 playerPosition = PlayerController.Instance.transform.position;
        //transform.LookAt(playerPosition);
        //transform.position += transform.forward * Movespeed * Time.deltaTime;
        transform.LookAt(player.transform.position); // Look at the player
        transform.position += transform.forward * Movespeed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            Destroy(this.gameObject);
            KillCounter.KillValue++;
        }
    }
}
