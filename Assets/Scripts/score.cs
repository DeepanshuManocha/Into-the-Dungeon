using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    Text score1;
    public shoot enemy;
    // Start is called before the first frame update
    void Start()
    {
        score1 = GetComponent<Text>();
        //score1.text = ("Player 1 score = \n" + p1.enthusiasm +"\n" + p1.network + "\n" + p1.capital);
    }

    // Update is called once per frame
    void Update()
    {
        score1.text =("" + enemy.enemycount) ;
    }
}
