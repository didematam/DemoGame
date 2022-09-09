using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitButton : MonoBehaviour
{
    [SerializeField] Button button;
    [SerializeField] UIScreenController uIScreenController;
    private void OnValidate()
    {
        button.onClick.AddListener(uIScreenController.ExitQuestion);
    }
}
