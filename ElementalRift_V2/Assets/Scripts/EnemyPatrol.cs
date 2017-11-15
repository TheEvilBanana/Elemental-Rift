using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour {

        public Transform player;
        public float speed = 5.0f;

        void Update()
        {
            var direction = player.position - transform.position;
            var angle = Vector3.Angle(direction, this.transform.forward);
            if (angle < 180 && direction.magnitude < 10)
            {
                var rotation = Quaternion.Slerp(
                    this.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime);
                rotation.x = 0;
                rotation.z = 0;
                transform.rotation = rotation;

                if (direction.magnitude > 5)
                    transform.Translate(0, 0, Time.deltaTime * speed);
            }
        }
}
