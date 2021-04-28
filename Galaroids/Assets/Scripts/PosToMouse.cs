using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosToMouse : MonoBehaviour
{
    public Transform body;

    // Update is called once per frame
    void Update()
    {
        body.position = new Vector2(GameManager.mousePos.x, GameManager.mousePos.y);
    }
}
