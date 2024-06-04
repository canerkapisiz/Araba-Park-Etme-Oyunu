using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class tenekeHareket : MonoBehaviour
{
    [SerializeField] private Vector3 gidecek;
    private Vector3 sonraGidecek;

    void Start()
    {
        sonraGidecek = transform.localPosition;
        StartCoroutine(Carptik());
    }

    IEnumerator Carptik()
    {
        float random = Random.Range(0, 2f);
        yield return new WaitForSeconds(random);
        transform.GetComponent<Transform>().DOLocalMove(gidecek, 1.5f);
        yield return new WaitForSeconds(2.5f);
        transform.GetComponent<Transform>().DOLocalMove(sonraGidecek, 1.5f);
        yield return new WaitForSeconds(2.5f);
        StartCoroutine(Carptik());
    }
}
