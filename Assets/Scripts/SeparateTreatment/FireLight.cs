using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireLight : MonoBehaviour
{
    [SerializeField] GameObject TheFire;
    [SerializeField] float Brightness=0.3f;
    [SerializeField] SpriteRenderer Png1;
    [SerializeField] ParticleSystem TheLight;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        var lights = TheLight.lights;
        lights.intensityMultiplier = TheFire.transform.localScale.x / 10;
        Png1.color = new Color(TheFire.transform.localScale.x / 10 + Brightness, TheFire.transform.localScale.x / 10 + Brightness, TheFire.transform.localScale.x / 10 + Brightness);
    }

}
