using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : Enemy //use of inheritence
{
    // Update is called once per frame
    void Update()
    {
        Move();
    }
    public override void Move()
    {
        base.Move();
    }
}