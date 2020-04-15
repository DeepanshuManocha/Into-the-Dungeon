using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroySpwanningStation : MonoBehaviour
{
    public int health = 10;
    public void Takedamage(int damage)
    {
        health -= damage;
        print(health);
        if (health == 0)
        {
            die();
        }
    }

    void die()
    {
        Destroy(gameObject);
        Debug.Log("destroy");
    }

}
