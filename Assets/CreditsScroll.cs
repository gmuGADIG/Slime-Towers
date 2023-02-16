using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsScroll : MonoBehaviour
{
    public RectTransform rectTransform;
    public float creditsSpeed;
    public int imagePhase;
    public List<GameObject> gameArt;

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        imagePhase = 0;
    }

    // Update is called once per frame
    void Update()
    {
        rectTransform.position = new Vector3(rectTransform.position.x, rectTransform.position.y + creditsSpeed, rectTransform.position.z);

        if (rectTransform.position.y > -1270 && imagePhase == 0 ||
            rectTransform.position.y > -620 && imagePhase == 1 ||
            rectTransform.position.y > 30 && imagePhase == 2 ||
            rectTransform.position.y > 680 && imagePhase == 3
            )
        {
            gameArt[imagePhase].SetActive(true);
            imagePhase++;
        }
        else if (rectTransform.position.y > 2200)
        {
            SceneManager.LoadScene("Title Menu");
        }
    }
}
