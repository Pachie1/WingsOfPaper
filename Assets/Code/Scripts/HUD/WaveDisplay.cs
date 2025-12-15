using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WaveDisplay : MonoBehaviour
{
    public int currentWave;
    public GameObject waveText;
    [SerializeField] TextMeshProUGUI textMesh;

    public EnemyManager enemyManager;
    void Start()
    {

    }

    void Update()
    {
        currentWave = enemyManager.currentWave;
        textMesh.text = "Wave " + currentWave.ToString();
    }


}
