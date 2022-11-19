using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballBehaviour : MonoBehaviour
{
    [SerializeField] private float bounceCount;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float totalATK;
    [SerializeField] private Vector3 ballForce;
    [SerializeField] private float increment;
    private playerBehaviour playerBehaviour;
    private float tes;
  
    void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
        _rigidbody.AddForce(ballForce, ForceMode2D.Impulse);
       // _rigidbody.gravityScale = 0;
        

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
       

    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "wall")
        {
            increment++;
            bounceCount++;
            totalATK += bounceCount;
            //Debug.Log(totalATK += bounceCount + _rigidbody.velocity.magnitude);
            Debug.Log(_rigidbody.velocity.magnitude);
        } else if(collision.gameObject.tag == "Player"){
            //ballForce = _rigidbody.velocity;
            //_rigidbody.velocity = ballForce * ;
            _rigidbody.AddForce(ballForce, ForceMode2D.Impulse);
            Debug.Log(_rigidbody.velocity.magnitude);
        }
    }
   
   
        
    
}
