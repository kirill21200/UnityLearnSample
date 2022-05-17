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
    public void AddNext(InteractiveBox box)
    {
        next = box;
    }

    void FixedUpdate()
    {
        if (next)
        {
            Debug.DrawLine(myTransform.position, next.transform.position, Color.blue);

            if (Physics.Raycast(myTransform.position, next.transform.position, out RaycastHit hit, obstacleitemsLayerMask))
            {
                Debug.Log(hit.collider.gameObject.name);

                if (hit.collider.gameObject.GetComponent<ObstacleItem>())
                {
                    hit.collider.gameObject.GetComponent<ObstacleItem>().GetDamage(Time.deltaTime);
                }
            }
        }
    }
}
