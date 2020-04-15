using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instantiateEnemies : MonoBehaviour
{
    public Rigidbody enemies;
    [SerializeField] Transform[] pos;
    void Start()
    {   
    //    StartCoroutine(DoCheck());
       InvokeRepeating ("inst", 3f, 3f);
    }
    public void inst()
    {   
        Vector3 speed = new Vector3(1, 0, 0);
        int r = Random.Range(0, pos.Length);
        Vector3 position = pos[r].position;
        Rigidbody clone = Instantiate(enemies, position, transform.rotation);
        clone.velocity = transform.TransformDirection(speed * 3);
    }
    // IEnumerator DoCheck()
    // {   
    //     for (int i = 0; i < 5; i++)
    //     {
    //         inst();
    //         yield return new WaitForSeconds(.05f);
    //     }
    // }
}
