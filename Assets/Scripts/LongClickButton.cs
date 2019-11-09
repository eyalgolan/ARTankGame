using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class LongClickButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool pointerDown;
    public float pointDownTimer;
    public float force;
    public int timesPower = 200;
    public float maxTimeHold;
    public UnityEvent onLongClick;
    public PlayerShoot playerShooter;
    [SerializeField]
    //private Image fillImage;

    public void OnPointerDown(PointerEventData eventData)
    {
        pointerDown = true;
        Debug.Log("down pressed");
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        force = pointDownTimer * timesPower;
        playerShooter.Shoot(pointDownTimer * timesPower);
        Reset();
        Debug.Log("up pressed");
    }
    // Start is called before the first frame update
    void Start()
    {
        if (timesPower == 0)
        {
            timesPower = 200;
        }
    }
    void FixedUpdate()
    {
        if (pointerDown)
        {
            pointDownTimer += (1000 * Time.deltaTime);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (pointerDown)
        {
            pointDownTimer += (1000*Time.deltaTime);
            if(pointDownTimer >= maxTimeHold)
            {
                if(onLongClick != null)
                {
                    
                    onLongClick.Invoke();
                }
                
                Reset();
            }
        }
    }
    void Reset()
    {
        pointerDown = false;
        pointDownTimer = 0;
    }
}
