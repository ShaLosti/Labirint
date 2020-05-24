using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace RootNamespace.AIStartPathFinding
{
	public class Grid : MonoBehaviour
	{
		//public Transform plr;
		public bool displayGrid;
		public LayerMask unwalkableMask;
		public Vector2 gridWorldSize;
		public float nodeRadius;
		Node[,] grid;

		float nodeDiameter;
		int gridSizeX, gridSizeY;

		void Awake()
		{
			nodeDiameter = nodeRadius * 2;
			gridSizeX = Mathf.RoundToInt(gridWorldSize.x / nodeDiameter);
			gridSizeY = Mathf.RoundToInt(gridWorldSize.y / nodeDiameter);
			CreateGrid();
		}

		public int maxSize
		{
			get
			{
				return gridSizeX * gridSizeY;
			}
		}

		void CreateGrid()
		{
			grid = new Node[gridSizeX, gridSizeY];
			Vector2 worldBottomLeft = (Vector2)transform.position - Vector2.right * gridWorldSize.x / 2 - Vector2.up * gridWorldSize.y / 2;
			for (int x = 0; x < gridSizeX; x++)
			{
				for (int y = 0; y < gridSizeY; y++)
				{
					Vector2 worldPoint = worldBottomLeft + Vector2.right * (x * nodeDiameter + nodeRadius) + Vector2.up * (y * nodeDiameter + nodeRadius);
					bool walkable = (Physics2D.OverlapCircle(worldPoint, nodeRadius/*-.01f*/, unwalkableMask) == null);
					grid[x, y] = new Node(walkable, worldPoint,x,y);
				}
			}
		}

		public List<Node> GetNeighbourse(Node node, int depth = 1)
		{
			List<Node> neighbourse = new List<Node>();

			for (int x = -depth; x <= depth; x++)
			{
				for (int y = -depth; y <= depth; y++)
				{
					if (x == 0 && y == 0) 
						continue;

					int checkX = node.gridX + x;
					int checkY = node.gridY + y;

					if(checkX >= 0 && checkX < gridSizeX && checkY >= 0 && checkY < gridSizeY)
					{	
						neighbourse.Add(grid[checkX,checkY]);
					}
				}
			}
			return neighbourse;
		}

		public Node NodeFromWorldPoint(Vector2 worldPosition)
		{
			float percentX = worldPosition.x / gridWorldSize.x + 0.5f;
			float percentY = worldPosition.y / gridWorldSize.y + 0.5f;
			//float percentX = (worldPosition.x + gridWorldSize.x / 2) / gridWorldSize.x;
			//float percentY = (worldPosition.y + gridWorldSize.y / 2) / gridWorldSize.y;

			percentX = Mathf.Clamp01(percentX);
			percentY = Mathf.Clamp01(percentY);

			int x = Mathf.FloorToInt(Mathf.Min(gridSizeX * percentX, gridSizeX - 1));
			int y = Mathf.FloorToInt(Mathf.Min(gridSizeY * percentY, gridSizeY - 1));
			return grid[x, y];
		}

		public Node ClosestWalkableNode(Node node)
		{
			int maxRadius = Mathf.Max(gridSizeX, gridSizeY) / 2;
			for (int i = 1; i < maxRadius; i++)
			{
				Node n = FindWalkableInRadius(node.gridX, node.gridY, i);
				if (n != null)
				{
					return n;

				}
			}
			return null;
		}
		Node FindWalkableInRadius(int centreX, int centreY, int radius)
		{

			for (int i = -radius; i <= radius; i++)
			{
				int verticalSearchX = i + centreX;
				int horizontalSearchY = i + centreY;

				// top
				if (InBounds(verticalSearchX, centreY + radius))
				{
					if (grid[verticalSearchX, centreY + radius].walkable)
					{
						return grid[verticalSearchX, centreY + radius];
					}
				}

				// bottom
				if (InBounds(verticalSearchX, centreY - radius))
				{
					if (grid[verticalSearchX, centreY - radius].walkable)
					{
						return grid[verticalSearchX, centreY - radius];
					}
				}
				// right
				if (InBounds(centreY + radius, horizontalSearchY))
				{
					if (grid[centreX + radius, horizontalSearchY].walkable)
					{
						return grid[centreX + radius, horizontalSearchY];
					}
				}

				// left
				if (InBounds(centreY - radius, horizontalSearchY))
				{
					if (grid[centreX - radius, horizontalSearchY].walkable)
					{
						return grid[centreX - radius, horizontalSearchY];
					}
				}

			}

			return null;

		}

		bool InBounds(int x, int y)
		{
			return x >= 0 && x < gridSizeX && y >= 0 && y < gridSizeY;
		}

		void OnDrawGizmos()
		{
			Gizmos.DrawWireCube(transform.position, new Vector2(gridWorldSize.x, gridWorldSize.y));
			if (grid != null && displayGrid)
			{
				foreach (Node n in grid)
				{
					Gizmos.color = (n.walkable) ? Color.white : Color.red;
					Gizmos.DrawWireCube(n.worldPosition, Vector3.one * (nodeDiameter - .1f));
				}
			}
		}
	}
}