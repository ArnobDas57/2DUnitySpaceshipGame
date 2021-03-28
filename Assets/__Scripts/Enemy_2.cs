using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy_2 : Enemy_1 //this class inherits from Enemy_1 as it is also an enemy
{
    public int leftOrRight;

    public void Start() //at the start of each frame, this method creates a random number between 0 (inclusive) and 10 (exclusive) 
    {
        var random = new System.Random();
        leftOrRight = random.Next(0, 10);
    }

    public override void Move() //this method allows the second type of enemy to move on a 45 degree line downwards
    {
        Vector3 tempPos = pos;
        tempPos.y -= speed * Time.deltaTime;

        if (leftOrRight < 5) //if the random number is less than 5, the enemy goes left
        {
            tempPos.x -= speed * Time.deltaTime;
        }

        else //if the random number is greater than 5, the enemy goes right
        {
            tempPos.x += speed * Time.deltaTime;
        }

        pos = tempPos;
    }

    void Update() //for every frame, this method makes the enemy move 
    {
        Move();

        //if the enemy goes off the screen, either left border or right border, it is destroyed
        if ((bndCheck != null && bndCheck.offRight) || (bndCheck != null && bndCheck.offLeft))
        {           
                Destroy(gameObject);   
        }
    }
}
