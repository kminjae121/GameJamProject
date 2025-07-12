using System;
using UnityEngine;

public class UIOpen : MonoBehaviour
{
    private bool isOpen = true;

    [SerializeField] private GameObject _soundUI;
    [SerializeField] private InputReader _inputReader;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isOpen)
            {
                isOpen = false;
                _soundUI.SetActive(true);
                _inputReader.OnDisable();
                Time.timeScale = 0;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else if (isOpen == false)
            {
                CloseUI();
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }

    public void CloseUI()
    {
        isOpen = true;
        _soundUI.SetActive(false);
        _inputReader.OnEnable();
        Time.timeScale = 1;
    }
}
