using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GM : MonoBehaviour
{
    public Text InputText;

    void Start()
    {
        this.InputText.text = PlayerPrefs.GetInt("Player Score").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        this.InputText.text = PlayerPrefs.GetInt("Player Score").ToString();
    }
}
