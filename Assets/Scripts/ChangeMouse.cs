using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMouse : MonoBehaviour
{
    [SerializeField] Texture2D mouseIcon;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(mouseIcon, new Vector2(16, 16), CursorMode.Auto);
    }
}
