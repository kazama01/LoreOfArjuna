using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballBehaviour : MonoBehaviour
{
    [SerializeField] private float bounceCount;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float totalATK;
    [SerializeField] private Vector3 ballForce;
    [SerializeField] private float increment;
  
    void Start()
    {
        _rigidbody = gameObject.AddComponent<Rigidbody>();
        _rigidbody.AddForce(ballForce, ForceMode.Impulse);
        _rigidbody.constraints = RigidbodyConstraints.FreezePositionY;
        

    }

      void Update()
    {
        
        //ballForce = _rigidbody.velocity;
        //_rigidbody.velocity = ballForce * increment;
        ballForce = _rigidbody.velocity;
        _rigidbody.velocity =  ballForce.normalized * (increment + 3);
       

    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "wall")
        {
            increment++;
            bounceCount++;
            totalATK += bounceCount+5;
            Debug.Log(_rigidbody.velocity.magnitude);
        }
    }

   
        
    
}
