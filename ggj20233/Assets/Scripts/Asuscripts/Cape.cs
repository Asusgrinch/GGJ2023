using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cape : MonoBehaviour
{
    public Material[] materials;
    Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = materials[0];
    }

    
    void Update()
    {
        
    }

    public void changeValue(int numCape)
    {
        rend.sharedMaterial = materials[numCape];
    }

    public void addLife(int damage)
    {
        
    }

    public void takeDamage(int life)
    {
        if (life <= 0)
        {
            Debug.Log("Game over");
            rend.sharedMaterial = materials[0];
        }
        else if (life >= 1 && life <= 5)
        {
            Debug.Log("1 life container");
            rend.sharedMaterial = materials[1];
        }
        else if (life >= 6 && life <= 10)
        {
            Debug.Log("2 life container");
            rend.sharedMaterial = materials[2];
        }
        else if (life >= 11 && life <= 15)
        {
            Debug.Log("3 life container");
            rend.sharedMaterial = materials[3];
        }
    }
}
