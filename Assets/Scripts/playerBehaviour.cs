using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class playerBehaviour : MonoBehaviour
{

    void OnMouseDrag()
    {
        Vector3 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        point.z = gameObject.transform.position.z;

        Debug.Log(point);

        if(point.y <= 9 && point.y >= 5 && point.x >= -1.5f && point.x <= 1.5f)
        {
            gameObject.transform.position = point;
        }
        
        //Cursor.visible = false;
    }

    void OnMouseUp()
    {
        Cursor.visible = true;
    }
}

