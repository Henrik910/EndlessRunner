using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthView : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI view;
    
    public void SetLive(int hp)
    {
        this.view.text = hp.ToString();
    }
}
