using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = System.Random;

public class GrassEncounter : MonoBehaviour
{
    private Random encounterChance = new Random();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider thing)
    {

        Debug.Log("Collided");

        if (thing.transform.tag != "Player")
        {
            return;
        }



        int num = encounterChance.Next(100);

        if (num > 70)
        {
            SceneManager.LoadScene("Fight");
        }
    }
}
