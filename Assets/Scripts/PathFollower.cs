using UnityEngine;
using PathCreation;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

//[RequireComponent(typeof(PathCreator))]
public class PathFollower : MonoBehaviour
{
    public PathCreator pathCreator;
    public GameObject player;
    public EndOfPathInstruction endOfPathInstruction;
    public float speed = 2;

    public float distanceTraveled;
    /*public float distanceTraveledDeviate;
    public float distanceMaxDeviate = 10;
    bool activeJourney = false;
    bool traveling = false;
    PathCreator creator;*/

    private void Start()
    {
        if (pathCreator != null)
            pathCreator.pathUpdated += OnPathChanged;
    }

    // Function to let this object to follower the path
    private float FollowPath(PathCreator pathC, float distance, EndOfPathInstruction end = EndOfPathInstruction.Loop)
    {
        distance += speed * Time.deltaTime;
        transform.position = pathC.path.GetPointAtDistance(distance, end);
        transform.rotation = pathC.path.GetRotationAtDistance(distance, end);
        return distance;

    }

    private float GetDistanceToObj(GameObject obj)
    {
        return (transform.position - obj.transform.position).magnitude;
    }


    private void Update()
    {
        //Debug.Log(getDistanceToObj(player));
        /*if (pathCreator != null && getDistanceToObj(player) > minDistanceToPlayer && !activeJourney)
        else
            deviatePath();*/
        distanceTraveled = FollowPath(pathCreator, distanceTraveled, endOfPathInstruction);

    }


    /*private void setupDeviatingPath()
    {
            creator = (PathCreator)Instantiate(pathCreator);

            Vector3 srcPoint = pathCreator.path.GetPointAtDistance(distanceTraveled, endOfPathInstruction);

            Vector3 dstPoint = player.transform.position;

            Vector3 endPoint = pathCreator.path.GetPointAtDistance(distanceTraveled + distanceMaxDeviate, endOfPathInstruction);

            Vector3[] waypoints = { 
            creator.transform.InverseTransformPoint(srcPoint) , 
            creator.transform.InverseTransformPoint(dstPoint),
            creator.transform.InverseTransformPoint(endPoint)
            };

            //Debug.Log(String.Format("Distance: {3}, SRC: {0}, DST: {1}, END: {2}", srcPoint, dstPoint, endPoint, distanceTraveled));

            BezierPath bezierPath = new BezierPath(waypoints, false, PathSpace.xz);
            

            creator.bezierPath = bezierPath;
           
            Debug.Log(String.Format(
                "wp: {0}\nsrc: {1}\ndst: {2}\nend: {3}\nwaypoints:\n{4}\nbezier:\n{5}\nsegments: {6}",
                transform.position,
                srcPoint, 
                dstPoint,
                endPoint,
                String.Join(",\n", waypoints),
                String.Join(",\n", creator.bezierPath.GetPoints()),
                creator.bezierPath.NumSegments
                ));
    }
    private void deviatePath()
    {
        
        if (!activeJourney)
        {
            distanceTraveledDeviate = 0;
            setupDeviatingPath();
            activeJourney = true;
        }
        if (activeJourney && !traveling)
        {
            traveling = true;
            distanceTraveledDeviate = followPath(creator, distanceTraveledDeviate, EndOfPathInstruction.Stop);
        }
        else
        {
            distanceTraveledDeviate = followPath(creator, distanceTraveledDeviate, EndOfPathInstruction.Stop);
        }

        if ( distanceTraveledDeviate >= creator.path.length)
        {
            activeJourney = false;
            traveling = false;
            distanceTraveled = distanceTraveledDeviate;
            Destroy(creator.gameObject);
        }

    }*/

    void OnPathChanged()
    {
        distanceTraveled = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
    }
}
