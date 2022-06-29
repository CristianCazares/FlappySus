using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] int _score;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "ScoreBox")
        {
            _score++;
        }
    }
}
