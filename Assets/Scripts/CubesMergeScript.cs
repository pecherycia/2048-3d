using UnityEngine;


public class CubesMergeScript : MonoBehaviour
{
    private float _force;
    private float _speedForce;
    private Rigidbody _rb;
    private GameObject _nextRangCube;
    public GameObject[] CubesRang;
    private CubesMergeScript _mergeScript;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _mergeScript = gameObject.GetComponent<CubesMergeScript>();               
    }

    private void Update()
    {
        Vector3 velocity = _rb.velocity;
        _force = velocity.magnitude;
    }


    private void OnCollisionEnter(Collision collision)
    {
        float collisionForce = collision.impulse.magnitude;

        if (_mergeScript != null)
        {

            _speedForce = _mergeScript._force;

        }

        if (_speedForce > 10 && collisionForce > 10 && gameObject.name == collision.gameObject.name)
        {

            CubesMerge(collision);

        }
        else if (_speedForce < 10 && collisionForce < 10)
        {
            if (collision.rigidbody != null)
            {
                Vector3 _pushDirection = transform.position - collision.transform.position;
                _pushDirection.Normalize();

                collision.rigidbody.AddForce(_pushDirection * 5f, ForceMode.Impulse);
            }

        }

    }


    private void CubesMerge(Collision _collision)
    {
       

        Vector3 _newRangCubePosition = gameObject.transform.position;
        Quaternion _newRangCubeRotation = gameObject.transform.rotation;
        for (int i = 0; i < CubesRang.Length; i++)
        {
            if (i < CubesRang.Length-1)
            {
                if (_collision.gameObject.name == CubesRang[i].gameObject.name)
                {
                    _nextRangCube = CubesRang[i + 1];

                    break;
                }
            }
        }       

        Destroy(_collision.gameObject);
        Destroy(gameObject);
      
        if(_nextRangCube!=null)
        {
            GameObject instantiatedObject = Instantiate(_nextRangCube, _newRangCubePosition, _newRangCubeRotation);
            ParticleSystem particleSystem = instantiatedObject.GetComponent<ParticleSystem>();
            

            if (particleSystem != null)
            {
                
                particleSystem.Play(); 
            }
        }

    }
}
