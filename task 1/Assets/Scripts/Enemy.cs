using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float Movespeed;
    [SerializeField] private GameObject Player;

    //public Transform target;
    void Start()
    {
       //unsure why this isn't working 
       //target = GameObject.FindGameObjectWithTag("Champ").GetComponent<Transform>();
    }
    private void Update()
    {
        Move();
    }
    public virtual void Move() // use of polymorph
    {
       transform.LookAt(Player.transform);
       transform.position += transform.forward * Movespeed * Time.deltaTime;
    }
    
}
