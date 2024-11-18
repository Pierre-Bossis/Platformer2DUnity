using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSpecificScene : MonoBehaviour
{
    public AudioClip changeSceneSound;
    public string sceneName;
    public Animator fadeSystem;

    private void Awake()
    {
        fadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //dontdestroy pour pas que le son soit coupé pendant le changement de scène, il s'autodétruit quand même a la fin
            DontDestroyOnLoad(AudioManager.instance.PlayClipAt(changeSceneSound, transform.position));
            StartCoroutine(loadNextScene());
        }
    }

    public IEnumerator loadNextScene()
    {
        fadeSystem.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneName);
    }
}
