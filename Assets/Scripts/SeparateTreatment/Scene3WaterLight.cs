using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Scene3WaterLight : MonoBehaviour
{

    [SerializeField] Volume TheLight;
    [HideInInspector]
    public float Thevalue;

    private List<VolumeComponent> TheComp=new List<VolumeComponent>();
    // Start is called before the first frame update
    void Start()
    {
        TheComp = TheLight.profile.components;
    }

    public void Setlightvalue(float value)
    {
        Thevalue = value;
        float complement = value * 2 - 1 ;
        TheComp[3].parameters[0].SetValue(new FloatParameter(complement));
    }
}
