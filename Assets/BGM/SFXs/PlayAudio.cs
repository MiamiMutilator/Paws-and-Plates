using UnityEngine;

// Very small helper to play a one-shot audio on demand.
// Usage:
// - Attach this to any GameObject.
// - Assign an AudioSource (or leave blank to use/add one on the same GameObject).
// - Assign an AudioClip (optional) and/or pass a clip to Play(clip).
// - Wire a UI Button's OnClick() to call Play() for spam-able feedback.
public class PlayAudio : MonoBehaviour
{
    [Tooltip("Optional AudioSource to use. If empty, one will be created on this GameObject.")]
    public AudioSource audioSource;

    [Tooltip("Default clip to play when Play() is called with no parameter.")]
    public AudioClip clip;

    [Tooltip("Volume for the one-shot (0..1)")]
    [Range(0f, 1f)]
    public float volume = 1f;

    private void Awake()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
            if (audioSource == null)
            {
                audioSource = gameObject.AddComponent<AudioSource>();
                audioSource.playOnAwake = false;
            }
        }
    }

    // Play the default clip (if assigned). This is what you wire to a Button's OnClick().
    public void Play()
    {
        if (clip == null)
            return;

        audioSource.PlayOneShot(clip, volume);
    }

    // Play a supplied clip (useful if you want to pass different clips via inspector events).
    public void Play(AudioClip overrideClip)
    {
        if (overrideClip == null)
            return;

        audioSource.PlayOneShot(overrideClip, volume);
    }
}
