using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatCounter : MonoBehaviour
{
    [SerializeField]
    private Image CatImage;
    
    public void SetCatState(bool catFound)
    {
        CatImage.gameObject.SetActive(catFound);
    }
}
