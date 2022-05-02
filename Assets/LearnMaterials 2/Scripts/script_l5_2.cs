using UnityEngine;

public class script_l5_2 : SampleScript
{
    [SerializeField]
    private float cx = 1;

    [SerializeField]
    private float cy = 1;

    [SerializeField]
    private float cz = 1;

    [SerializeField]
    private float seped = 1;

    private float t;

    private Quaternion startRotation;

    private Quaternion targetRotation;

    private void Awake()
    {
        t = -1;
    }
    private void Update()
    {
        Go();
    }

    private void Go()
    {
        if (t >= 0)
        {
            t += Time.deltaTime * seped;
            transform.rotation = Quaternion.Lerp(startRotation, targetRotation, t);
            if (t > 1)
            {
                t = -1;
            }
        }
    }

    [ContextMenu("Запуск")]
    public override void Use()
    {
        startRotation = transform.rotation;
        targetRotation = Quaternion.Euler(new Vector3(cx, cy, cz));
        t = 0;
    }
}
