using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraSize : MonoBehaviour
{
    private CinemachineVirtualCamera _virtualCamera;
    private float _cameraSize = 6.6f;
    private float _camerZoomSpeed  = 2f;
    private float _camerMaxSize = 10f;
    private float _cameraMinSize = 3f;

    // Start is called before the first frame update
    void Start()
    {
        GameObject vCamObject = GameObject.Find("Virtual Camera");
        _virtualCamera = vCamObject.GetComponent<CinemachineVirtualCamera>(); 
    }

    // Update is called once per frame
    void Update()
    {
        var scroll = Input.GetAxis("Mouse ScrollWheel");
        if(scroll != 0) {
            _cameraSize -= scroll * _camerZoomSpeed;
            _cameraSize = Mathf.Clamp(_cameraSize, _cameraMinSize, _camerMaxSize);
            _virtualCamera.m_Lens.OrthographicSize = _cameraSize;
        }
    }
}
