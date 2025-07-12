using System;
using UnityEngine;

public class UIOpen : MonoBehaviour
{
    private bool isOpen = true;

    [SerializeField] private GameObject _soundUI;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isOpen)
            {
                isOpen = false;
                _soundUI.SetActive(true);
            }
            else if (isOpen == false)
            {
                CloseUI();
            }
        }
    }

    public void CloseUI()
    {
        isOpen = true;
        _soundUI.SetActive(false);
    }
}
