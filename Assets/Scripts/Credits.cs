using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{
    GameObject Title;
    CanvasGroup TitleCG;
    GameObject continueM;
    CanvasGroup continueMCG;
    bool flag = false;
    private GameObject LevelLoader;
    // Start is called before the first frame update
    void Start()
    {
        LevelLoader = GameObject.Find("LevelLoader");
        Title = GameObject.Find("Title");
        TitleCG = Title.GetComponent<CanvasGroup>();
        continueM = GameObject.Find("Continue");
        continueMCG = continueM.GetComponent<CanvasGroup>();
        StartCoroutine(Starter());
        
    }

    // Update is called once per frame
    void Update()
    {
        if (flag == true) { StartCoroutine(Loop()); }
        if(flag == true && Input.GetKeyDown(KeyCode.Space))
        {
            LevelLoader.GetComponent<LevelLoader>().LoadMainMenu();
        }   
    }
    IEnumerator FadeIn(CanvasGroup CG, float seconds)
    {
        // loop over 2 seconds
        for (float i = 0; i <= seconds; i += Time.deltaTime)
        {
            CG.alpha = i/seconds;
            yield return null;
        }
    }
    IEnumerator FadeOut(CanvasGroup CG, float seconds)
    {
        for (float i = seconds; i >= 0; i -= Time.deltaTime)
        {
            CG.alpha = i/seconds;
            yield return null;
        }
    }
    IEnumerator Starter() 
    {
        GameObject SubT = GameObject.Find("sub title");
        CanvasGroup SubTCG = SubT.GetComponent<CanvasGroup>();
        GameObject Developers = GameObject.Find("developers");
        CanvasGroup DevelopersCG = Developers.GetComponent<CanvasGroup>();
        GameObject Names = GameObject.Find("names");
        CanvasGroup NamesCG = Names.GetComponent<CanvasGroup>();
        GameObject continueM = GameObject.Find("Continue");
        CanvasGroup continueMCG = continueM.GetComponent<CanvasGroup>();
        GameObject thanksM = GameObject.Find("thanks");
        CanvasGroup thanksMCG = thanksM.GetComponent<CanvasGroup>();
        StartCoroutine(FadeIn(SubTCG, 2));
        yield return new WaitForSeconds(3f);
        StartCoroutine(FadeIn(TitleCG, 2));
        yield return new WaitForSeconds(2f);
        StartCoroutine(FadeIn(DevelopersCG, 1));
        StartCoroutine(FadeIn(NamesCG, 2));
        yield return new WaitForSeconds(2f);
        StartCoroutine(FadeIn(thanksMCG, 2));
        yield return new WaitForSeconds(4f);
        StartCoroutine(FadeIn(continueMCG, 2));
        flag = true;
    }
    IEnumerator Loop()
    {
        StartCoroutine(FadeOut(continueMCG, 1f));
        StartCoroutine(FadeIn(continueMCG, 1f));
        yield return null;
    }
}
