using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AcilirKapiHareket : MonoBehaviour
{
    Vector3 gidilecek;
    Vector3 donulecek;

    void Start()
    {
        gidilecek = new Vector3(transform.rotation.z, transform.rotation.y, -65f);
        donulecek = new Vector3(transform.rotation.z, transform.rotation.y, 0f);
        StartCoroutine(AcKapa());
    }

    IEnumerator AcKapa()
    {
        float random = Random.Range(0, 2f);
        yield return new WaitForSeconds(random);
        // Local rotasyon yapılıyor
        transform.DOLocalRotate(gidilecek, 1.5f);
        yield return new WaitForSeconds(2f);
        // Local rotasyon yapılıyor
        transform.DOLocalRotate(donulecek, 1.5f);
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(AcKapa());
    }
}
