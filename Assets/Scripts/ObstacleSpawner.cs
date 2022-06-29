using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] GameObject _obstaclePrefab;
    [SerializeField] float _rate;
    [SerializeField] float _lowestYPosition;
    [SerializeField] float _highestYPosition;
    bool _started;

    // Update is called once per frame
    void Update()
    {
        if(!_started && Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Spawn());
            _started = true;
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
