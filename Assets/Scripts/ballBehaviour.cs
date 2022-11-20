using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    [SerializeField] private float bounceCount;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float totalATK;
    [SerializeField] private Vector3 ballForceUp;
    [SerializeField] private Vector3 ballForceDown;
    [SerializeField] private float increment;
    private PlayerBehaviour playerBehaviour;
    private float tes;
    
    public ParticleSystem _particleSystem;

    void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
        //_rigidbody.AddForce(ballForceUp, ForceMode2D.Impulse);
       // _rigidbody.gravityScale = 0;
      _particleSystem = GetComponentInChildren<ParticleSystem>();


    }
    private void FixedUpdate()
    {
        tes = Mathf.SmoothStep(50, 100, 0 / 60);
    }

    void Update()
    {

        //ballForce = _rigidbody.velocity;
        //_rigidbody.velocity = ballForce * increment;
        //ballForce = _rigidbody.velocity;

        totalATK = bounceCount * increment + _rigidbody.velocity.magnitude * 2.5f;
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "wall")
        {
            //increment++;
            bounceCount++;
            
            _particleSystem.Play();
            //_rigidbody.AddForce(ballForce, ForceMode2D.Impulse);
            //Debug.Log(_rigidbody.velocity.magnitude);
        } 
        else if(collision.gameObject.tag == "Player"){
            //ballForce = _rigidbody.velocity;
            //_rigidbody.velocity = ballForce * ;
            _rigidbody.AddForce(ballForceUp, ForceMode2D.Impulse);
            //Debug.Log(_rigidbody.velocity.magnitude);
        }
        else if(collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().Damaged((int)totalATK);
            _rigidbody.AddForce(ballForceDown, ForceMode2D.Impulse);
            bounceCount = 1;
        }    
    }
}
   
