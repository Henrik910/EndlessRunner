using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreView : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI view;
    
    private void Update() 
    {
        this.view.text = Score.GetTime().ToString("F2");
    }
}
