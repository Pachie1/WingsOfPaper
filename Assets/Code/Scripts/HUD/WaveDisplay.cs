using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WaveDisplay : MonoBehaviour
{
    public int currentWave;
    public GameObject waveText;
    [SerializeField] TextMeshProUGUI textMesh;

    public EnemyManager enemyManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        currentWave = enemyManager.currentWave;
        textMesh.text = "Wave " + currentWave.ToString();
    }


}
