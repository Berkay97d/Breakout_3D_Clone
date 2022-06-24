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
    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
    }

    private void OnMouseDown()
    {
        if (!isBallThrowed)
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
    }

    public IEnumerator ThrowBall()
    {
        yield return new WaitForSeconds(0);

        var randomNum = Random.Range(0, 2);
        
        if (randomNum == 1)
        {
            ballRb.AddForce(new Vector3(2,5,0),ForceMode.Impulse);
            yield break;
        }
        
        ballRb.AddForce(new Vector3(-2,-5,0),ForceMode.Impulse);
    }

    private void FollowPlayer()
    {
        if (!isBallThrowed)
        {
            transform.position = new Vector3(player.transform.position.x, transform.position.y);
        }
    }
}
