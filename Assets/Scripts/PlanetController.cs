using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetController : MonoBehaviour
{
    public GameObject[] Planets; //array untuk prefabs awan
    //quee to hold the clouds<
    Queue<GameObject> availablePlanets = new Queue<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        //add the  clouds to  the queue (enqueue them)
        availablePlanets.Enqueue (Planets [0]);
        availablePlanets.Enqueue (Planets [1]);
        availablePlanets.Enqueue (Planets [2]);
        //call the movePlanetDown function every 20 seconds
        InvokeRepeating("MovePlanetDown", 0, 20f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //fungsi unruk dequeue awan,dan set isMoving flag to true
    //jdi awan bakal turun terus
    void MovePlanetDown()
    {
        EnqueuePlanets();
        //kalo queue nya abis bakal balik lg
        if(availablePlanets.Count == 0)
            return;
        //get a cloud from queue
        GameObject aPlanet = availablePlanets.Dequeue ();
        //set the cloud isMoving flag to True
        aPlanet.GetComponent<Planet> ().isMoving = true;
    }

    //fungsi untuk enqueue planet yang ada di bawah layar yang tidak bergerak
    void EnqueuePlanets()
    {
        foreach(GameObject aPlanet in Planets)
        {
            if((aPlanet.transform.position.y < 0) && (!aPlanet.GetComponent<Planet>().isMoving))
            {
        //reset the cloud position
                aPlanet.GetComponent<Planet>().ResetPosition();

        //enqueue the clouds
                availablePlanets.Enqueue(aPlanet);
            }
        }
    }
}
