﻿using System;
using UnityEngine;
using UnityEngine.Events;

namespace BezierSolution
{
	public class BezierWalkerWithSpeed : BezierWalker
	{
		public BezierSpline spline;
		public TravelMode travelMode;

		public float speed = 5f;
		[SerializeField]
		[Range( 0f, 1f )]
		private float m_normalizedT = 0f;

		public override BezierSpline Spline { get { return spline; } }

		public override float NormalizedT
		{
			get { return m_normalizedT; }
			set { m_normalizedT = value; }
		}

		//public float movementLerpModifier = 10f;
		public float rotationLerpModifier = 10f;

		[System.Obsolete( "Use lookAt instead", true )]
		[System.NonSerialized]
		public bool lookForward = true;
		public LookAtMode lookAt = LookAtMode.Forward;

		private bool isGoingForward = true;
		public override bool MovingForward { get { return ( speed > 0f ) == isGoingForward; } }

		public Action OnPathCompleted;
		private bool onPathCompletedCalledAt1 = false;
		private bool onPathCompletedCalledAt0 = false;

		protected virtual void Update()
		{
			Execute( Time.deltaTime );
		}

		public override void Execute( float deltaTime )
		{
			float targetSpeed = ( isGoingForward ) ? speed : -speed;

			Vector3 targetPos = spline.MoveAlongSpline( ref m_normalizedT, targetSpeed * deltaTime );

			//transform.position = targetPos;
			transform.position = Vector3.Lerp( transform.position, targetPos, 2f * deltaTime );

			bool movingForward = MovingForward;

			if( lookAt == LookAtMode.Forward )
			{
				Quaternion targetRotation;
				if( movingForward )
					targetRotation = Quaternion.LookRotation( spline.GetTangent( m_normalizedT ) );
				else
					targetRotation = Quaternion.LookRotation( -spline.GetTangent( m_normalizedT ) );

				transform.rotation = Quaternion.Lerp( transform.rotation, targetRotation, rotationLerpModifier * deltaTime );
			}
			else if( lookAt == LookAtMode.SplineExtraData )
				transform.rotation = Quaternion.Lerp( transform.rotation, spline.GetExtraData( m_normalizedT, extraDataLerpAsQuaternionFunction ), rotationLerpModifier * deltaTime );

			if( movingForward )
			{
				if( m_normalizedT >= 1f )
				{
					if( travelMode == TravelMode.Once )
						m_normalizedT = 1f;
					else if( travelMode == TravelMode.Loop )
						m_normalizedT -= 1f;
					else
					{
						m_normalizedT = 2f - m_normalizedT;
						isGoingForward = !isGoingForward;
					}

					if( !onPathCompletedCalledAt1 )
					{
						onPathCompletedCalledAt1 = true;
#if UNITY_EDITOR
						if( UnityEditor.EditorApplication.isPlaying )
#endif
							if(OnPathCompleted!=null)OnPathCompleted.Invoke();
					}
				}
				else
				{
					onPathCompletedCalledAt1 = false;
				}
			}
			else
			{
				if( m_normalizedT <= 0f )
				{
					if( travelMode == TravelMode.Once )
						m_normalizedT = 0f;
					else if( travelMode == TravelMode.Loop )
						m_normalizedT += 1f;
					else
					{
						m_normalizedT = -m_normalizedT;
						isGoingForward = !isGoingForward;
					}

					if( !onPathCompletedCalledAt0 )
					{
						onPathCompletedCalledAt0 = true;
#if UNITY_EDITOR
						if( UnityEditor.EditorApplication.isPlaying )
#endif
							if(OnPathCompleted!=null)OnPathCompleted.Invoke();
					}
				}
				else
				{
					onPathCompletedCalledAt0 = false;
				}
			}
		}
	}
}