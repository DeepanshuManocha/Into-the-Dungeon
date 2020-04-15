using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class shoot : MonoBehaviour
{
    // public Button shootbtn;
    public GameObject music;
    public Camera fpsCam;
    public int damage = 1;
    public int enemycount=0;
    public int count;
    void Update()
    {
        // shootbtn.onClick.AddListener (onShoot);
        if (Input.GetButtonDown("Fire1"))
        {
            onShoot();
        }
        if(count==3)
        {
            SceneManager.LoadScene("WinGame");
        }
    }

    void onShoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit))
        {
            Debug.Log("hit");
            EnemiesShreyansh target = hit.transform.GetComponent<EnemiesShreyansh>();
            destroySpwanningStation spwanningTarget = hit.transform.GetComponent<destroySpwanningStation>();
            if (target != null)
            {
                target.Takedamage(damage);
                enemycount++;

                music.SetActive(true);
            }
            if (spwanningTarget != null)
            {   
                count++;
                spwanningTarget.Takedamage(damage);
            }

        }
    }
}
