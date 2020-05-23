using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace RootNamespace.AIStartPathFinding
{
    public class PathRequestManager : MonoBehaviour
    {
        Queue<PathRequest> pathRequestsQueue = new Queue<PathRequest>();
        PathRequest currentPathRequest;

        static PathRequestManager instance;

        Pathfinding pathfinding;

        bool isProcessinPath;

        private void Awake()
        {
            instance = this;
            TryGetComponent<Pathfinding>(out pathfinding);
        }

        public static void RequestPath(Vector2 pathStart, Vector2 pathEnd, Action<Vector2[], bool> callback)
        {
            PathRequest newRequest = new PathRequest(pathStart, pathEnd, callback);
            instance.pathRequestsQueue.Enqueue(newRequest);
            instance.TryProcessNext();
        }

        private void TryProcessNext()
        {
            if (!isProcessinPath && pathRequestsQueue.Count > 0)
            {
                currentPathRequest = pathRequestsQueue.Dequeue();
                isProcessinPath = true;
                pathfinding.StartFindPath(currentPathRequest.pathStart, currentPathRequest.pathEnd);
            }
        }

        public void FinishProcessingPath(Vector2[] path, bool success)
        {
            currentPathRequest.callback(path, success);
            isProcessinPath = false;
            TryProcessNext();
        }

        struct PathRequest
        {
            public Vector2 pathStart;
            public Vector2 pathEnd;
            public Action<Vector2[], bool> callback;

            public PathRequest(Vector2 _start, Vector2 _end, Action<Vector2[], bool> _callback)
            {
                pathStart = _start;
                pathEnd = _end;
                callback = _callback;
            }
        }
    }
}