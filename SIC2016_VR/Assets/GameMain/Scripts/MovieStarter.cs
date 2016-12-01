using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Renderer))]
public class MovieStarter : MonoBehaviour {

	public string movieFile;
	// Use this for initialization
	void Start () {
		StartCoroutine(moviePlay());

	}

	private IEnumerator moviePlay()
	{
		string movieTexturePath = Application.streamingAssetsPath + "/" + movieFile;
		string url = "file:///" + movieTexturePath;
		WWW movie = new WWW(url);

		while (!movie.isDone)
		{
			yield return null;
		}

		MovieTexture movieTexture = movie.movie;

		while (!movieTexture.isReadyToPlay)
		{
			yield return null;
		}

		var renderer = GetComponent<MeshRenderer>();
		renderer.material.mainTexture = movieTexture;

		movieTexture.loop = true;
		movieTexture.Play();

	}

}
