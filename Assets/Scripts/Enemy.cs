using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int MaxHP;
    [SerializeField] private int _currentHP;

    [SerializeField] private float movementSpeed;
    [SerializeField] private float projectileSpeed;
    public GameObject projectile;

    public float idleTimer;
    float _idleTimer;

    [SerializeField] private GameObject posTarget;

    enum Status
    {
        Normal,
        Rage
    }

    enum State
    {
        Idle,
        Move,
        Shoot,
        Die
    }

    [SerializeField] State state;

    private void Start()
    {
        state = State.Idle;

        _idleTimer = idleTimer;

        _currentHP = MaxHP;

        
    }

    private void Update()
    {
        //Debug.Log(posTarget.transform.localPosition);

        if (state == State.Idle)
        {
            Idle();
        }
        else if(state == State.Move)
        {
            Move();
        }
        else if(state == State.Shoot)
        {
            Shoot();
        }
        else if(state == State.Die)
        {
            Die();
        }


        if (_currentHP <= 0)
        {
            state = State.Die;
        }
    }

    private void Idle()
    {
        if(_idleTimer >= 0)
        {
            _idleTimer -= Time.deltaTime;
            //Debug.Log(_idleTimer);
        }
        else if(_idleTimer <= 0)
        {
            state = State.Move;
            _idleTimer = idleTimer;
        }       
    }

    private void Move()
    {
        if (Vector3.Distance(gameObject.transform.position, posTarget.transform.position) >= 0.5f)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, posTarget.transform.position, movementSpeed * Time.deltaTime);
        }
        else
        {
            state = State.Shoot;
        }
    }

    private void Shoot()
    {
        GameObject projClone;

        projClone = Instantiate(projectile, gameObject.transform.position, gameObject.transform.rotation);
        projClone.transform.localScale = projClone.transform.localScale * 0.05f;

        projClone.GetComponent<Rigidbody2D>().AddForce(Vector2.down * projectileSpeed);
        Destroy(projClone, 5f);

        posTarget.transform.position = new Vector3(posTarget.transform.position.x * -1, posTarget.transform.position.y, posTarget.transform.position.z);

        state = State.Idle;
    }

    private void Die()
    {
        //GameOver
    }

    public void Damaged(int inputDamage)
    {
        //Geter kanan kiri

        _currentHP -= inputDamage;
    }    
}
