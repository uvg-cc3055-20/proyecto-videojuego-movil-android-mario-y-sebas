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
    public bool walking;
    public sbyte direction;
    
    private Animator animator;
    private AudioSource audioSource;
    private float audioLoopTime;
    private float randomIdleTime;
    private float ellapsedIdleTime;
    private Vector3 originalScale;

    #region Unity Callbacks
    private void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        originalScale = transform.localScale;
        direction = 1;
        audioLoopTime = audioSource.clip.length / moveAudioLoopTime;
        walking = true;
        animator.SetBool("Walk", walking);
        randomIdleTime = Random.Range(minRandomIdleTime, maxRandomIdleTime);
        StartCoroutine(PlayLoopingMoveAudio());
    }

    private void Update()
    {
        ellapsedIdleTime += Time.deltaTime;
        if (ellapsedIdleTime > randomIdleTime)
        {
            walking = !walking;
            ellapsedIdleTime = 0f;
            randomIdleTime = Random.Range(minRandomIdleTime, maxRandomIdleTime);
            animator.SetBool("Walk", walking);
            audioSource.mute = !walking;
        }
        if(walking) transform.Translate(Vector2.right * direction * speed * Time.deltaTime);
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
        transform.localScale = new Vector3(originalScale.x * direction, originalScale.y, originalScale.z);
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
