using System.Collections.Generic;
using UnityEngine;

public class StartScripts : MonoBehaviour
{
    [SerializeField]
    private List<SampleScript> objects = new List<SampleScript>();
    
    [ContextMenu("Запустить скрипты")]
    public void RunScripts()
    {
        foreach(SampleScript obj in objects)
        {
            obj.Use();
        }
    }
    
}
