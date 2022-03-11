using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColor : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    private Renderer sphereRenderer;
    private Color newSphereColor;
    public Material[] Material;
    public int matNumb;
    /*
    // Start is called before the first frame update
    void Start()
    {
        sphereRenderer = player.GetComponent<Renderer>();
        gameObject.GetComponent<Button>().onClick.AddListener(ChangePlayerColor);
    }

    private void ChangePlayerColor_R()
    {
        matNumb = 0;
       
        newSphereColor = new Color(matNumb, matNumb, matNumb, 1f);

        sphereRenderer.material.SetColor("_Color", newSphereColor);
    }

    private void ChangePlayerColor_B()
    {
        matNumb = 1;

        newSphereColor = new Color(randomChannelOne, randomChannelOne, randomChannelOne, 1f);

        sphereRenderer.material.SetColor("_Color", newSphereColor);
    }

    private void ChangePlayerColor_G()
    {
        matNumb = 2;

        newSphereColor = new Color(randomChannelOne, randomChannelOne, randomChannelOne, 1f);

        sphereRenderer.material.SetColor("_Color", newSphereColor);
    }*/
}
