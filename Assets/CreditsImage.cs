using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsImage : MonoBehaviour
{
    public float fadeSpeed;
    public float lifetime;
    public Image creditsImage;
    public bool startToFadeOut;
    float counter = 0.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Awake()
    {
        creditsImage = GetComponent<Image>();
        creditsImage.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
        startToFadeOut = false;
    }

    // Update is called once per frame
    void Update()
    {
        counter += (1 * Time.deltaTime);

        if (counter > lifetime)
        {
            startToFadeOut = true;
        }


        if (startToFadeOut == false && creditsImage.color.a < 1.0f)
        {
            // creditsImage.tintColor = new Vector4(1.0f, 1.0f, 1.0f, creditsImage.tintColor.a + (fadeSpeed * Time.deltaTime));
            creditsImage.color = new Color(1.0f, 1.0f, 1.0f, creditsImage.color.a + (fadeSpeed*Time.deltaTime));
            Debug.Log("cheese is gay and i love her for that");
        }
        else if (startToFadeOut)
        {
            //creditsImage.tintColor = new Vector4(1.0f, 1.0f, 1.0f, creditsImage.tintColor.a - (fadeSpeed * Time.deltaTime));
            if (creditsImage.color.a > 0.0f)
            {
                creditsImage.color = new Color(1.0f, 1.0f, 1.0f, creditsImage.color.a - (fadeSpeed * Time.deltaTime));
            }
            else
            {
                this.gameObject.SetActive(false);
            }
            
        }
    }
}
