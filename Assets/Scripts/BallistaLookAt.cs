using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallistaLookAt : MonoBehaviour
{
    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = (Vector2)cam.ScreenToWorldPoint(Input.mousePosition);
        float angleRad = Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x);
        float angleDeg = (180 / Mathf.PI) * angleRad - 90; // Offset by 90 Degrees

        transform.rotation = Quaternion.Euler(0, 0, angleDeg);
        Debug.DrawLine(transform.position, mousePos, Color.white, Time.deltaTime); // Just for Debugging :)
    }
}
