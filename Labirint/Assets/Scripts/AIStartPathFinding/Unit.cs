using UnityEngine;
using System.Collections;

namespace RootNamespace.AIStartPathFinding
{
	public class Unit : MonoBehaviour
	{
		public Transform target;
		public float speed = 20;

		Vector2[] path;
		int targetIndex;

		//[SerializeField] Rigidbody2D rb;

		void Start()
		{
			StartCoroutine(RefreshPath());
			if (target == null)
				target = FindObjectOfType<CharacterInput>().transform;
			//TryGetComponent<Rigidbody2D>(out rb);
		}

		IEnumerator RefreshPath()
		{
			Vector2 targetPositionOld = (Vector2)target.position + Vector2.up; // ensure != to target.position initially

			while (true)
			{
				if (targetPositionOld != (Vector2)target.position)
				{
					targetPositionOld = (Vector2)target.position;

					path = Pathfinding.RequestPath(transform.position, target.position);
					StopCoroutine(FollowPath());
					StartCoroutine(FollowPath());
				}

				yield return new WaitForSeconds(.25f);
			}
		}

		IEnumerator FollowPath()
		{
			if (path.Length > 0)
			{
				targetIndex = 0;
				Vector2 currentWaypoint = path[0];

				while (true)
				{
					if ((Vector2)transform.position == currentWaypoint)
					{
						targetIndex++;
						if (targetIndex >= path.Length)
						{
							targetIndex = 0;
							path = new Vector2[0];
							yield break;
						}
						currentWaypoint = path[targetIndex];
					}

					transform.position = Vector2.MoveTowards(transform.position, currentWaypoint, speed * Time.deltaTime);
					//rb.MovePosition(new Vector2(rb.position.x, rb.position.y) + currentWaypoint * speed * Time.deltaTime);
					yield return null;

				}
			}
		}

		public void OnDrawGizmos()
		{
			if (path != null)
			{
				for (int i = targetIndex; i < path.Length; i++)
				{
					Gizmos.color = Color.black;
					//Gizmos.DrawCube((Vector3)path[i], Vector3.one *.5f);

					if (i == targetIndex)
					{
						Gizmos.DrawLine(transform.position, path[i]);
					}
					else
					{
						Gizmos.DrawLine(path[i - 1], path[i]);
					}
				}
			}
		}
	}

}