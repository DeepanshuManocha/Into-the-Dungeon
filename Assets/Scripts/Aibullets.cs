using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aibullets : MonoBehaviour
{
    public float speed;

    private Transform Player;
    private Vector3 target;

    public bool hit;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector3(Player.position.x, Player.position.y, Player.position.z);

    }
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if (transform.position.x == target.x && transform.position.y == target.y && transform.position.z == target.z)
        {
            Destroyprojectile();
        }
    }
    void OnTriggerEnter(Collider col)   
    {
        if (col.CompareTag("Player"))
        {   Debug.Log("HIt"+hit);
            hit = true;
            Debug.Log("HIt"+hit);
            Destroyprojectile();


        }
    }
    void Destroyprojectile()
    {
        Destroy(gameObject);
    }
}

