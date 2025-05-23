using UnityEngine;

public class ScoreManager1 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trash"))
        {
            Destroy(other.gameObject);
            PointHUD.Instance.AddPoint();
        }
    }
}
