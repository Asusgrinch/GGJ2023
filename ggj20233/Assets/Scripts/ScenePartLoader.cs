using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum CheckMethod
{
    Distance,
    Trigger
}
public class ScenePartLoader : MonoBehaviour
{

    public Transform player;
    public CheckMethod checkMethod;
    public float loadRange;

    private bool isLoaded;
    private bool ShouldLoad;

    // Start is called before the first frame update

    void Start()
    {
        //verify state scene
        if(SceneManager.sceneCount > 0)
        {
            for(int i =0; i < SceneManager.sceneCount; i++)
            {
                Scene scene= SceneManager.GetSceneAt(i);
                if(scene.name == gameObject.name)
                {
                    isLoaded= true;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(checkMethod == CheckMethod.Distance)
        {
            DistanceCheck();
        }
        else if (checkMethod == CheckMethod.Trigger)
        {
            TriggerCheck();
        }

    }
    void DistanceCheck()
    {
        if(Vector3.Distance(player.position, transform.position) < loadRange)
        {
            LoadScene();
        }
        if (Vector3.Distance(player.position, transform.position) > loadRange)
        {
            UnloadScene();
        }
    }

    void LoadScene()
    {
        if(!isLoaded)
        {
            SceneManager.LoadSceneAsync(gameObject.name, LoadSceneMode.Additive);
            isLoaded = true;
        }
    }
    void UnloadScene()
    {
        if(isLoaded) 
        {
            SceneManager.UnloadSceneAsync(gameObject.name);
            isLoaded = false;    
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ShouldLoad = true;
            Debug.Log("entrando");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ShouldLoad = false;
            Debug.Log("Saliendop");
        }
    }

    void TriggerCheck()
    {
        if (ShouldLoad)
        {
            LoadScene();
        }
        else
        {
            UnloadScene();
        }
    }
}
