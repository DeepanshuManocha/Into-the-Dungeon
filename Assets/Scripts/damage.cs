using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class damage : MonoBehaviour
{
    //public SakeScreen shake;
    public int count;
    public GameObject end;
    private Animation anim;

    void Start()
    {
        anim=gameObject.GetComponent<Animation>();
    }

    //public Aibullets damageByBullets;

    void OnTriggerEnter(Collider collision)
    {
        Debug.Log("inside coliision enter");
        if (collision.gameObject.tag=="bullets")
        {
            count++;



            
            // Debug.Log("OBject destroyed");
            // SceneManager.LoadScene("EndScene");
        }
        // else if (damageByBullets.hit == true)
        // {
        //     shake.shakeScreen();
        //     count++;
        //     print("count------" + count);
        // }
        Debug.Log(count);

    }
    public void Update()
    {
        if(count==10)
        {
            Debug.Log("OBject destroyed");
            // SceneManager.LoadScene("EndScene");
            end.SetActive(true);
            if(end.activeSelf==(true))
            {
                anim.Play("down");
            }
            
        }
    }
}
