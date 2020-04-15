using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wincondition : MonoBehaviour
{
    public GameObject win;
    public void OnCollisionEnter(Collision coll)
    {   
         if(coll.gameObject.name=="Win")
        {
        Debug.Log("collisuion");
        win.SetActive(true);
         }
    }
}
