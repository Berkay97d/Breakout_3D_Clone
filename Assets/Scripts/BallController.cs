using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallController : MonoBehaviour
{

    [SerializeField] private Rigidbody ballRb;
    [SerializeField] private bool isBallThrowed;
    [SerializeField] private GameObject player;
    private float startYPosition = -2.884f;
    public bool isBallDead;
    
    
    void Update()
    {
        FollowPlayer();
        BallThrower();
    }

    private void BallThrower()
    {
        if ( Input.GetKeyDown(KeyCode.Space) &&!isBallThrowed )
        {
            StartCoroutine(ThrowBall());
            isBallThrowed = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && isBallThrowed)
        {
            var playerPosition = collision.transform.position.x;
            var ballPosition = transform.position.x;
            var range = (ballPosition - playerPosition) * 10 ;
            var x = (range - ballRb.velocity.x) ;

            ballRb.AddForce(x,0,0,ForceMode.Impulse);
        }
        
        if (ballRb.velocity.y < 0 )
        {
            ballRb.velocity = new Vector3(ballRb.velocity.x, -5);
        }
        else if (ballRb.velocity.y > 0 )
        {
            ballRb.velocity = new Vector3(ballRb.velocity.x, 5);
        }
    }

    public IEnumerator ThrowBall()
    {
        yield return new WaitForSeconds(0);

        var randomNum = Random.Range(0, 2);
        
        if (randomNum == 1)
        {
            ballRb.AddForce(new Vector3(3,5,0),ForceMode.Impulse);
            yield break;
        }
        
        ballRb.AddForce(new Vector3(-3,-5,0),ForceMode.Impulse);
    }

    private void FollowPlayer()
    {
        if (!isBallThrowed)
        {
            transform.position = new Vector3(player.transform.position.x, startYPosition);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sensor"))
        {
            RelocateBall();
            isBallDead = true;
        }
    }

    private void RelocateBall()
    {
        transform.position = new Vector3(player.transform.position.x, startYPosition);
        ballRb.velocity = Vector3.zero;
        isBallThrowed = false;
    }
}
