using System;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Needs : MonoBehaviour, INpc
{
    private int hungry;
    private int tired;
    public GameObject floor;
    private GameObject placeSleep;
    private GameObject placeWork;
    private GameObject placeEat;
    public NavMeshAgent agent;
    private Vector3 _dest;
    
    void Start()
    {
        placeSleep = floor.GetComponent<MapData>().home;
        placeWork = floor.GetComponent<MapData>().work;
        placeEat = floor.GetComponent<MapData>().kitchen;
        hungry = Random.Range(0, 100);
        tired = Random.Range(0, 100);
        InvokeRepeating(nameof(IncreaseNeeds), 2.0f, 1.0f);
        //InvokeRepeating(nameof(logNeeds), 0.0f, 5.0f);
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    void IncreaseNeeds()
    {
        hungry++;
        tired++;
        // Debug.Log("Decreased Needs for NPC");
        // Debug.Log(sleep);
        // Debug.Log(hunger)
    }
    
    
    //When the Primitive collides with the walls, it will reverse direction
    private void OnTriggerEnter(Collider place)
    {
        //place.GetComponent<Building>().interact(this);
        IInteract kram = place.GetComponent(typeof(IInteract)) as IInteract;
        kram.interact(this);
    }

    public void calculateNeeds()
    {
        Vector3 dest;
        string where;
        
        if (hungry > 80)
        {
            dest = placeEat.transform.position;
            where = "food";
        }
        else if (tired > 80)
        {
            dest = placeSleep.transform.position;
            where = "sleep";
        }
        else
        {
            dest = placeWork.transform.position;
            where = "work";
        }

        if (dest.ToString() == _dest.ToString())  return;

        Debug.Log(where);
        agent.SetDestination(dest);
        _dest = dest;
    }

    public void eat(int food = 50)
    {
        hungry -= food;
        if (hungry > 0) return;

        hungry = 0;
    }

    public void sleep(int amount = 0)
    {
        tired -= amount;
        if (tired > 0) return;

        tired = 0;
    }

    private void logNeeds()
    {
        Debug.Log("Sleep " + tired);
        Debug.Log("Hunger " + hungry);
    } 
}
