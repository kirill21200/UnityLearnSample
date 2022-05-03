using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObstacleItem : MonoBehaviour
{
    private float currentValue = 1;
    private Renderer rend;
    private float v = 0.1f;
    private UnityEvent onDestroyObstacle;
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    [ContextMenu("Нанести урон")]
    public void GetDamage()
    {
        currentValue -= v;

        if(currentValue < 0)
        {
            currentValue = 0;
        }
        changeColor();
    }

    private void changeColor()
    {
        rend.material.color = new Color(0.1f, 0, 0) * (1 - currentValue);
    }

    void Update()
    {
        
    }
}
