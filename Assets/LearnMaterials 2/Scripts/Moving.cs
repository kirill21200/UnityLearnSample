using UnityEngine;

public class Moving : SampleScript
{
    [SerializeField]
    private Vector3 targetPoint;
    [SerializeField]
    private float speed;
    private bool start = false;

    [ContextMenu("Move")]
    public override void Use()
    {
        start = true;
    }

    public void FixedUpdate()
    {
        if (start)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPoint, speed);
        }
    }
}
