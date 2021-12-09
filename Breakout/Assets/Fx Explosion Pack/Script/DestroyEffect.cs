using UnityEngine;
using System.Collections;

public class DestroyEffect : MonoBehaviour {

	void Start ()
	{
		StartCoroutine(Destruction());
	}

	IEnumerator Destruction()
    {
		yield return new WaitForSeconds(3);
		Destroy(gameObject);
    }

}
