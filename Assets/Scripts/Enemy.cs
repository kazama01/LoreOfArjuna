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

    [SerializeField] private float idleTimer;
    [SerializeField] private float _idleTimer;

    [SerializeField] private int stepLimit;
    [SerializeField] private int _stepCount;
    [SerializeField] private int shootStepLimit;
    [SerializeField] private int _shootStepCount;
    [SerializeField] private bool resetStep;
    [SerializeField] private bool isRight;
    [SerializeField] AudioSource audioSource;
    [SerializeField] private GameObject posTarget;
    [SerializeField] private AudioSource playerWin;
    [SerializeField] public AudioSource stageBGM;
    float tempPos;
    [SerializeField] private Image Win;
    [SerializeField] private GameObject _ball;
    

    [SerializeField] private Image HPBar;

    private Animator anim;

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

        _shootStepCount = shootStepLimit;

        tempPos = posTarget.GetComponent<RectTransform>().anchoredPosition.y;

        anim = gameObject.GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
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
            Win.enabled = true;
            _ball.SetActive(false);
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
        if (Vector3.Distance(gameObject.transform.position, posTarget.transform.position) >= 0.125f)
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
        //Debug.Log(posTarget.transform.position);
        float randomY = Random.Range(-25, 25);

        if(_stepCount == stepLimit)
        {

            resetStep = true;
            
            _stepCount = 0;
            _shootStepCount = shootStepLimit;
        }
        if(_shootStepCount == 0)
        {
            resetStep = false;
            _stepCount = 0;
            _shootStepCount = shootStepLimit;
        }

        if(posTarget.GetComponent<RectTransform>().anchoredPosition.x <= -300)
        {
            isRight = true;
        }
        if(posTarget.GetComponent<RectTransform>().anchoredPosition.x >= 300)
        {
            isRight = false;
        }

        if(resetStep)
        {
            GameObject projClone;

            projClone = Instantiate(projectile, gameObject.transform.position, gameObject.transform.rotation);
            projClone.transform.localScale = projClone.transform.localScale * 0.05f;

            projClone.GetComponent<Rigidbody2D>().AddForce(Vector2.down * projectileSpeed);
            Destroy(projClone, 5f);

            if (isRight)
            {
                posTarget.GetComponent<RectTransform>().anchoredPosition = new Vector2(posTarget.GetComponent<RectTransform>().anchoredPosition.x + 150, tempPos + randomY);
            }
            else if (!isRight)
            {
                posTarget.GetComponent<RectTransform>().anchoredPosition = new Vector2(posTarget.GetComponent<RectTransform>().anchoredPosition.x - 150, tempPos + randomY);
            }

            _shootStepCount--;
            state = State.Idle;
            _idleTimer = 0.0000025f;
        }
        else if(!resetStep)
        {
            _stepCount++;

            posTarget.GetComponent<RectTransform>().anchoredPosition = new Vector2(posTarget.GetComponent<RectTransform>().anchoredPosition.x * -1, tempPos + randomY);

            state = State.Idle;
            _idleTimer = 1f;
        }

        //Debug.Log(posTarget.transform.position);

        
    }

    public void Die()
    {
        //GameOver
        stageBGM.Stop();
        Time.timeScale = 0;
    }

    public void Damaged(int inputDamage)
    {
        //Geter kanan kiri

        _currentHP -= inputDamage;

        HPBar.fillAmount = ((100f / MaxHP) * _currentHP) / 100;
        Debug.Log(HPBar.fillAmount);
        if(_currentHP <= 0)
        {
            playerWin.Play();
        }

        anim.Play("EnemyDamaged");
        audioSource.Play();
    }    
}
