//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Random = UnityEngine.Random;

public class WhackADot : MonoBehaviour
{
    private void OnMouseDown()
    {
        GameManager.instance.Score++;
        Debug.Log(GameManager.instance.Score);
        transform.position = new Vector2(Random.Range(-6f, 6f), Random.Range(-4f, 4f));
        
    }
}
