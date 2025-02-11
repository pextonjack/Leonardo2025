using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIQualityManager : MonoBehaviour
{
    public Canvas canvas;


    public Dropdown dpPostProcessing;
    public Dropdown dpQuality;

    public Terrain terrain;

    public List<NameValue> detailDensities;
    public Dropdown dpDetailDensity;

    public List<NameValue> shapeQualities;
    public Dropdown dpShapeQuality;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            canvas.enabled = !canvas.enabled;
        }
    }

    public void SetPostProcessing(int id)
    {
        

    }

    public void SetQuality(int id)
    {
        QualitySettings.SetQualityLevel(id);

    }

    public void SetDetailDensity(int id)
    {
        terrain.detailObjectDensity = detailDensities[id].value;
        terrain.Flush();
    }

    public void SetShapeQuality(int id)
    {
        terrain.heightmapPixelError = shapeQualities[id].value;
        terrain.Flush();
    }

}

[Serializable]
public class NameValue
{
    public float value;
    public string name;

}


