using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class Level1TriggerManager : MonoBehaviour
{
    [SerializeField] private GameObject bittiPanel;

    void Start()
    {
        bittiPanel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("araba"))
        {
            bittiPanel.SetActive(true);
            bittiPanel.transform.DOScale(1f, 1f);
            PlayerPrefs.SetInt("hangiLevel",SceneManager.GetActiveScene().buildIndex-1);
        }
    }
}
