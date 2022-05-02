using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteChildren : SampleScript
{
    [SerializeField]
    [Min(0)]
    private float destroyDelay = 0;

    private Transform targetTransform;

    [SerializeField]
    float speed = 0.1f;

    Vector3 targetScaleVector = new Vector3(0.2f, 0.2f, 0.2f);
    List<Transform> childList = new List<Transform>();

    void Start()
    {
        targetTransform = transform;
        foreach (Transform child in targetTransform)
        {
            childList.Add(child);
        }
    }

    [ContextMenu("DeleteChildren")]
    public override void Use()
    {
        StartCoroutine(deleteChildsCoroutine(childList, destroyDelay));
    }

    IEnumerator deleteChildsCoroutine(List<Transform> childList, float destroyDelay)
    {
        foreach (var child in childList)
        {
            Vector3 start = child.lossyScale;
            float t = 0;
            while (t < 1)
            {
                t += Time.deltaTime * speed;
                child.localScale = Vector3.Lerp(start, targetScaleVector, t);
                yield return null;
            }
            child.localScale = targetScaleVector;
            yield return new WaitForSeconds(destroyDelay);
        }

        foreach (var child in childList)
        {
            Destroy(child.gameObject);
        }

        yield break;
    }

    
}
