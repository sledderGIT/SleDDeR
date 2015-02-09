using System;
using Cirrious.CrossCore;
using System.Linq;
using System.Collections;
using System.Reflection;
using System.IO;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Globalization;
using Jeopardy.Core;

namespace Investor.Core
{
	public static class PositionSortExtension
	{
	    public static T Move<T>(this List<T> list, T obj, bool direction) where T : ISortable, IEntity, new()
        {
            var i = list.FindIndex(s => s.SortPosition == obj.SortPosition);
            if (direction)
            {
                if (i > 0)
                {
                    list[i].SortPosition = list[i - 1].SortPosition;
                    list[i - 1].SortPosition++;
                    return list[i - 1];
                }
                else
                {
                    throw new InvalidOperationException("Can't move down last element");
                }
            }
            else
            {
                if (i < list.Count - 1)
                {
                    list[i].SortPosition = list[i + 1].SortPosition;
                    list[i + 1].SortPosition--;
                    return list[i + 1];
                }
                else
                {
                    throw new InvalidOperationException("Can't move down last element");
                }
            }
        }
	}
}

