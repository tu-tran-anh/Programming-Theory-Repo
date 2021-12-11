using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float xRange = 13f;
    private float yTopRange = 16f;
    private float yBottomRange = -1f;

    private float speed = 7f;
//    private float angle = 60f;
    private float horizontalInput;
    private float verticalInput;

    public GameObject projectilePrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!MenuManager.Instance.gameOver)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");

            OnBoundary();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
            }
            transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);
            transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        }


    }
    private void OnBoundary()
    {
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.z < yBottomRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, yBottomRange);
        }
        if (transform.position.z > yTopRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, yTopRange);
        }
    }
}
