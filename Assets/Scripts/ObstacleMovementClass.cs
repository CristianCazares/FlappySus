using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovementClass : MonoBehaviour
{
    [SerializeField] float _speed = 5;

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * Time.deltaTime * _speed;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Unspawner")
        {
            Destroy(gameObject);
        }
    }
}
