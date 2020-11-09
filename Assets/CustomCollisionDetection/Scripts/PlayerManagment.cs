using UnityEngine;
using System.Collections;
using navid021.CustomCollisionDetection;

public class PlayerManagment : MonoBehaviour
{
    public AreaCollisionExp1 eventListener1;
    public AreaCollisionExp2 eventListener2;

    Renderer thisMesh;

    public void ChangeColor1(object obj)
    {
        thisMesh.material.color = Color.red;
    }

    public void ChangeColor2(object obj)
    {
        thisMesh.material.color = (Color)obj;
    }

    private void Start()
    {
        thisMesh = GetComponent<Renderer>();
    }

    private void OnEnable()
    {
        eventListener1.eventAction += ChangeColor1;
        eventListener2.eventAction += ChangeColor2;
    }

    private void OnDisable()
    {
        eventListener1.eventAction -= ChangeColor1;
        eventListener2.eventAction -= ChangeColor2;
    }
}
