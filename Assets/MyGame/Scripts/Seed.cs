using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;
using Random = UnityEngine.Random;

[Serializable]
public class SeedStage
{
    public string stageStts;
    public float growthTime;
    public Sprite sprite;
    [Range(0.0f, 1.0f)]
    public float destroyChance;
}
public enum RepeatHarvest
{
    Repeat,
    NoRepeat
}
public enum GrowthStage
{
    Stage0,
    Stage1,
    Stage2,
    Stage3,
}

public class Seed : MonoBehaviour
{

    public SeedStage[] seedStage;
    public RepeatHarvest repeatHarvest;
    public GrowthStage growthStage;


    [SerializeField] private GameObject dropSeed;
    [SerializeField] private GameObject dropGoldSeed;
    private SpriteRenderer spriteRenderer;
    
    private bool isReadyForHarvest = false;
    void Start()
    {
        spriteRenderer = GetComponent <SpriteRenderer>();       
    }

    void Update()
    {
        Growth();        
    }

    public void Growth() 
    {
        if (growthStage == GrowthStage.Stage0) StartCoroutine(SeedStage0());            
        if (growthStage == GrowthStage.Stage1) StartCoroutine(SeedStage1());
        if (growthStage == GrowthStage.Stage2) StartCoroutine(SeedStage2());
        if (growthStage == GrowthStage.Stage3) StartCoroutine(SeedStage3());
    }
    IEnumerator SeedStage0() 
    {
        spriteRenderer.sprite = seedStage[0].sprite;
        yield return new WaitForSeconds(seedStage[0].growthTime);
        growthStage = GrowthStage.Stage1;
    }
    IEnumerator SeedStage1()
    {
        spriteRenderer.sprite = seedStage[1].sprite;
        yield return new WaitForSeconds(seedStage[1].growthTime);
        growthStage = GrowthStage.Stage2;
    }
    IEnumerator SeedStage2()
    {
        spriteRenderer.sprite = seedStage[2].sprite;
        yield return new WaitForSeconds(seedStage[2].growthTime);

        if (repeatHarvest == RepeatHarvest.Repeat)
        {
            growthStage = GrowthStage.Stage3;
        }
        else
            isReadyForHarvest = true;
        
    }
    IEnumerator SeedStage3()
    {
        spriteRenderer.sprite = seedStage[3].sprite;
        yield return new WaitForSeconds(seedStage[3].growthTime);
        isReadyForHarvest = true;
    }

     void OnMouseDown()
     {        
         if (isReadyForHarvest)
         {
             if (repeatHarvest == RepeatHarvest.Repeat)
             {
                 if (growthStage == GrowthStage.Stage3)
                 {
                    float randomChance = Random.Range(0f, 1f);
                    if (randomChance <= 0.7f)
                    {
                        Instantiate(dropGoldSeed, transform.position, transform.rotation);                       
                    }
                    else 
                    {
                        Instantiate(dropGoldSeed, transform.position, transform.rotation);
                        Instantiate(dropGoldSeed, transform.position, transform.rotation);
                    }

                    isReadyForHarvest = false;
                    growthStage = GrowthStage.Stage2;
                }
             }
             else
             {
                float randomChance = Random.Range(0f, 1f);
                if (randomChance <= 0.7f)
                {
                    Instantiate(dropGoldSeed, transform.position, transform.rotation);
                }
                else
                {
                    Instantiate(dropGoldSeed, transform.position, transform.rotation);
                    Instantiate(dropGoldSeed, transform.position, transform.rotation);
                }
                Instantiate(dropSeed, transform.position, transform.rotation);
                Destroy(gameObject);
             }
         }
     }  
    
}
