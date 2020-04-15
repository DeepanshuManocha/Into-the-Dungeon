using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emeny: MonoBehaviour
{
  
     public float speed;
    public bool moveright;
      void OnTriggerEnter(Collider turn)
    {
        if(turn.gameObject.tag == "turn")
        {
            moveright = false;
        }
      
        
        else if(turn.gameObject.tag == "turn1")
        {
            
                moveright = true;

            
        }
    }
   


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(moveright)
        {
            transform.Translate(0,1*Time.deltaTime*speed,0);
            // transform.localScale = new Vector3(1.5f,1.5f,1.5f);
        }
        else
        {
            transform.Translate(0 , -1*Time.deltaTime*speed,0);
            // transform.localScale = new Vector3(1.5f,-1.5f,1.5f);
        }
    }
}
