using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] float _highestYPosition;
    [SerializeField] float _lowestYPosition;
    [SerializeField] GameObject _obstaclePrefab;
    [SerializeField] float _rate;

    bool _started = false;
    float _initialDelay = 2;

    // Update is called once per frame
    void Update()
    {
        if (!_started)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartCoroutine(Spawn());
                _started = true;
            }
        }
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(2);
        while (true)
        {
            GameObject obstacle = Instantiate(_obstaclePrefab);
            obstacle.transform.position = new Vector3(
                obstacle.transform.position.x,
                Random.Range(_lowestYPosition, _highestYPosition),
                obstacle.transform.position.z
            );
            yield return new WaitForSeconds(_rate);
        }
    }
}
