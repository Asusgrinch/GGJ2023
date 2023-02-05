using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    
    public Cape capa;
    
    public int life = 15;

    int count;
    
    void Start()
    {
        
        
        if (capa != null)
        {
            Debug.Log("cape find");
        }
        else
        {
            Debug.Log("cape lost :(");
        }
      
    }


    void Update()
    { 


        /*
        if (Input.GetKeyDown(KeyCode.L))
        {
            life++;
            Debug.Log("add life, value of count :::::: " + life);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            life--;
            Debug.Log("add life, value of count :::::: " + life);
        }

        if (life <= 0 )
        {
            Debug.Log("Game over");
        }else if(life >= 1 && life <= 5)
        {
            Debug.Log("1 life container");
        }else if (life >= 6 && life <= 10)
        {
            Debug.Log("2 life container");
        }else if (life >= 11 && life <= 15)
        {
            Debug.Log("3 life container");
        }else if (life >= 16 && life <= 20)
        {
            Debug.Log("4 life container");
        }

        
        switch (count)
        {
            case 5:
                capa.changeValue(1);
            break;

            case 10:
                capa.changeValue(2);
            break;

            case 15:
                capa.changeValue(3);
            break;

            case 20:
                capa.changeValue(0);
            break;

        }
        */

        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            life--;
            capa.takeDamage(life);
            Debug.Log("Value of life ::::: " + life);
        }

        if (collision.gameObject.tag == "Friend")
        {
            life++;
            Debug.Log("Value of life ::::: " + life);
        }
    }
}
