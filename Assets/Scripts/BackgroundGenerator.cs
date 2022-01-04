using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BackgroundGenerator : MonoBehaviour
{
    [SerializeField] private Sprite backgroundSprite; 
    
    void Start()
    {
        GenerateBackground();
    }

    void GenerateBackground()
    {
        Vector3 fillingArea = Camera.main.ViewportToWorldPoint(transform.position);
        float spriteSizePerUnit = (backgroundSprite.rect.width/backgroundSprite.pixelsPerUnit);
        int countTileX = Mathf.RoundToInt(Math.Abs(fillingArea.x)) + 1;
        int countTileY = Mathf.RoundToInt(Math.Abs(fillingArea.y)) + 1;
        
        for (int i = 0; i < countTileX; i++)
        {
            for (int j = 0; j < countTileY; j++)
            {
                GameObject gm = new GameObject();
                gm.transform.parent = transform;
                gm.name = "BackgroundTile";
                gm.AddComponent<SpriteRenderer>().sprite = backgroundSprite;
                gm.transform.position = new Vector3(i * spriteSizePerUnit + fillingArea.x, j * spriteSizePerUnit + fillingArea.y, 0);
            }
        }
    }
    
    
}
