using UnityEngine;
using System.Collections;
using UnityEngine.Scripting;
using UnityEngine.EventSystems;

public class TrackingSystem : MonoBehaviour
{
    public float speed = 3.0f;
    public Transform m_target = null;
    Vector3 m_lastKnownPosition = Vector3.zero;
    Quaternion m_lookAtRotation;



    // Update is called once per frame
    void Update()
    {

        m_target = GameObject.FindGameObjectWithTag("Player").transform;

        if (m_target)
        {

            if (m_lastKnownPosition != m_target.transform.position)
            {
                m_lastKnownPosition = m_target.transform.position;
                m_lookAtRotation = Quaternion.LookRotation(m_lastKnownPosition - transform.position);
            }

            if (transform.rotation != m_lookAtRotation)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, m_lookAtRotation, speed * Time.deltaTime);
            }
        }
    }

    bool SetTarget(Transform target)
    {

        m_target = GameObject.FindGameObjectWithTag("Enemy").transform;

        if (!target)
        {
            return false;
        }

        m_target = target;

        return true;
    }
}
