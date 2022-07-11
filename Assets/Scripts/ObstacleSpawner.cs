using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] GameObject _obstaclePrefab;
    [SerializeField] public float _obstacleSpeed = 5;
    [SerializeField] float _rate;
    [SerializeField] float _lowestYPosition;
    [SerializeField] float _highestYPosition;
    [SerializeField] PlayerScore _playerScore;
    bool _started;

    // Update is called once per frame
    void Update()
    {
        if(!_started && Input.GetButtonDown("Jump"))
        {
            StartCoroutine(Spawn());
            _started = true;
        }

        if (_playerScore._gameOver)
        {
            _obstacleSpeed = 0;
        }

    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(2);
        while (true)
        {
            GameObject obstacle = Instantiate(_obstaclePrefab);
            obstacle.transform.position = new Vector2(
                obstacle.transform.position.x,
                Random.Range(_lowestYPosition, _highestYPosition)
            );
            yield return new WaitForSeconds(_rate);
        }
    }
}
