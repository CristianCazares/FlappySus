using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovementClass : MonoBehaviour
{
    [SerializeField] GameObject _spawner;
    [SerializeField] GameObject _scoreBox;

    private float _speed;


    void Start()
    {
        _spawner = GameObject.Find("Spawner");
    }

    void Update()
    {
        _speed = _spawner.GetComponent<ObstacleSpawner>()._obstacleSpeed;

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
