using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggingExample : MonoBehaviour
{
    [SerializeField] private bool isDragging = false;

    // Update is called once per frame
    void Update()
    {
        if(isDragging)
        {
            transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    private void OnMouseDown()
    {
        isDragging = true;
        // isDragging = !isDragging;
    }

    private void OnMouseUp()
    {
        isDragging = false;
    }
}
