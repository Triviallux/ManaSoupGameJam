using UnityEngine;



public class GrabItem : MonoBehaviour
{
   
    private bool _grabbedItem;
    private bool _checkedItem;
    public float _ItemCheckRadius;
    public float _ItemCheckOffset;

    //Timeout Click
    public float _buttonTimeout;
    private bool _buttonReset;
    private float _timer;
    //Grab Objects
    public Transform _ItemGrabParent;
    public GameObject _ItemToGrab;
    public GameObject _HintIcon;
    //Animation IDs
    private int _animIDgrabItem;


    public LayerMask _ItemLayers;


    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        GrabOrDrop();
        if (CheckforItem())
        {
            _HintIcon.SetActive(true);
        }
        else
        {
            _HintIcon.SetActive(false);
        }
    }

    private bool CheckforItem()
    {   
        // update animator if using character
        return Physics.Raycast(Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f)), _ItemCheckRadius, _ItemLayers, QueryTriggerInteraction.Ignore); 
    }

    public void GrabOrDrop()
    {
        _timer += Time.deltaTime;

        if (Input.GetKey(KeyCode.Mouse0) && _buttonTimeout < _timer && _buttonReset && Time.timeScale > 0.1f)
        {
            _buttonReset = false;
            if (_grabbedItem)
            {
                DropItem();
            }
            else
            {
                GrabItems();
            }
            _timer = 0;
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            _buttonReset = true;
        }
    }

    public void GrabItems()
    {
        if (!CheckforItem())
            return;
        Vector3 spherePosition = new Vector3(transform.position.x, transform.position.y - _ItemCheckOffset, transform.position.z);
        _ItemToGrab = Physics.OverlapSphere(spherePosition, _ItemCheckRadius, _ItemLayers, QueryTriggerInteraction.Ignore)[0].gameObject;

        
        if (_ItemToGrab != null)
        {
            _ItemToGrab.GetComponent<Rigidbody>().isKinematic = true;
            _ItemToGrab.transform.SetParent(_ItemGrabParent, false);
            if (_ItemToGrab.GetComponent<AudioSource>() != null)
            {
                _ItemToGrab.GetComponent<AudioSource>().Stop();
            }
            
            _ItemToGrab.transform.position = _ItemGrabParent.transform.position;
            _grabbedItem = true;
        }

    }

    public void DropItem()
    {

        _ItemToGrab.GetComponent<Rigidbody>().isKinematic = false;
        _ItemToGrab.transform.SetParent(null);
        _ItemToGrab.GetComponent<Rigidbody>().velocity = Vector3.zero;
        _ItemToGrab.transform.position = _ItemGrabParent.transform.position + new Vector3(0, 2, 0);

        _ItemToGrab = null;
        _grabbedItem = false;

    }
}
