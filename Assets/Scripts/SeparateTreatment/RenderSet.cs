using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
public class RenderSet : MonoBehaviour
{
    [SerializeField] UniversalRendererData renderData;
    // Start is called before the first frame update
    void Start()
    {
        renderData.rendererFeatures[1].SetActive(true);
    }
    private void OnDisable()
    {
        if (renderData.rendererFeatures[1].isActive)
        {
            renderData.rendererFeatures[1].SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
