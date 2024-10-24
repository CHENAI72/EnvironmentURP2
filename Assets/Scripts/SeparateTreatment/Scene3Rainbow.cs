using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene3Rainbow : MonoBehaviour
{

    [SerializeField] List<ParticleSystemRenderer> particleSystemRenderer;
    [SerializeField] Scene3WaterLight TheValueFloat;

    private List<Material> materials = new List<Material>();

    private float value;
    private bool increasing = true;

    // Start is called before the first frame update  
    void Start()
    {
        for (int i = 0; i < particleSystemRenderer.Count; i++)
        {
            materials.Add(particleSystemRenderer[i].material);
        }
        value = materials[0].color.a; // Initialize value with the alpha of the first material  
    }

    // Update is called once per frame  
    void Update()
    {
        float targetAlpha = TheValueFloat.Thevalue;

        if (targetAlpha > 0.8f && value < 1.0f)
        {
            increasing = true;
        }
        else if (targetAlpha < 0.8f && value > 0.0f)
        {
            increasing = false;
        }

        if (increasing)
        {
            value = Mathf.Lerp(value, 1.0f, Time.deltaTime * 2);
            if (value >= 1.0f)
            {
                value = 1.0f;
                increasing = false;
            }
        }
        else
        {
            value = Mathf.Lerp(value, 0.0f, Time.deltaTime * 2);
            if (value <= 0.0f)
            {
                value = 0.0f;
                increasing = true;
            }
        }

        Color newColor = new Color(1, 1, 1, value);
        for (int i = 0; i < materials.Count; i++)
        {
            materials[i].color = newColor;
        }
    }

}
