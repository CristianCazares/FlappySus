using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] GameObject _obstaclePrefab;
    [SerializeField] float _rate;

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
            yield return new WaitForSeconds(_rate);
        }
    }
}
