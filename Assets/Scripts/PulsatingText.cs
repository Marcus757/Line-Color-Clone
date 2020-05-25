using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PulsatingText : MonoBehaviour
{
    public float fontSizeIncrease;
    public float speed;
    private float originalFontSize;

    void Start()
    {
        originalFontSize = GetComponent<TextMeshProUGUI>().fontSize;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<TextMeshProUGUI>().fontSize = Mathf.PingPong(Time.time * speed, 10) + originalFontSize;
    }
}
