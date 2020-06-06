using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector2 startVelocity;
    public Rigidbody2D a;
    public Vector2 startPosition;
    public double mass;
    //public Rigidbody2D star;
    //public int power;
    public int index;
    public GameObject explosion; // drag your explosion prefab here
    public bool sun;


        void Start()
    {

        PlanetaryObjects.planets.Add(a);
        index = PlanetaryObjects.planets.Capacity - 1;
        a.transform.position = startPosition;
        a.velocity = startVelocity;
        InvokeRepeating("Gravity", 0, 0.000015f);
    }

    // Update is called once per frame
    void Update()
    {
   
    }

    void Gravity()
    {
        foreach(Object planet in PlanetaryObjects.planets)
        {
            if (planet==null||planet.GetInstanceID() == a.GetInstanceID())
            {
                continue;
            }
            Rigidbody2D b = (Rigidbody2D)planet;
            Vector2 difference = -a.transform.position + b.transform.position;
            decimal dist = (decimal)difference.magnitude*50000;
            decimal gMagnitude = (decimal)(6.7 * b.mass * a.mass) / (dist * dist);
            Vector2 difference2 = -a.transform.position + b.transform.position;
            Vector2 direction = difference2.normalized;
      
            Vector2 gravityVector = (direction * (float)gMagnitude);
            a.GetComponent<Rigidbody2D>().AddForce(gravityVector, ForceMode2D.Force);
        }
       
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        Sun.masss += a.mass;
        Sun.location = a.transform.position;
        Sun.direction += a.velocity;
        double maass = a.mass;
        double maass2 = other.gameObject.GetComponent<Rigidbody2D>().mass;
        if (!sun && maass<maass2)
        {
            PlanetaryObjects.planets[PlanetaryObjects.planets.IndexOf(a)] = null;
            a.gameObject.SetActive(false);
        }
        else
        {
            a.GetComponent<Rigidbody2D>().position = Sun.location;
            a.GetComponent<Rigidbody2D>().mass = (float)Sun.masss;
            a.GetComponent<Rigidbody2D>().velocity = Sun.direction*(float)(1/Sun.masss);
            Sun.masss = 0;
            Sun.location = new Vector2(0, 0);

            Sun.direction = new Vector2(0, 0);
        }


    }
}
