
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class perseguir : MonoBehaviour
{
    public Transform player;
    NavMeshAgent enemigo;
    private Animator anim;




    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        enemigo = GetComponent<NavMeshAgent>();
        
        anim = GetComponentInParent<Animator>();
    }

    void Update()
    {
        enemigo.destination = player.position;
    }

    public void Pelear(Vector3 target)
    {
        enemigo.destination = target;
        enemigo.isStopped = false;

    }
    public void Atacar()
    {
        Pelear(player.position);
        //transform.LookAt(player, Vector3.up);
    }
    public void morir()
    {
        anim.SetBool("Death", true);
        enemigo.SetDestination(transform.position);
    }

}