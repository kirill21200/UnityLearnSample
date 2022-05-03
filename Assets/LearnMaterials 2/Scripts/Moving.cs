using UnityEngine;

public class Moving : SampleScript
{
    [SerializeField]
    private Vector3 targetPoint;
    [SerializeField]
    private float speed;
    private bool start = false;
    Transform myTransform;

    [ContextMenu("Move")]
    public override void Use()
    {
        myTransform = transform;
        start = true;

    }

    public void FixedUpdate()
    {
        if (start)
        {
            myTransform.position = Vector3.MoveTowards(myTransform.position, targetPoint, speed);
            if ((myTransform.position-targetPoint).magnitude<0.01F)
            {
                myTransform.position = targetPoint;
                start = false;
            }
        }
    }
}
