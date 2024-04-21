using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.EventSystems;

public class GlobalClick : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update() { }
}

public static class ProxyStandaloneInputModule
{
    private static StandaloneInputModule inputModule;
    private static FieldInfo m_PointerData;

    public static Dictionary<int, PointerEventData> GetPointerData()
    {
        if (m_PointerData == null)
            m_PointerData = typeof(StandaloneInputModule).GetField(
                "m_PointerData",
                BindingFlags.Instance | BindingFlags.NonPublic
            );
        if (inputModule == null)
            inputModule = GameObject.FindObjectOfType<StandaloneInputModule>();
        if (inputModule != null && m_PointerData != null)
        {
            return m_PointerData.GetValue(inputModule) as Dictionary<int, PointerEventData>;
        }

        return null;
    }
}
