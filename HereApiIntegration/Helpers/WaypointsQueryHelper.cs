using HereApiIntegration.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HereApiIntegration.Definitions.Helpers
{
    public static class WaypointsQueryHelper
    {
        public static string ConvertToHereWaypoints(List<Point> points)
        {
            var decimalPoint = 4;
            var waypoints = new StringBuilder();

            for (int i = 0; i < points.Count(); i++)
            {
                waypoints.Append($"&waypoint{i}=geo!{Math.Round(points[i].Longitude, decimalPoint)},{Math.Round(points[i].Latitude, decimalPoint)}");
            }

            return waypoints.ToString();
        }
    }
}
