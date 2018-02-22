using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AudioSource))]
public class CEnemyMoveHorizontally : MonoBehaviour 
{
    public float speed = 1f;
    public float moveAudioLoopTime = 1f;
    public float minRandomIdleTime = 0f;
    public float maxRandomIdleTime = 5f;
    
    private sbyte direction;
    private SpriteRenderer sprite;
    private Animator animator;
    private AudioSource audioSource;
    private float audioLoopTime;
    private float randomIdleTime;
    private float ellapsedIdleTime;
    private bool walk;

    #region Unity Callbacks
    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        direction = 1;
        audioLoopTime = audioSource.clip.length / moveAudioLoopTime;
        walk = true;
        animator.SetBool("Walk", walk);
        randomIdleTime = Random.Range(0f, maxRandomIdleTime);
        StartCoroutine(PlayLoopingMoveAudio());
    }

    private void Update()
    {
        ellapsedIdleTime += Time.deltaTime;
        if (ellapsedIdleTime > randomIdleTime)
        {
            walk = !walk;
            ellapsedIdleTime = 0f;
            randomIdleTime = Random.Range(minRandomIdleTime, maxRandomIdleTime);
            animator.SetBool("Walk", walk);
            audioSource.mute = !walk;
        }
        if(walk) transform.Translate(Vector2.right * direction * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        ReverseDirection();
    }

    #endregion
    
    #region Private Methods
    private void ReverseDirection()
    {
        direction *= -1;
        transform.localScale = new Vector3(direction, 1f, 1f);
    }

    private IEnumerator PlayLoopingMoveAudio()
    {
        while (true)
        {
            audioSource.Play();
            yield return new WaitForSeconds(audioLoopTime);
        }
    }
    #endregion
}
