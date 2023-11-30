using System.Collections;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private Transform[] _diamondPoints;

    private void Awake()
    {
        _rb.useGravity = false;
        _rb.isKinematic = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            StartCoroutine(FallCountdown());
    }

    private IEnumerator FallCountdown()
    {
        yield return new WaitForSeconds(0.5f);

        _rb.useGravity = true;
        _rb.isKinematic = false;

        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }

    // This method places the diamond then offsets it for more variation in gameplay
    public void AddDiamond(Diamond diamond)
    {
        diamond.transform.parent = transform;
        int diamondPoint = Random.Range(0, _diamondPoints.Length);

        diamond.transform.position = _diamondPoints[diamondPoint].position;
    }
}
