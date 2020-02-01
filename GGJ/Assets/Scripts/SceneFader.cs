using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class SceneFader : MonoBehaviour
{
    //J: modificado de https://gamedevelopertips.com/unity-how-fade-between-scenes/ . controla esmaecimento para transição entre cenas

    //J: objeto imagem que esmaece e tempo até terminar processo
    public Image fadeOutUIImage;
    public float fadeSpeed = 0.8f;

    //J: direção de esmaecimento.
    public enum FadeDirection
    {
        In, //Alpha = 1
        Out // Alpha = 0
    }

    //J: inicia o processo de esmaecimento quando habilitar o objeto
    void OnEnable()
    {
        StartCoroutine(Fade(FadeDirection.Out));
    }

    //J: corrotina para controlar o esmaecimento
    private IEnumerator Fade(FadeDirection fadeDirection)
    {
        //J: prepara valores iniciais e finais para esmaecimento
        float alpha = (fadeDirection == FadeDirection.Out) ? 1 : 0;
        float fadeEndValue = (fadeDirection == FadeDirection.Out) ? 0 : 1;
        if (fadeDirection == FadeDirection.Out)
        {
            //J: se fadeout, aumenta alpha até maximo gradualmente
            while (alpha >= fadeEndValue)
            {
                SetColorImage(ref alpha, fadeDirection);
                yield return null;
            }
            fadeOutUIImage.enabled = false;
        }
        else
        {
            //J: senão, reduz alpha até 0 gradualmente
            Debug.Log("Fading in...");
            fadeOutUIImage.enabled = true;
            while (alpha <= fadeEndValue)
            {
                SetColorImage(ref alpha, fadeDirection);
                Debug.Log("fading...");
                yield return null;
            }
            Debug.Log("Fade in complete!");
        }
    }

    //J: corrotina que efetua esmaecimento e depois 
    public IEnumerator FadeAndLoadScene(FadeDirection fadeDirection, string sceneToLoad)
    {

        yield return Fade(fadeDirection);
        Debug.Log($"Loading scene '{sceneToLoad}'...");
        SceneManager.LoadScene(sceneToLoad);
    }

    //J: altera o alpha da imagem conforme a direção escolhida
    private void SetColorImage(ref float alpha, FadeDirection fadeDirection)
    {
        fadeOutUIImage.color = new Color(fadeOutUIImage.color.r, fadeOutUIImage.color.g, fadeOutUIImage.color.b, alpha);
        alpha += Time.deltaTime * (1.0f / fadeSpeed) * ((fadeDirection == FadeDirection.Out) ? -1 : 1);
    }

}