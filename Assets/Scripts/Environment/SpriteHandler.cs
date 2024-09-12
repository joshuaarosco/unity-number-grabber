using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteHandler : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        string gameCategory = StaticData.gameCategory;
        if(gameCategory != "arithmetic" && gameCategory != "roman_numerals"){
            if (spriteRenderer != null){
                spriteRenderer.enabled = false;
            }
        }
    }
}
