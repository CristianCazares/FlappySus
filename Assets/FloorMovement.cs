using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorMovement : MonoBehaviour
{
    [SerializeField] float _speed = 5;
    [SerializeField] PlayerScore _playerScore;
    [SerializeField] GameObject _floorPrefab;

    void Start()
    {
        _playerScore = GameObject.Find("Player").GetComponent<PlayerScore>();
    }

    void Update()
    {
        if(_playerScore._gameOver)
        {
            Destroy(this);
        }
        transform.position += Vector3.left * _speed * Time.deltaTime;
    }
    

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Unspawner")
        {
            GameObject newFloor = Instantiate(_floorPrefab);
            newFloor.name = "Floor";
            newFloor.transform.position = new Vector3(
                transform.position.x + GetComponent<BoxCollider2D>().bounds.size.x * 2.9f,
                transform.position.y,
                0);
            Destroy(gameObject);
        }
    }
}
