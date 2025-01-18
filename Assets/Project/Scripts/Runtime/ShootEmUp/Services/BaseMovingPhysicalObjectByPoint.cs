using System;
using UnityEngine;

namespace TaoPulse.ShootEmUp.Services
{
    public class BaseMovingPhysicalObjectByPoint : BaseMovingPhysicalObject
    {
        [SerializeField] private Transform[] movingPoints;
        protected override void Init()
        {
            
        }

        private void Update()
        {
            int lenght = movingPoints.Length;
            for (int i = 0; i < lenght; i++)
            {
                
            }
        }

        public void SetMovingPoints(Transform[] movePoints) => movingPoints = movePoints;
    }
}
