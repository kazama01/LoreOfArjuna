using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private int MaxHP = 3;
    [SerializeField] private int _currentHP;

    [SerializeField] private GameObject hP_1;
    [SerializeField] private GameObject hP_2;
    [SerializeField] private GameObject hP_3;

    [SerializeField] private Animator animVignette;
    private Animator anim;
    public AudioSource audioSource;
    public AudioSource audioSourceHit;
    [SerializeField] AudioSource playerLose;
    public Enemy enemy;
    [SerializeField] Image _Lose;
    [SerializeField] GameObject panel;

    private void Start()
    {
        _currentHP = MaxHP;

        anim = gameObject.GetComponent<Animator>();
        
    }

    
    void OnMouseDrag()
    {
        Vector3 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        point.z = gameObject.transform.position.z;

        //Debug.Log(point);

        if (point.y <= 10.5f && point.y >= 5 && point.x >= -1.8f && point.x <= 1.8f)
        {
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, point, 0.5f);
        }

        //Cursor.visible = false;
    }

    void OnMouseUp()
    {
        Cursor.visible = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyBullet")
        {
            animVignette.Play("Vignette");

            Destroy(collision.gameObject);

            audioSource.Play();
            audioSourceHit.Play();
            _currentHP--;

            if(_currentHP == 3)
            {
                hP_1.SetActive(true);
                hP_2.SetActive(true);
                hP_3.SetActive(true);
            }
            else if (_currentHP == 2)
            {
                hP_1.SetActive(true);
                hP_2.SetActive(true);
                hP_3.SetActive(false);
            }
            else if (_currentHP == 1)
            {
                hP_1.SetActive(true);
                hP_2.SetActive(false);
                hP_3.SetActive(false);
            }
            else if (_currentHP == 0)
            {
                
                hP_1.SetActive(false);
                hP_2.SetActive(false);
                hP_3.SetActive(false);

                playerLose.Play();
                enemy.stageBGM.Stop();
                _Lose.enabled = true;
                panel.SetActive(true);

                Destroy(this.gameObject);
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Biji")
        {
            anim.Play("CharAttack");
        }
    }
}