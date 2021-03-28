using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Main : MonoBehaviour
{
    static public Main S; //Singleton class that allows one instance of S to be created

    [Header("Set in Inspector")] 
    //these public fields create an enemy prefabs array and allows the player to control the enemy spawn rate 
    public GameObject[] prefabEnemies;
    public float enemySpawnPerSecond = 0.5f;
    public float enemyDefaultPadding = 1.5f;

    private BoundsCheck bndCheck;

    void Awake() //this method occurs before any other method and gets the BoundsCheck component
    {
        S = this;

        bndCheck = GetComponent<BoundsCheck>();

        //the SpawnEnemy method is invoked once in 2 seconds
        Invoke("SpawnEnemy", 1f / enemySpawnPerSecond);
    }
    public void SpawnEnemy() //this method randomly chooses an enemy prefab to instantiate
    {
        int ndx = Random.Range(0, prefabEnemies.Length);
        GameObject go = Instantiate<GameObject>(prefabEnemies[ndx]);

        //the enemy is positioned above the screen with a random x position
        float enemyPadding = enemyDefaultPadding;
        if(go.GetComponent<BoundsCheck>() != null)
        {
            enemyPadding = Mathf.Abs(go.GetComponent<BoundsCheck>().radius);
        }

        //the initial position is set for the enemy that is spawned
        Vector3 pos = Vector3.zero;
        float xMin = -bndCheck.camWidth + enemyPadding;
        float xMax = bndCheck.camWidth - enemyPadding;
        pos.x = Random.Range(xMin, xMax);
        pos.y = bndCheck.camHeight + enemyPadding;
        go.transform.position = pos;

        Invoke("SpawnEnemy", 1f / enemySpawnPerSecond); //the spawnEnemy() method is invoked
    }
    
}
