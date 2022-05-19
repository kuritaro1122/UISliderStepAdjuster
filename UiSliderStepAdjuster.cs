using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
internal class UISliderStepAdjuster : MonoBehaviour {
    [Range(0, 0.1f)] public float step = 0.025f;
    private Slider _slider;
    private float prevValue;

    void Start() {
        this._slider = this.GetComponent<Slider>();
        this._slider.onValueChanged.AddListener(StepSliderFix);
        this.prevValue = _slider.value;
    }
    void OnEnable() {
        if (_slider != null) this.prevValue = _slider.value;
    }

    public void StepSliderFix(float value) {
        value = prevValue + Mathf.Clamp(value - prevValue, -this.step, this.step);
        this.prevValue = _slider.value = value;
    }
}