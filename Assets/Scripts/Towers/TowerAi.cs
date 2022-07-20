using System.Collections;
using Enemies;
using UnityEngine;

namespace Towers
{
	public class TowerAi : MonoBehaviour
	{
		[SerializeField] private LineRenderer lineRenderer;
		[SerializeField] private BaseTower baseTower;
		private BaseEnemy _focusedEnemy;

		private void Start()
		{
			lineRenderer.positionCount = 2;
			lineRenderer.startWidth = 0.7f;
			lineRenderer.endWidth = 0.1f;
			StartCoroutine(EnemyAttack());
		}

		private void FixedUpdate()
		{
			DrawLineToEnemy(_focusedEnemy);
		}

		private IEnumerator EnemyAttack()
		{
			while (true)
			{
				if (_focusedEnemy) _focusedEnemy.GetDamage(baseTower.damage);
				yield return new WaitForSeconds(baseTower.speedAttack);
			}
		}

		private void DrawLineToEnemy(BaseEnemy baseEnemy)
		{
			ClearLine();
			if (!_focusedEnemy) return;
			lineRenderer.positionCount = 2;
			lineRenderer.SetPosition(0, gameObject.transform.position);
			lineRenderer.SetPosition(1, baseEnemy.transform.position);
		}

		private void ClearLine() => lineRenderer.positionCount = 0;

		public void AddEnemyToFocus(BaseEnemy baseEnemy) => _focusedEnemy = baseEnemy;

		public void DeleteEnemyFocused() => _focusedEnemy = null;

		public BaseEnemy GetFocusedEnemy() => _focusedEnemy;

	}
}
