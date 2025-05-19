using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiEventExample : MonoBehaviour
{
    public Slider slider;
    public TMP_InputField inputfield;
    public Scrollbar scrollbar;

    private void Start()
    {
        slider.onValueChanged.AddListener(OnSliderValueChagned);

        scrollbar.onValueChanged.AddListener(OnScrollBarValueChanged);

        inputfield.onSelect.AddListener(OnSelectInputField);
        inputfield.onEndEdit.AddListener(OnEndEdit);
        inputfield.onValueChanged.AddListener(OnInputFieldValueChanged);
        inputfield.onDeselect.AddListener(OnDeselectInputField);
    }
    public void OnClickButton()
    {
        Debug.Log("Clicked.");
    }

    public void OnToggleValueChanged(bool isOn)
    {
        Debug.Log($"Toggle : {isOn}");
    }

    public void OnSliderValueChagned(float value)
    {
        Debug.Log($"Slider Value : {value}");
    }

    public void OnScrollBarValueChanged(float value)
    {
        Debug.Log($"Scroll Bar Value : {value}");
    }

    public void OnInputFieldValueChanged(string newValue)
    {
        Debug.Log($"유저의 입력 : {newValue}");
    }

    public void OnEndEdit(string value)
    {
        Debug.Log($"입력 끝 : {value}");
    }

    public void OnSelectInputField(string currentValue)
    {
        Debug.Log($"눌렀을 때 : {currentValue}");
    }

    public void OnDeselectInputField(string value)
    {
        Debug.Log($"뗏을 때 : {value}");
    }

    public void OnScrollRectValueChanged(Vector2 value)
    {
        Debug.Log($"Scroll Rect : {value}");
    }
}
