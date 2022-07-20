using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Enemies
{
	public class EnemyMove : MonoBehaviour
	{
		[SerializeField] private BaseEnemy baseEnemy;
		[SerializeField] private NavMeshAgent navMeshAgent;
		[SerializeField] private List<Transform> pathPointsList = new List<Transform>();
		private int _currentPointIndex;

		private void Start()
		{
			NewTargetPathPoint(_currentPointIndex);
		}

		private void FixedUpdate()
		{
			CheckTargetPathPoint();
		}

		private void CheckTargetPathPoint()
		{
			if (pathPointsList.Count == 0) return;
			if (_currentPointIndex > pathPointsList.Count)
			{
				baseEnemy.DestroyEnemy(baseEnemy);
				return;
			}

			if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
				NewTargetPathPoint(++_currentPointIndex);
		}

		public void CreateNewPathPointsList(List<Transform> newPathPointsList)
		{
			pathPointsList.Clear();
			pathPointsList = newPathPointsList;
			transform.position = pathPointsList[0].position;
		}

		private void NewTargetPathPoint(int pointIndex)
		{
			if (pathPointsList.Count == 0 || pointIndex >= pathPointsList.Count) return;
			navMeshAgent.destination = pathPointsList[pointIndex].position;
		}
	}
}
