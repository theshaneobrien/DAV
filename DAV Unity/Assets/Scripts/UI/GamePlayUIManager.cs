using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GamePlayUIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI contextSensitiveText;

    private void Start()
    {
        HideText();   
    }

    public void SetContextText(string textToDisplay)
    {
        contextSensitiveText.gameObject.SetActive(true);
        contextSensitiveText.text = textToDisplay;
    }

    public void HideText()
    {
        contextSensitiveText.gameObject.SetActive(false);
    }
}
