using UnityEngine;
using UnityEngine.UI;
using navid021.CustomCollisionDetection;

public class UIHandler : MonoBehaviour
{
    public Text text = null;
    public AreaCollisionExp1 eventListener1;
    public AreaCollisionExp2 eventListener2;

    private void OnEnable()
    {
        eventListener1.eventAction += ChangeUIElement;
        eventListener2.eventAction += ChangeUIElement2;
    }

    private void OnDisable()
    {
        eventListener1.eventAction -= ChangeUIElement;
        eventListener2.eventAction -= ChangeUIElement2;
    }

    void ChangeUIElement(object Element)
    {
        int number = Element == null ?  0 : (int)Element;
        text.text = number.ToString();
        text.color = Color.red;
    }

    void ChangeUIElement2(object Element)
    {
        Color color = Element == null ? Color.white : (Color)Element;
        text.color = color;
        text.text = "2";
    }
}
