using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitButton : MonoBehaviour
{
    Button button;
    [SerializeField] UIScreenController uIScreenController;
    private void OnValidate()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(uIScreenController.ExitQuestion);
    }

}
