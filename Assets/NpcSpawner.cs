using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcSpawner : MonoBehaviour
{
	[SerializeField] private GameObject prefabNpc;
	[SerializeField] private List<Transform> pointsList;
	[SerializeField] private int npcCount = 10;

	private void Start()
	{
		StartCoroutine(CreatNpc());
	}

	// ReSharper disable Unity.PerformanceAnalysis
	private IEnumerator CreatNpc()
	{
		while (npcCount > 0)
		{
			var npc = Instantiate(prefabNpc);
			npc.GetComponent<NpcMoveController>().CreateNewTargetPointList(pointsList);
			npcCount--;
			yield return new WaitForSeconds(Random.Range(0.5f, 1f));
		}
	}
}
