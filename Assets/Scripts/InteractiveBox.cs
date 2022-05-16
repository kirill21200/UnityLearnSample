using UnityEngine;

public class InteractiveBox : MonoBehaviour
{
    [SerializeField]
    private LayerMask obstacleitemsLayerMask;
    [SerializeField]
    private InteractiveBox next;
    private Transform myTransform;

    void Start()
    {
        myTransform = transform;
    }

    [ContextMenu("Добавить следующий")]
    private void AddNext(InteractiveBox box)
    {
        next = box;
    }

    void FixedUpdate()
    {
        if (next)
        {
            Debug.DrawLine(myTransform.position, next.transform.position, Color.blue);

            if (Physics.Linecast(myTransform.position, next.transform.position, out RaycastHit hit, obstacleitemsLayerMask))
            {
                if (hit.collider.gameObject.GetComponent<ObstacleItem>())
                {
                    hit.collider.gameObject.GetComponent<ObstacleItem>().GetDamage(Time.deltaTime);
                }
            }
        }
    }
}
