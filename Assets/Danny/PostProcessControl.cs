using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PostProcessControl : MonoBehaviour
{
    private ColorAdjustments c;
    public UniversalRendererData hintRenderer;
    ScriptableRendererFeature hintRenderFeature;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Volume>().profile.TryGet<ColorAdjustments>(out c);
        GetHintRenderFeature();
        hintRenderFeature.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        AdjustSat();
    }
    void test()
    {
        c.saturation.value = -100f;
    }

    void AdjustSat ()
    {
        if (Input.GetKey(KeyCode.Tab)) 
        {
            if (c.saturation.value >= -99) 
            {
                c.saturation.value = Mathf.Lerp(c.saturation.value, -100, 0.1f);
            }
            Time.timeScale = 0.1f;
            hintRenderFeature.SetActive(true);
        }
        if (!Input.GetKey(KeyCode.Tab)) 
        {
            if (c.saturation.value <= -0.01)
            {
                c.saturation.value = Mathf.Lerp(c.saturation.value, 0, 0.1f);
            }
            Time.timeScale = 1f;
            hintRenderFeature.SetActive(false);
        }
    }

    void GetHintRenderFeature() 
    {
        hintRenderFeature = hintRenderer.rendererFeatures[2];
    }

}
