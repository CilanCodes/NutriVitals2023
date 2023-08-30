
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScrollViewItem : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Image childImage;

    public void ChangeImage(Sprite image)
    {
        childImage.sprite = image;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}
