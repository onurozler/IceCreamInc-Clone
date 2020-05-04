﻿using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Utils
{
    public static class OnurExtensionMethods
    {
        public static void SafeInvoke(this Action source)
        {
            if (source != null) source.Invoke();
        }

        public static void SafeInvoke<T>(this Action<T> source, T value)
        {
            if (source != null) source.Invoke(value);
        }

        public static List<T> Clone<T>(this List<T> listToClone) where T : ICloneable  
        {  
            return listToClone.Select(item => (T)item.Clone()).ToList();  
        }

        public static void ChangePositionY(this Transform thisPosition, float yPosition)
        {
            var tempPos = thisPosition.position;
            tempPos.y = yPosition;

            thisPosition.position = tempPos;
        }
    }
}
