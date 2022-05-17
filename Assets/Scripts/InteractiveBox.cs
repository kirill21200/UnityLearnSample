using UnityEngine;

public class InteractiveBox : MonoBehaviour
{
    [SerializeField]
    private InteractiveBox next;
    private Transform myTransform;
    private LineRenderer myLineRenderer;
    private const float rayDistance = 100f;

    void Start()
    {
        myTransform = transform;
        myLineRenderer = GetComponent<LineRenderer>();
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
            //Debug.DrawLine(myTransform.position, next.transform.position, Color.blue);

            if (Physics.Raycast(myTransform.position, next.transform.position - myTransform.position, out RaycastHit hit, rayDistance))
            {
                //Debug.Log(hit.collider.gameObject.name);
                DrawLine(hit);

                if (hit.collider.gameObject.GetComponent<ObstacleItem>())
                {
                    hit.collider.gameObject.GetComponent<ObstacleItem>().GetDamage(Time.deltaTime);
                }
            }
        }
    }

    void DrawLine(RaycastHit hit)
    {
        if(myLineRenderer.positionCount != 2)
        {
            myLineRenderer.positionCount = 2;
        }
        myLineRenderer.SetPosition(0, myTransform.position);
        myLineRenderer.SetPosition(1, hit.point);
    }
}
