using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarpmaKontrolManager : MonoBehaviour
{
    MeshRenderer meshRenderer;
    public Material[] materials;
    bool degis = false;
    ArabaKontrol arabaKontrol;
    

    void Start()
    {
        meshRenderer = gameObject.GetComponentInParent<MeshRenderer>();
        meshRenderer.material = materials[0];
        arabaKontrol = FindObjectOfType<ArabaKontrol>();
    }

    IEnumerator Carptik()
    {
        if (!degis)
        {
            meshRenderer.material = materials[1];
            degis = true;
        }
        else
        {
            meshRenderer.material = materials[0];
            degis = false;
        }
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(Carptik());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("araba"))
        {
            other.GetComponentInParent<ArabaKontrol>().carptiBool = true;
            StartCoroutine(Carptik());
        }
    }
}
