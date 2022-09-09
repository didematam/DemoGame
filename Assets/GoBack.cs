using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoBack : MonoBehaviour
{
    Button button;
    [SerializeField] UIScreenController uIScreenController;
    private void OnValidate()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(uIScreenController.CancelExit);
    }
}
