using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public enum StatsLands
{
    Dry,
    Wet
}

public class Lands : MonoBehaviour
{

    public StatsLands statsLands;

    [SerializeField] private bool readyToPlant;


    [Header("Sprites lands")]
    [SerializeField] private Sprite[] sprite;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if(statsLands == StatsLands.Dry) 
        {
            readyToPlant = false;
            spriteRenderer.sprite = sprite[0];
        }
        else if (statsLands == StatsLands.Wet)
        {
            readyToPlant = true;
            spriteRenderer.sprite = sprite[1];
        }
    }



}
