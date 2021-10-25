using UnityEngine;

// Allows the game to play sound effects with the following values predefined
[System.Serializable]
public class Sound
{
	public string name;

	public AudioClip clip;

	[Range(0f, 1f)]
	public float volume;

	[Range(-3f, 3f)]
	public float pitch;

	public bool loop = false;

	[HideInInspector]
	public AudioSource source;
}