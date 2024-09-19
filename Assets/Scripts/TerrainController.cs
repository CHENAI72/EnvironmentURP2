using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class TerrainController : MonoBehaviour
{
    public static TerrainController Instance;
    // [SerializeField] TMP_Text tMP_Text;
    private void Awake()
    {
        Instance = this;
    }
    [SerializeField] float currentValue = 0f;
    [SerializeField] float speed = 2f;
    [SerializeField] Terrain terrain;
    // Start is called before the first frame update
    //[SerializeField] Slider slider1;
    void Start()
    {

        Shader.SetGlobalFloat("_GlobalControl", 0);
        //  slider1.onValueChanged.AddListener(OnSliderValueChanged);
    }

    private void OnSliderValueChanged(float arg0)
    {
        SetSceneValue(arg0);
        // tMP_Text.text = arg0.ToString();
    }

    // 0-100
    private void SetSceneValue(float sceneValue)
    {
        sceneValue = Clamp(0, 100, sceneValue);
        SetValue(sceneValue * 0.01f);
    }
    public void SetSceneValue01(float sceneValue)
    {
        sceneValue = Clamp(0, 1, sceneValue);
        SetValue(sceneValue);
    }

    private float Clamp(float a, float b, float value)
    {
        float ret;
        if (value < a)
        {
            ret = a;
        }
        else if (value > b)
        {
            ret = b;
        }
        else
        {
            ret = value;
        }
        return ret;
    }

    private void SetValue(float value)
    {
        // float fogDistance = RenderSettings.fogEndDistance - RenderSettings.fogStartDistance;
        // fogDistance *= value;
        // RenderSettings.fogStartDistance = fogDistance;
        terrain.detailObjectDistance = (value * 200) - 50;
        //Debug.Log($"RenderSettings.fogStartDistance={RenderSettings.fogStartDistance}");
        Shader.SetGlobalFloat("_GlobalControl", value);
    }
    private void Update()
    {
        // OnSliderValueChanged(currentValue += Time.deltaTime * speed);
    }
}
