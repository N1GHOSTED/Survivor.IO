using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using Unity.VisualScripting;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.EventSystems.EventTrigger;

public class movementJoystick : MonoBehaviour
{
    public GameObject ArrowDirecteur;
    public GameObject Gun;
    public GameObject joystick;
    public GameObject joystickBG;
    public Vector2 joystickVec;
    private Vector2 joystickTouchPos;
    private Vector2 joystickOriginalPos;
    private float joystickRadius;
    private int ActivePointerId = -1;
    public float InputMagnitude { get; private set; }


    void Update()
    {
        if(joystickVec.x == 0 && joystickVec.y == 0)
        {
            ArrowDirecteur.SetActive(false);
        }
        else
        {
            ArrowDirecteur.SetActive(true);
            ArrowDirecteur.transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2(-joystickVec.x, joystickVec.y) * 180 / Mathf.PI);
        }
        if(Gun.activeSelf == true)
        {
            Gun.transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2(-joystickVec.x, joystickVec.y) * 180 / Mathf.PI);
        }
    }
    void Start()
    {
        joystickOriginalPos = joystickBG.transform.position;
        joystickRadius = joystickBG.GetComponent<RectTransform>().sizeDelta.y / 4;
    }
    public void PointerDown()
    {
        ActivatePointer(-1, Input.mousePosition);
    }
    public void PointerDown(BaseEventData baseEventData)
    {
        PointerEventData pointerEventData = baseEventData as PointerEventData;
        Vector2 position = pointerEventData != null ? pointerEventData.position : (Vector2)Input.mousePosition;
        ActivatePointer(pointerEventData != null ? pointerEventData.pointerId : -1, position);
    }
    private void ActivatePointer(int pointerId, Vector2 position)
    {
        ActivePointerId = pointerId;
        joystick.transform.position = position;
        joystickBG.transform.position = position;
        joystickTouchPos = position;
        joystickVec = Vector2.zero;
        InputMagnitude = 0f;
    }
    public void Drag(BaseEventData baseEventData)
    {
        PointerEventData pointerEventData = baseEventData as PointerEventData;
        if (pointerEventData == null)
        {
            return;
        }
        if (ActivePointerId >= 0 && pointerEventData.pointerId != ActivePointerId)
        {
            return;
        }
        Vector2 dragePos = pointerEventData.position;
        float joystickDist = Vector2.Distance(dragePos, joystickTouchPos);
        joystickVec = joystickDist > 0f ? (dragePos - joystickTouchPos).normalized : Vector2.zero;
        InputMagnitude = Mathf.Clamp01(joystickDist / joystickRadius);
        if(joystickDist < joystickRadius)
        {
            joystick.transform.position = joystickTouchPos + joystickVec * joystickDist;
        }
        else
        {
            joystick.transform.position = joystickTouchPos + joystickVec * joystickRadius;
        }
    }
    public void PointerUp()
    {
        ActivePointerId = -1;
        joystickVec = Vector2.zero;
        InputMagnitude = 0f;
        joystick.transform.position = joystickOriginalPos;
        joystickBG.transform.position = joystickOriginalPos;
    }



}
