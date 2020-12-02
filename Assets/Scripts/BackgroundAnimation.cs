using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundAnimation : MonoBehaviour
{
    public float scrollSpeed = 0.005f;
    public Transform player;
    private Renderer _renderer;

    void Update()
    {
        _renderer = GetComponent<Renderer>();
   
        _renderer.material.SetTextureOffset("_MainTex", new Vector2(player.position.x* scrollSpeed,0));
    }
}
