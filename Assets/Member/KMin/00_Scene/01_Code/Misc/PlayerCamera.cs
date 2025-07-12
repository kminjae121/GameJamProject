using System;
using DG.Tweening;
using Unity.Cinemachine;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private InputReader playerInput;
    [SerializeField] private CinemachineCamera playerCamera;
    [SerializeField] private float minZoom;
    [SerializeField] private float maxZoom;
    [SerializeField] private float zoomSpeed;

    private float _targetOthor;

    private void Awake()
    {
        playerInput.OnScrollEvent += HandleScroll;
        _targetOthor = playerCamera.Lens.OrthographicSize;
    }

    private void HandleScroll(float delta)
    {
        delta *= -1;
        _targetOthor += delta * zoomSpeed;
        _targetOthor = Mathf.Clamp(_targetOthor, minZoom, maxZoom);
        
        DOTween.Kill(playerCamera); // 이전 Tween이 남아있으면 제거
        DOTween.To(() => playerCamera.Lens.OrthographicSize, x => playerCamera.Lens.OrthographicSize = x, 
            _targetOthor, 0.3f);
    }
}
