using AtmosphericHeightFog;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaculaFog : MonoBehaviour
{
    [SerializeField] HeightFogGlobal Thefog;
    [SerializeField] GameObject TheWater;

    private float m_fog;
    private Material m_Water;
    private float TheValue=0.1f;
    private float  scaledValue;
    // Start is called before the first frame update
    void Start()
    {
        m_Water = TheWater.GetComponent<Renderer>().material;
        m_fog = m_Water.GetFloat("_PointSpotLightReflectionStrength");
    }

    // Update is called once per frame
    void Update()
    {
        if (Thefog != null)
        {
            m_fog = Thefog.fogIntensity;

            scaledValue = (m_fog - 0.1f) / (0.4f - 0.1f) * (1 - 0.2f) + 0.2f;
            TheValue = (0.4f - scaledValue) / 0.4f;
            m_Water.SetFloat("_PointSpotLightReflectionStrength",Mathf.Clamp( TheValue * 5f,0.1f,5f));
        }
       
       
    }
}
