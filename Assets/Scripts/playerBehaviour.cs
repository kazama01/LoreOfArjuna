using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class playerBehaviour : MonoBehaviour
{
    [SerializeField] float healthPlayer;
    
    void OnMouseDrag()
    {
        Vector3 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        point.z = gameObject.transform.position.z;

        //Debug.Log(point);

        if(point.y <= 9 && point.y >= 5 && point.x >= -1.8f && point.x <= 1.8f)
        {
            gameObject.transform.position = point;
        }
        
        //Cursor.visible = false;
    }

    void OnMouseUp()
    {
        Cursor.visible = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponentInChildren<ParticleSystem>())
        {
            
            if(healthPlayer != 0)
            {
                healthPlayer--;
            }
            else if(healthPlayer == 0)
            {
                Debug.Log("GameOver");
            }
        }
    }
}

