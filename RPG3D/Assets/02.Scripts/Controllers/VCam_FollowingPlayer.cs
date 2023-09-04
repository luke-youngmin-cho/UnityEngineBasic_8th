using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using RPG.Controllers;

public class VCam_FollowingPlayer : ControllerBase
{
    private CinemachineVirtualCamera _vCam;
    [SerializeField] private float _rotateSpeedY;
    [SerializeField] private float _rotateSpeedX;
    [SerializeField] private float _angleXMin = -8.0f;
    [SerializeField] private float _angleXMax = 45.0f;
    [SerializeField] private float _fovMin = 3.0f;
    [SerializeField] private float _fovMax = 60.0f;
    [SerializeField] private float _scrollThreshold;
    [SerializeField] private float _scrollSpeed;

    private Transform _followTarget;
    private Transform _followTargetRoot;

    protected override void Awake()
    {
        base.Awake();
        _vCam = GetComponent<CinemachineVirtualCamera>();
        _followTarget = _vCam.Follow;
        _followTargetRoot = _followTarget.root;
    }

    private void LateUpdate()
    {
        if (controlEnabled == false)
            return;

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        _followTargetRoot.Rotate(Vector3.up, mouseX * _rotateSpeedY * Time.deltaTime, Space.World);
        _followTarget.Rotate(Vector3.left, mouseY * _rotateSpeedX * Time.deltaTime, Space.Self);
        _followTarget.eulerAngles = new Vector3(ClampAngle(_followTarget.eulerAngles.x, _angleXMin, _angleXMax),
                                                _followTarget.eulerAngles.y,
                                                0.0f);

        if (Mathf.Abs(Input.mouseScrollDelta.y) > _scrollThreshold)
        {
            _vCam.m_Lens.FieldOfView -= Input.mouseScrollDelta.y * _scrollSpeed * Time.deltaTime;
            if (_vCam.m_Lens.FieldOfView < _fovMin)
                _vCam.m_Lens.FieldOfView = _fovMin;
            else if (_vCam.m_Lens.FieldOfView > _fovMax)
                _vCam.m_Lens.FieldOfView = _fovMax;
        }
    }

    // 음수 각도에 대해서는 360도를 더한후 360 모듈러연산하면 양수로 클램핑 가능
    private float ClampAngle(float angle, float min, float max)
    {
        angle = (angle + 360.0f) % 360.0f;

        if (angle > 180.0f)
        {
            angle -= 360.0f;
        }

        return Mathf.Clamp(angle, min, max);
    }
}
