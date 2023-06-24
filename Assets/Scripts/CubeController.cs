using System.Collections;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    private Rigidbody _cubeRigidbody;
    private float _spawnCheckRadius;
    private bool _canPush;
    private bool _canMove;

    public Transform SpawnPosition;
    public float PushForse;

    private void Start()
    {

        if (gameObject.transform.position.x > 4)
        {
            _canPush = true;

        }
        _cubeRigidbody = GetComponent<Rigidbody>();
        _canMove = false;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (CheckSpawnLocation() && gameObject.transform.position.x > 4)
            {
                _canMove = true;
            }

        }
        else if (_canMove && Input.GetMouseButton(0))
        {
            CubeHorizontalMove();
        }
        else if (Input.GetMouseButtonUp(0) && _canPush)
        {

            _canMove = false;

            _cubeRigidbody.AddForce(Vector3.left * PushForse, ForceMode.Impulse);

            _canPush = false;

        }

    }

    private void CubeHorizontalMove()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float zPosition = Mathf.Clamp(transform.position.z + mouseX / 5, -4f, 4f);
        transform.position = new Vector3(transform.position.x, transform.position.y, zPosition);
    }

    private bool CheckSpawnLocation()
    {
        Collider[] colliders = Physics.OverlapBox(transform.position, new Vector3(_spawnCheckRadius, _spawnCheckRadius, _spawnCheckRadius));

        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("SpawnPosition"))
            {
                return false;
            }
        }

        return true;
    }

}



