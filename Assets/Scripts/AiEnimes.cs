using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiEnimes : MonoBehaviour
{   
public float speed;
public float stoppingDistance;
public float retratDistance;
private float TimeBtwShots;
public float startTimeBtwShots;
public GameObject projectile;
private Transform player;
public Transform Player;

public GameObject user;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        TimeBtwShots = startTimeBtwShots;
    }

    public void OnCollisionEnter(Collision coll)
    {   
        if(coll.gameObject.name=="First Person Camera")
        {
            Debug.Log("collisuion");
            user.SetActive(true);
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Player.position - transform.position) , speed * Time.deltaTime);
        if(Vector3.Distance(transform.position,Player.position)>stoppingDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, Player.position, speed *Time.deltaTime);
           

        }
        else if(Vector3.Distance(transform.position,Player.position)<stoppingDistance && Vector3.Distance(transform.position,Player.position)>retratDistance)
        {
            transform.position = this.transform.position;
            
        }
        else if(Vector3.Distance(transform.position,Player.position)<retratDistance)
        {
             transform.position = Vector3.MoveTowards(transform.position, Player.position, -speed *Time.deltaTime);
             
        }

        if(TimeBtwShots<=0)
        {
           Instantiate(projectile,transform.position,Quaternion.identity);
           TimeBtwShots =startTimeBtwShots;
        }
        else
        {
             TimeBtwShots-= Time.deltaTime;
        }
    }
}
