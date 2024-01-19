using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] GameObject scoreText;

    public float Score = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.GetComponent<TextMeshProUGUI>().text = Score.ToString();
        if (Score >= 100)
        {
            SceneManager.LoadScene("CompletionScreen");
        }
    }
}
