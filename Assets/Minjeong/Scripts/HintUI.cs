using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintUI : MonoBehaviour
{
    public GameObject BreadUIObject;
    public GameObject CakeUIObject;
    public GameObject PieUIObject;
    
    public void BreadShow()
    {
        BreadUIObject.SetActive(true);
    }

    public void BreadHide()
    {
        BreadUIObject.SetActive(false);
    }

    public void CakeShow()
    {
        CakeUIObject.SetActive(true);
    }
    public void CakeHide()
    {
        CakeUIObject.SetActive(true);
    }
    
    public void PieShow()
    {
        PieUIObject.SetActive(true);
    }
    public void PieHide()
    {
        PieUIObject.SetActive(true);
    }
    
}
