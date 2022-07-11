using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class AbstractButton : MonoBehaviour
{
    [SerializeField]
    private UI.Type.EventType.ButtonEventType eventType;
    public UI.Type.EventType.ButtonEventType EventType { get { return eventType; } set { eventType = value; } }
}
