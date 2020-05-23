using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RootNamespace.AIStartPathFinding
{
    public class Pathfinding : MonoBehaviour
    {
        PathRequestManager requestManager;

        Grid grid;

        private void Awake()
        {
            TryGetComponent<PathRequestManager>(out requestManager);
            TryGetComponent<Grid>(out grid);
        }
        public void StartFindPath(Vector2 startPos, Vector2 targetPos)
        {
            StartCoroutine(FindPath(startPos, targetPos));
        }
        IEnumerator FindPath(Vector2 startPos, Vector2 targetPos)
        {
            Vector2[] wayPoints = new Vector2[0];
            bool pathSuccess = false;

            Node startNode = grid.NodeFromWorldPoint(startPos);
            Node targetNode = grid.NodeFromWorldPoint(targetPos);

            if (startNode.walkable && targetNode.walkable)
            {

                Heap<Node> openSet = new Heap<Node>(grid.maxSize);
                HashSet<Node> closeSet = new HashSet<Node>();

                openSet.Add(startNode);

                while (openSet.Count > 0)
                {
                    Node currentNode = openSet.RemoveFirst();

                    closeSet.Add(currentNode);

                    if (currentNode == targetNode)
                    {
                        pathSuccess = true;
                        break;
                    }

                    foreach (Node neighbour in grid.GetNeighbourse(currentNode))
                    {
                        if (!neighbour.walkable || closeSet.Contains(neighbour))
                            continue;

                        int newMovementCostToNeighbour = currentNode.gCost + GetDistance(currentNode, neighbour);
                        if (newMovementCostToNeighbour < neighbour.gCost || !openSet.Contains(neighbour))
                        {
                            neighbour.gCost = newMovementCostToNeighbour;
                            neighbour.hCost = GetDistance(neighbour, targetNode);
                            neighbour.parent = currentNode;

                            if (!openSet.Contains(neighbour))
                                openSet.Add(neighbour);

                        }
                    }
                }
            }
            yield return null;
            if (pathSuccess)
            {
                wayPoints = RetracePath(startNode, targetNode);
            }
            requestManager.FinishProcessingPath(wayPoints, pathSuccess);

        }

        Vector2[] RetracePath(Node startNode, Node endNode)
        {
            List<Node> path = new List<Node>();

            Node currentNode = endNode;

            while(currentNode != startNode)
            {
                if (currentNode == startNode)
                    path.Add(currentNode);
                currentNode = currentNode.parent;
            }
            Vector2[] waypoints = SimplifyPath(path);
            Array.Reverse(waypoints);
            return waypoints;
        }

        Vector2[] SimplifyPath(List<Node> path)
        {
            List<Vector2> waypoints = new List<Vector2>();
            Vector2 directionOld = Vector2.zero;

            for (int i = 1; i < path.Count; i++)
            {
                Vector2 directionNew = new Vector2(path[i - 1].gridX - path[i].gridX, path[i - 1].gridY - path[i].gridY);
                if (directionNew != directionOld)
                {
                    waypoints.Add(path[i - 1].worldPosition);
                }
                directionOld = directionNew;
            }
            return waypoints.ToArray();
        }

        int GetDistance (Node nodeA, Node nodeB)
        {
            int DistX = Mathf.Abs(nodeA.gridX - nodeB.gridX);
            int DistY = Mathf.Abs(nodeA.gridY - nodeB.gridY);
            //if (DistX > DistY)
            //    return 14 * DistY + 10 * (DistX - DistY);

            //return 14 * DistX + 10 * (DistY - DistX);
            return Mathf.Abs(nodeA.gridX - nodeB.gridX) + Mathf.Abs(nodeA.gridY - nodeB.gridY);
        }
    }
}
