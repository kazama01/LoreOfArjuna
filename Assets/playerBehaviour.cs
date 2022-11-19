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
        gameObject.transform.position = point;
        Cursor.visible = false;
    }

    void OnMouseUp()
    {
        Cursor.visible = true;
    }
}

