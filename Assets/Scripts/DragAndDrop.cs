using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IDragHandler, IPointerDownHandler,
    IPointerUpHandler
{
    private Vector3 _transformStart;
    private bool _tap, _check;

    private void Start()
    {
        _transformStart = transform.position;
    }

    private void Update()
    {
        if (!_tap && !_check)
        {
            _tap = true;
            transform.DOMove(_transformStart, 0.5f).SetEase(Ease.OutBack);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        _check = true;
        BoosterSing.instance.Boost(gameObject.tag,col.gameObject);
        Destroy(gameObject);
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        _check = false;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _tap = false;
    }




    public void OnDrag(PointerEventData eventData)
    {
        var cursor = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(cursor.x, cursor.y, transform.position.z);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _tap = true;
    }
}
