using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SelectUtility
{
    Hoe,
    WateringCan,
    Arrow
}
public class ToolsUtilitys : MonoBehaviour
{

    public SelectUtility selectUtility;


    private void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        Plane plane = new Plane(Vector3.forward, Vector3.zero);
        Vector3 hitPoint;
        
        if (plane.Raycast(ray, out float hitDistance))
        {
            // Obtenha o ponto de impacto
            hitPoint = ray.GetPoint(hitDistance);

            // Atualize a posição do objeto para o ponto de impacto
            transform.position = hitPoint;
        }
        
    }
    public void SelectHoe() 
    {
        selectUtility = SelectUtility.Hoe;
        Debug.Log("<color=blue>Hoe Select</color>");
    }
    public void SelectWateringCan()
    {
        selectUtility = SelectUtility.WateringCan;
        Debug.Log("<color=blue>WateringCan Select</color>");
    }
    public void SelectArrow()
    {
        selectUtility = SelectUtility.Arrow;
        Debug.Log("<color=blue>Arrow Select</color>");
    }
}
