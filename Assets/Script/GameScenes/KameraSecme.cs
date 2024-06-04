using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraSecme : MonoBehaviour
{
    [SerializeField] private GameObject[] ilkArabaKameralar, ikinciArabaKameralar, ucuncuArabaKameralar, dorduncuArabaKameralar;
    int sayac = 0;
    private GameObject[] atanacakdizi;
    void Start()
    {
        atanacakdizi = new GameObject[2];
        for (int i = 0; i < ilkArabaKameralar.Length; i++)
        {
            ilkArabaKameralar[i].SetActive(false);
            ikinciArabaKameralar[i].SetActive(false);
            ucuncuArabaKameralar[i].SetActive(false);
            dorduncuArabaKameralar[i].SetActive(false);
        }
        if(PlayerPrefs.GetInt("Car") == 0)
        {
            for (int i = 0; i < ilkArabaKameralar.Length; i++)
            {
                atanacakdizi[i] = ilkArabaKameralar[i];
            }
        }
        else if (PlayerPrefs.GetInt("Car") == 1)
        {
            for (int i = 0; i < ikinciArabaKameralar.Length; i++)
            {
                atanacakdizi[i] = ikinciArabaKameralar[i];
            }
        }
        else if (PlayerPrefs.GetInt("Car") == 2)
        {
            for (int i = 0; i < ucuncuArabaKameralar.Length; i++)
            {
                atanacakdizi[i] = ucuncuArabaKameralar[i];
            }
        }
        else if (PlayerPrefs.GetInt("Car") == 3)
        {
            for (int i = 0; i < dorduncuArabaKameralar.Length; i++)
            {
                atanacakdizi[i] = dorduncuArabaKameralar[i];
            }
        }
        atanacakdizi[sayac].SetActive(true);
    }

    public void kameraAcma()
    {
        KameraKapatma();
        sayac++;
        atanacakdizi[sayac].SetActive(true);
        
        if (sayac == atanacakdizi.Length-1)
        {
            sayac = -1;
        }
    }

    void KameraKapatma()
    {
        foreach (var item in atanacakdizi)
        {
            item.SetActive(false);
        }
    }
}
