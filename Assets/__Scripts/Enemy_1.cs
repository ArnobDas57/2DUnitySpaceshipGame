using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_1 : MonoBehaviour
{
    [Header("Set in Inspector: Enemy")]
    //This public field allow the user to change the speed of the ship
    public float speed = 10f;      
  
    protected BoundsCheck bndCheck;
    void Awake() //this method takes place before any other method so it can get the BoundsCheck class
    {
        bndCheck = GetComponent<BoundsCheck>();
    }

    public Vector3 pos //this property acts like a field that gets and sets the player position
    {
        get
        {
            return (this.transform.position);
        }

        set
        {
            this.transform.position = value;
        }
    }
    public virtual void Move() //this method makes the enemy move downwards, in the y-direction
    {
        Vector3 tempPos = pos;
        tempPos.y -= speed * Time.deltaTime;
        pos = tempPos;
    }
    void Update() //for every frame, this method calls Move(); to make the enemy move 
    {
        Move();

        if (bndCheck != null && bndCheck.offDown) //if the enemy GameObject goes off the screen, it is destroyed
        {           
                Destroy(gameObject);   
        }
    }
}
