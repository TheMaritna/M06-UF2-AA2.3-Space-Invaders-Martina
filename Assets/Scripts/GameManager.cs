using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int score;
    

    [Header("UI")]
    public GameObject winText;
    public TMPro.TextMeshProUGUI scoreText;
    public TMPro.TextMeshProUGUI lifesText;

    [Header("Reference")]
    [SerializeField] public PLayerControler PC;
    private void Start()
    {
        winText.SetActive(false);
    }

    private void Update()
    {
        scoreText.text = score.ToString();
        lifesText.text = PC.lifes.ToString();
    }
}
