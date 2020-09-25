using UnityEngine;

public class SyncTransformPosition : MonoBehaviour
{
    [SerializeField]
    Vector3Variable positionVariable;

    [SerializeField]
    [HideInInspector]
    Transform tr;

    void Start()
    {
       positionVariable.value = new Vector3(20, -70, -20); // Prasárna
    }


    void LateUpdate()
    {
        tr.position = positionVariable;
    }

#if UNITY_EDITOR
    void OnValidate()
    {
        tr = GetComponent<Transform>();
    }
#endif
}
