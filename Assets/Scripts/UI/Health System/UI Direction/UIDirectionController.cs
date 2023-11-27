using UnityEngine;

public class UIDirectionController : MonoBehaviour
{
    [SerializeField] private bool useRelativeRotation;
    private Quaternion relativeRotation;

    private void Start()
    {
        useRelativeRotation = true;
        relativeRotation = transform.parent.rotation;
    }

    private void Update()
    {
        if (useRelativeRotation)
        {
            transform.rotation = relativeRotation;
        }
    }
}