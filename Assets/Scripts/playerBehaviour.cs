using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerBehaviour : MonoBehaviour
{

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
}

