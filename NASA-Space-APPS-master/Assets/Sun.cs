using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    public static double masss;
    public static Vector2 location;
    public static Vector2 direction;
    public static GameObject planet;
    public GameObject planett;
    void Start()
    {
        masss = 0;
        planet = planett;
    }


    // Update is called once per frame
    void Update()
    {

    }
    public static void PCollision()
    {
          
            GameObject newPlanet = Instantiate(planet) as GameObject;
            newPlanet.GetComponent<Rigidbody2D>().position = location;
            newPlanet.GetComponent<Rigidbody2D>().mass = (float)masss;
            newPlanet.GetComponent<Rigidbody2D>().velocity = direction;
            masss = 0;
            location = new Vector2(0, 0);

            direction = new Vector2(0, 0);

    }
}
