using System.Collections.Generic;
using UnityEngine;

public class StartScripts : MonoBehaviour
{
    [SerializeField]
    private List<SampleScript> objects = new List<SampleScript>();
    
    [ContextMenu("��������� �������")]
    public void RunScripts()
    {
        foreach(SampleScript obj in objects)
        {
            obj.Use();
        }
    }
    
}
