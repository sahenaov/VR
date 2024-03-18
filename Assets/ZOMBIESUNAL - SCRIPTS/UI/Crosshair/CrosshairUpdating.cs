using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrosshairUpdating : MonoBehaviour
{
    [SerializeField] bool update = false;
    [SerializeField] RectTransform reticleLines;
    [SerializeField] Transform lineHandler;
    [SerializeField] RectTransform reticlePoint, rechargePoint;
    [SerializeField] RectTransform Up,Down,Left,Right;
    [SerializeField] RectTransform OffUp, OffDown, OffLeft, OffRight;
    private RectTransform mainReticle;

    [Range(0,360)]
    [SerializeField] private float rotation;

    [Range(0,50)]
    [SerializeField] private float Weight, Height;

    [SerializeField] private Color color = new Color(255, 255, 255, 255);
    [SerializeField] private Color colorRecharge = new Color(255, 255, 255, 255);

    private Image[] images;

    [SerializeField] private Slider sliderLineSize;
    [SerializeField] private Slider sliderLineRot;
    [SerializeField] private Slider sliderDotSize;
    [SerializeField] private Slider sliderLineWidth;
    [SerializeField] private Slider sliderLineLenght;

    private void Start()
    {
        mainReticle = GetComponent<RectTransform>();
        images = GetComponentsInChildren<Image>();

        if(update) {return;}
        reticlePoint.gameObject.SetActive(false);
    }

    private void Update()
    {
        if(!update) {return;}

        transform.localPosition = new Vector3(500, 0, 0);
        transform.rotation = Quaternion.Euler(0,rotation,0);

        reticleLines.sizeDelta = new Vector2(sliderLineSize.value, sliderLineSize.value);
        lineHandler.rotation = Quaternion.Euler(0,rotation, sliderLineRot.value);

        Up.sizeDelta = new Vector2(Weight-27.5f, Height);
        Down.sizeDelta = Up.sizeDelta;

        Right.sizeDelta = new Vector2(Height, Weight-27.5f);
        Left.sizeDelta = Right.sizeDelta;

        reticlePoint.localScale = new Vector2(sliderDotSize.value, sliderDotSize.value);

        OffUp.localScale = new Vector2(sliderLineWidth.value, sliderLineLenght.value);
        OffDown.localScale = OffUp.localScale;
        OffLeft.localScale = new Vector2(sliderLineLenght.value, sliderLineWidth.value);
        OffRight.localScale = OffLeft.localScale;

        foreach(Image image in images)
        {
            image.color = color;
        } 
    }

    [ContextMenu("Save")]
    public void SaveCrossHair()
    {
        transform.localPosition = new Vector3(500, 0, 0);
        transform.rotation = Quaternion.Euler(0,0,0);

        reticleLines.sizeDelta = new Vector2(sliderLineSize.value, sliderLineSize.value);
        lineHandler.rotation = Quaternion.Euler(0,0, sliderLineRot.value); 

        reticlePoint.localScale = new Vector2(sliderDotSize.value, sliderDotSize.value);

        OffUp.localScale = new Vector2(sliderLineWidth.value, sliderLineLenght.value);
        OffDown.localScale = OffUp.localScale;
        OffLeft.localScale = new Vector2(sliderLineLenght.value, sliderLineWidth.value);
        OffRight.localScale = OffLeft.localScale;

        foreach(Image image in images)
        {
            image.color = color;
        } 
    }

    [ContextMenu("Reload")]
    public void Reload()
    {
        reticlePoint.gameObject.SetActive(false);
        rechargePoint.gameObject.SetActive(true);

        foreach(Image image in images)
        {
            image.color = colorRecharge;
        } 
    }

    [ContextMenu("Reloaded")]
    public void Reloaded()
    {
        reticlePoint.gameObject.SetActive(true);
        rechargePoint.gameObject.SetActive(false);

        foreach(Image image in images)
        {
            image.color = color;
        } 
    }
}
