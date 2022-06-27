using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    
    public GameObject bulletPrefab;
    public float speed = 10f;
    public float xLimit = 7f;
    public float reloadTime = 0.5f;

    float elapsedTime = 0f;
    public GameManager gameManager;


    void Update()
    {
        elapsedTime += Time.deltaTime;

        float xInput = Input.GetAxis("Horizontal");
        transform.Translate(xInput * speed * Time.deltaTime, 0f, 0f);

        Vector3 position = transform.position;
        position.x = Mathf.Clamp(position.x, -xLimit, xLimit);
        transform.position = position;

        if(Input.GetButtonDown("Jump") && elapsedTime > reloadTime)
        {
            Vector3 spawnPos = transform.position;
            Vector3 spawnPos2 = transform.position;

            spawnPos += new Vector3(-0.5f, 1.2f, 0);
            spawnPos2 += new Vector3(0.5f, 1.2f, 0);

            Instantiate(bulletPrefab, spawnPos, Quaternion.identity);
            Instantiate(bulletPrefab, spawnPos2, Quaternion.identity);
            elapsedTime = 0f;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameManager.PlayerDied();
    }
}
