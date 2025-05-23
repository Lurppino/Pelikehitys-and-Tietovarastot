using UnityEngine;

public class Door_Loki : MonoBehaviour
{
    public string doorName;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log($"Oven nimi: {doorName}");

            Animator animator = GetComponent<Animator>();
            if (animator != null)
            {
                animator.SetTrigger("OpenDoor");
            }

            GameEvents.Instance.OpenDoor(doorName);

            // Disable the GameObject after opening the door (optional)
            // If you just want to disable the Animator, use: animator.enabled = false;
            gameObject.SetActive(false);
        }
    }
}
