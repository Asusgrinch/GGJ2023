using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public int rutina;
    public float cronometro;
    public float time_rutinas;
    public Animator ani;
    public Quaternion angulo;
    public float grado;
    public GameObject target;
    public bool atacando;
    public RangoBoss rango;
    public float speed;
    public GameObject[] hit;
    public int hit_select;

    ///disparo
    public GameObject bala_ball;
    public GameObject point;
    public List<GameObject> pool2 = new List<GameObject>();
    ///----------------////
    ///
    public int fase = 1;
    public float HP_Min;
    public float HP_Max;
    public bool muerto;

    private void Start()
    {
        ani= GetComponent<Animator>();
        target= GameObject.Find("Player");
    }

    public void Comportamiento_Boss()
    {
        if(Vector3.Distance(transform.position, target.transform.position) < 15)
        {
            var lookPos = target.transform.position - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            point.transform.LookAt(target.transform.position);

            if(Vector3.Distance(transform.position, target.transform.position) > 1 && !atacando)
            {
                switch(rutina)
                {
                    case 0:
                        //////WALK////
                        transform.rotation= Quaternion.RotateTowards(transform.rotation, rotation, 2);
                        ani.SetBool("walk", true);
                        ani.SetBool("run", false);

                        if (transform.rotation == rotation)
                        {
                            transform.Translate(Vector3.forward * speed * Time.deltaTime);
                        }

                        ani.SetBool("attack", false);

                        cronometro += 1 * Time.deltaTime;
                        if(cronometro > time_rutinas)
                        {
                            rutina = Random.Range(0, 5);
                            cronometro= 0;
                        }

                        break;

                    case 1:
                        //////run//////
                        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
                        ani.SetBool("walk", false);
                        ani.SetBool("run", true);

                        if (transform.rotation == rotation)
                        {
                            transform.Translate(Vector3.forward * speed * 2 * Time.deltaTime);
                        }

                        ani.SetBool("attack", false);
                        break;
                     case 2:
                        ///dispara///
                        if (fase == 2)
                        {
                            ani.SetBool("walk", false);
                            ani.SetBool("run", false);
                            ani.SetBool("attack", true);
                            ani.SetFloat("skills", 0.75f);
                            rango.GetComponent<CapsuleCollider>().enabled = false;
                            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 0.5f);
                        }
                        else
                        {
                            rutina = 0;
                            cronometro= 0;
                        }



                        break;

                }
            }
        }
    }
    public void Final_Ani()
    {
        rutina= 0;
        ani.SetBool("attack", false);
        atacando=false; 
        rango.GetComponent<CapsuleCollider>().enabled = true;
       // direction_skill = false;
    }

    //Melee//
    public void ColliderWeaponTrue()
    {
        hit[hit_select].GetComponent<SphereCollider>().enabled = true;
    }
    public void ColliderWeaponFalse()
    {
        hit[hit_select].GetComponent<SphereCollider>().enabled = false;
    }

    //Disparo//
    public GameObject Get_fire_ball()
    {
        for(int i = 0; i < pool2.Count; i++)
        {
            if (!pool2[i].activeInHierarchy)
            {
                pool2[i].SetActive(true);
                return pool2[i];
            }
        }
        GameObject obj = Instantiate(bala_ball, point.transform.position, point.transform.rotation) as GameObject;
        pool2.Add(obj);
        return obj;
    }

    public void Fire_Ball_Skill()
    {
        GameObject obj= Get_fire_ball();
        obj.transform.position= point.transform.position;
        obj.transform.rotation=point.transform.rotation;
    }
    public void BossVivo()
    {
        if (HP_Min < 500)
        {
            fase = 2;
            time_rutinas= 1; // <=====    tiempo en atacar
        }
    }
    private void Update()
    {
        if(HP_Min >0)
        {
            BossVivo();
        }
        else
        {
            if (!muerto)
            {
                ani.SetTrigger("dead");
                muerto= true;
            }
        }
    }
}
