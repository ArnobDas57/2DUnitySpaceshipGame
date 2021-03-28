using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    static public Hero S; //Singleton class that allows one instance of S to be created

    [Header("Set in Inspector")]
    //These public fields control the ship movement
    public float speed = 30;
    public float rollMult = -45;
    public float pitchMult = 30;
    public float gameRestartDelay = 2f;

    private GameObject lastTriggerGo = null;
    void Update() //this method takes vertical and horizontal inputs per frame then allows the player to move the ship 
    {
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        Vector3 pos = transform.position;
        pos.x += xAxis * speed * Time.deltaTime;
        pos.y += yAxis * speed * Time.deltaTime;
        transform.position = pos;

        //allows the user to rotate the ship for more dynamic feeling
        transform.rotation = Quaternion.Euler(yAxis * pitchMult, xAxis * rollMult, 0);
    }
    void Awake() //this method initilizes Hero S before the game starts
    {
        if (S == null)
        {
            S = this; //Singleton is initialized
        }

        else
        {
            Debug.LogError("Hero.Awake() - Attempted to assign second Hero.S!");
        }
    }
    void OnTriggerEnter(Collider other) //this method occurs when the Gameobjects collide
    {
        Transform rootT = other.gameObject.transform.root;
        GameObject go = rootT.gameObject;

        if (go == lastTriggerGo)
        {
            return;
        }

        lastTriggerGo = go;

        if (go.tag == "Enemy") //if the player collides with the enemy, both player and enemy are destroyed
        {
            Destroy(go);
            Destroy(this.gameObject);
        }

        else
        {
            print("Triggered by non-Enemy: " + go.name);
        }
    }
}
