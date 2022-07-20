using UnityEngine;

public class SunMovingEmulation : MonoBehaviour
{
	private void Update()
	{
		transform.Rotate(-1f * Time.deltaTime, 2f * Time.deltaTime, 0);
	}
}
