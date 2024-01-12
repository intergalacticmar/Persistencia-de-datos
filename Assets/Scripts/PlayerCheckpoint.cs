using UnityEngine;
using UnityEngine.UI;

public class PlayerCheckpoint : MonoBehaviour
{
    public Text checkpointText; 
    private int checkpointCount = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Checkpoint"))
        {
            checkpointCount++;
            checkpointText.text = "Checkpoints alcanzados: " + checkpointCount + "/3";

            if (checkpointCount == 3)
            {
                checkpointText.text = "Todos los checkpoints alcanzados";
            }
        }
    }
}
