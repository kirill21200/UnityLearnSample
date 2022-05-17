using UnityEngine;
using UnityEngine.Events;

public class ObstacleItem : MonoBehaviour
{
    [SerializeField]
    private float currentValue = 1;
    private Renderer rend;
    [SerializeField]
    public UnityEvent onDestroyObstacle;
    [SerializeField]
    public Color color;

    void Start()
    {
        rend = GetComponent<Renderer>();
        color = rend.material.color;
        onDestroyObstacle.AddListener(() => Destroy(gameObject));
    }

    [ContextMenu("Нанести урон")]
    public void GetDamage(float value)
    {
        changeColor(value);

        currentValue -= value;

        if (currentValue <= 0)
        {
            onDestroyObstacle?.Invoke();
        }

    }

    private void changeColor(float t)
    {
        color = Color.Lerp(color, Color.red, t);
        rend.material.color = color;
    }
}
