using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueRango : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    private Transform playerPosition;
    public float bulletVelocity = 100;

    // Start is called before the first frame update
    private void Start()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
       
    }
    void shootPlayer()
    {
        Vector3 playerDirection= playerPosition.position - transform.position;

        transform.Translate(Vector3.forward * 15 * Time.deltaTime);

        GameObject newBullet ;

        newBullet = Instantiate(bulletPrefab,bulletSpawnPoint.position,bulletSpawnPoint.rotation);

        newBullet.GetComponent<Rigidbody>().AddForce(playerDirection*bulletVelocity,ForceMode.Force);

    }
}
