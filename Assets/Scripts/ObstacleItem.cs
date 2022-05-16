using UnityEngine;
using UnityEngine.Events;

public class ObstacleItem : MonoBehaviour
{
    [SerializeField]
    private float currentValue = 1;
    private Renderer rend;
    private float v = 0.1f;
    private Color subColor = new Color(0, 0.1f, 0.1f);
    [SerializeField]
    private UnityEvent onDestroyObstacle;
    [SerializeField]
    public Color color;

    void Start()
    {
        Debug.Log(gameObject.name);
        rend = GetComponent<Renderer>();
        color = rend.material.color;
        Debug.Log(gameObject.name);

        onDestroyObstacle.AddListener(() => Destroy(gameObject));

    }

    [ContextMenu("Нанести урон")]
    private void GetDamage()
    {
        changeColor();

        currentValue -= v;

        if (currentValue <= 0)
        {
            onDestroyObstacle.Invoke();
        }

    }

    private void changeColor()
    {
        color -= subColor;
        rend.material.color = color;
    }
}
