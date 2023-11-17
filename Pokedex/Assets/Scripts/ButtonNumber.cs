using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonNumber : MonoBehaviour
{
    public int buttonNumber;
    public IntEventChannel broadcaster;
    Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SendNumber);
    }
     public void SendNumber()
    {
        broadcaster.RaiseEvent(buttonNumber);
    }
}
