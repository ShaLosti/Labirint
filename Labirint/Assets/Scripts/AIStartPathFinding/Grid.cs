using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
/*If you are making it for 2D, use Physics2D.OverlapCircle isntead of checkSphere
Since this is still the best video on pathfinding I'm hijacking 
top comment to say that all you need to do to make it 2D after using 
Physics2D.OverlapCircle is to change your two Vector3.forwards to Vector3.up 
and in the next video change worldPosition.z to worldPosition.y.
Oh and change your Gizmos.DrawWireCube to: 
Gizmos.DrawWireCube(transform.position, new Vector3(gridWorldSize.x, gridWorldSize.y, 1));*/
namespace RootNamespace.AIStartPathFinding
{ 
    public class Grid : MonoBehaviour
    {
        public LayerMask unWalkableMask;
        public Vector2 gridWorldSize;
        public float nodeRadius;
        Node[,] grid;

        private float nodeDiameter;
        int gridSizeX, gridSizeY;

        private void Start()
        {
            nodeDiameter = nodeRadius*2;
            gridSizeX = Mathf.RoundToInt(gridWorldSize.x / nodeDiameter);
            gridSizeY = Mathf.RoundToInt(gridWorldSize.y / nodeDiameter);

            CreateGrid();
        }

        private void CreateGrid()
        {
            grid = new Node[gridSizeX,gridSizeY];

            Vector2 worldBottomLeft = new Vector2(transform.position.x,transform.position.y) 
                - Vector2.right * gridWorldSize.x / 2
                - Vector2.up * gridWorldSize.y;

            for (int x = 0; x < gridSizeX; x++)
            {
                for (int y = 0; y < gridSizeY; y++)
                {
                    Vector2 worldPoint = worldBottomLeft + Vector2.right
                        * (x * nodeDiameter + nodeRadius) + Vector2.up 
                        * (y * nodeDiameter + nodeRadius);
                    bool walkable = !(Physics2D.OverlapCircle(worldPoint, nodeRadius, unWalkableMask));
                    grid[x, y] = new Node(walkable, worldPoint);
                }
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireCube(transform.position, new Vector3(gridWorldSize.x, gridWorldSize.y, 1));
            if(grid != null)
            {
                foreach (Node node in grid)
                {
                    Gizmos.color = (node.walkable) ? Color.white : Color.red;
                    Gizmos.DrawCube(node.worldPosition, Vector2.one * (nodeDiameter - 0.1f));
                }
            }
        }
    }
}
