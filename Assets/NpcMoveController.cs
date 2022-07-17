using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcMoveController : MonoBehaviour
{
	[SerializeField] private NavMeshAgent navMeshAgent;
	[SerializeField] private List<Transform> pointsList = new List<Transform>();
	private const float DistanceToTarget = 1;
	private int _currentPointIndex;

	private void Start()
	{
		NewTargetPoint(_currentPointIndex);
	}

	private void FixedUpdate()
	{
		CheckTargetPoint();
	}

	private void CheckTargetPoint()
	{
		if (pointsList.Count == 0) return;
		if (_currentPointIndex > pointsList.Count)
		{
			Destroy(gameObject);
			return;
		}
		if (navMeshAgent.remainingDistance < DistanceToTarget)
			NewTargetPoint(++_currentPointIndex);
	}

	public void CreateNewTargetPointList(List<Transform> newTargetPointList)
	{
		pointsList.Clear();
		pointsList = newTargetPointList;
	}

	private void NewTargetPoint(int pointIndex)
	{
		if (pointsList.Count == 0 || pointIndex >= pointsList.Count) return;
		navMeshAgent.destination = pointsList[pointIndex].position;
	}
}
