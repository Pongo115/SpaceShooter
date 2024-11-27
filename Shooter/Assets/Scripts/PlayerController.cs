using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 2f;
    public Transform minXValue;
    public Transform maxXValue;

    public GameObject BulletPrefab;
    public Transform GunEndPosition;

    public float FireRate;
    private float TimeSinceLastAction;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        PlayerMovement();

        if (Input.GetKey(KeyCode.Space)) 
        {
            Shoot();
        }

        if (Input.GetKey(KeyCode.W))
        {
            Shoot();
        }
    }

    void PlayerMovement()
    {
        float HorizontalInputValue = Input.GetAxis("Horizontal");
        Vector2 movementVector = new Vector2(HorizontalInputValue, 0) * moveSpeed * Time.deltaTime;
        transform.Translate(movementVector);

        if (transform.position.x > maxXValue.position.x)
        {
            transform.position = new Vector2(maxXValue.position.x, transform.position.y);
        }

        if (transform.position.x < minXValue.position.x)
        {
            transform.position = new Vector2(minXValue.position.x, transform.position.y);
        }







    }

    void Shoot()
    {
        TimeSinceLastAction += Time.deltaTime;
        if (TimeSinceLastAction >= FireRate)
        {
            Instantiate(BulletPrefab, GunEndPosition.position, Quaternion.identity);
            TimeSinceLastAction = 0;
        }
    }
   
}   
  
