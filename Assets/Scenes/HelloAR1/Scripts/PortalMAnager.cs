using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PortalMAnager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject MainCamera;
    public GameObject Sponza;
    private Material[] SponaMaterials;
    void Start()
    {
        SponaMaterials = Sponza.GetComponent<Renderer>().sharedMaterials;
    }

    // Update is called once per frame
    void OnTriggerStay(Collider col)
    {
        Vector3 camPosotionPortalSpace = transform.InverseTransformPoint(MainCamera.transform.position);
        if (camPosotionPortalSpace.y < .5f)
        {
            for (int i = 0; i < SponaMaterials.Length; ++i)
            {
                SponaMaterials[i].SetInt("_StencilComp", (int)CompareFunction.Always);
            }
        }
        else
        {
            for (int i = 0; i < SponaMaterials.Length; ++i)
            {
                SponaMaterials[i].SetInt("_StencilComp", (int)CompareFunction.Equal);
            }
        }
    }
}
