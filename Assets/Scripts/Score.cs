using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    static float score = 0f;
    // Start is called before the first frame update
    void Start()
    {
        score = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        score += Time.deltaTime;
    }

    public static float GetTime()
    {
        return score;
    }
}
