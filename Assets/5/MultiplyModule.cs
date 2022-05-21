using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplyModule : SampleScript
{
    [SerializeField]
    private GameObject prefab;

    [SerializeField]
    [Min(0)]
    [Tooltip("Количество")]
    private int Count;

    [SerializeField]
    [Min(0)]
    [Tooltip("Шаг")]
    private float Step;

    [ContextMenu("Запуск")]
    public void Use()
    {
        for (int i = 0; i < Count; i++)
        {
            Instantiate(prefab, prefab.transform.position + new Vector3(0, 0, Step), Quaternion.identity, transform);
        }
    }

    
}
