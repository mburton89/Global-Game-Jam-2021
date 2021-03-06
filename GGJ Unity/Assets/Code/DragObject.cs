﻿using UnityEngine;

public class DragObject : MonoBehaviour
{
    Vector3 screenPoint;
    Vector3 offset;
    Vector3 scanPos;
    Transform trans;

    private Vector3 _startPos;
    private Vector3 _endPos;

    void Start()
    {
        trans = this.transform;
        scanPos = trans.position;
        _sensitivity = 40f;
        _rotation = Vector3.zero;
    }

    void Update()
    {
        SetDirection();
    }

    void OnMouseDown()
    {
        _isRotating = true;
        _mouseReference = trans.position;
        _startPos = trans.position;
        screenPoint = Camera.main.WorldToScreenPoint(scanPos);
        offset = scanPos - Camera.main.ScreenToWorldPoint(
        new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        SlingShotManager.instance.aimer.eulerAngles = new Vector3(0, 0, 0);
        SlingShotManager.instance.setPath(true);

        GameSoundManager.Instance.SlingPull.Play();
        Player.Instance.ShowPullBackSprite();
    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        trans.position = curPosition;
        float posX = Mathf.Clamp(trans.position.x, -1.4f, 1.4f);
        float posY = Mathf.Clamp(trans.position.y, -3.5f, -2.36f);
        trans.position = new Vector3(posX, posY, curPosition.z);
    }

    void OnMouseUp()
    {
        _endPos = trans.position;
        _isRotating = false;
        trans.position = scanPos;

        //print( _startPos.y - _endPos.y);
        if (_startPos.y - _endPos.y > .15f || Mathf.Abs(_startPos.x - _endPos.x) > .15f)
        {
            SlingShotManager.instance.SlingAmmo();
        }
        else
        {
            Player.Instance.ShowIdle();
        }
        Invoke("ResetDirection", 0f);
    }

    void ResetDirection()
    {
        SlingShotManager.instance.aimer.eulerAngles = new Vector3(0, 0, 0);
        SlingShotManager.instance.setPath(false);
        SlingShotManager.instance.ObjectHolder.GetComponent<Collider2D>().enabled = true;
    }

    private float _sensitivity;
    private Vector3 _mouseReference;
    private Vector3 _mouseOffset;
    private Vector3 _rotation;
    private bool _isRotating;

    void SetDirection()
    {
        if (_isRotating)
        {
            _mouseOffset = (trans.position - _mouseReference);
            _rotation.z = (_mouseOffset.x) * _sensitivity;
            SlingShotManager.instance.aimer.Rotate(_rotation);
            _mouseReference = trans.position;
        }
    }
}