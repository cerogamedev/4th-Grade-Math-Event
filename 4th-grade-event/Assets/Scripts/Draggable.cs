using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Draggable : MonoBehaviour
{    
    public bool IsDragging;
    public Vector3 LastPosition;

    private Collider2D _collider;
    private DragController _dragController;

    private float _movementTime = 15f;
    private System.Nullable<Vector3> _movementDestination;

    public string SlotName;

    public bool isTrue = false;

    public static int _numberOfAnswers = 0;

    void Start()
    {
        _collider = GetComponent<Collider2D>();
        _dragController = GetComponent<DragController>();
        _numberOfAnswers = 0;

    }
    private void Update()
    {
        if(isTrue)
        {
            _collider.enabled = false;
        }
    }
    void FixedUpdate()
    {
        if (_movementDestination.HasValue)
        {
            if (IsDragging)
            {
                _movementDestination = null;
                return;
            }
            if (transform.position == _movementDestination)
            {
                gameObject.layer = Layer.Default;
                _movementDestination = null;
            }
            else
                transform.position = Vector3.Lerp(transform.position, _movementDestination.Value, _movementTime * Time.fixedDeltaTime);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        Draggable collidedDraggable = collision.GetComponent<Draggable>();

        if (collidedDraggable != null && _dragController.LastDragged.gameObject == gameObject)
        {
            ColliderDistance2D colliderDistance2D = collision.Distance(_collider);
            Vector3 diff = new Vector3(colliderDistance2D.normal.x, colliderDistance2D.normal.y) * colliderDistance2D.distance;
            transform.position -= diff;
        }
        if (collision.CompareTag("DropValid") && collision.name == SlotName)
        {
            _movementDestination = collision.transform.position;
            isTrue = true;
            _numberOfAnswers += 1;

        }
        else if (collision.CompareTag("DropInvalid"))
        {
            _movementDestination = LastPosition;
        }
        else
            _movementDestination = LastPosition;
    }
}
