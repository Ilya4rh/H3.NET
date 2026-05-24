using System;
using System.Globalization;
using H3Net.Constants;
using H3Net.Utils;

namespace H3Net.Models;

public readonly struct GeoCoordinate
{
    public readonly double LatitudeRadians;
    
    public readonly double LongitudeRadians;

    public double LatitudeDegrees => ToDegrees(LatitudeRadians);
    
    public double LongitudeDegrees => ToDegrees(LongitudeRadians); 

    public GeoCoordinate(double latitudeRadians, double longitudeRadians)
    {
        LatitudeRadians = latitudeRadians;
        LongitudeRadians = longitudeRadians;
    }
    
    public static GeoCoordinate CreateFromDegrees(double latitudeDegrees, double longitudeDegrees)
    {
        var latitudeRadians = ToRadians(latitudeDegrees);
        var longitudeRadians = ToRadians(longitudeDegrees);
        
        return new GeoCoordinate(latitudeRadians, longitudeRadians);
    }

    internal double CalculateAzimuthRadians(GeoCoordinate target)
    {
        return Math.Atan2(
            Math.Cos(target.LatitudeRadians) * Math.Sin(target.LongitudeRadians - LongitudeRadians),
            Math.Cos(LatitudeRadians) * Math.Sin(target.LatitudeRadians) -
            Math.Sin(LatitudeRadians) * Math.Cos(target.LatitudeRadians) *
            Math.Cos(target.LongitudeRadians - LongitudeRadians)
        );
    }

    internal GeoCoordinate MoveByAzimuthAndDistance(double azimuth, double distance)
    {
        if (distance < CalculateConstants.Epsilon)
        {
            return new GeoCoordinate(LatitudeRadians, LongitudeRadians);
        }

        azimuth = AngleUtils.NormalizeRadians(azimuth);

        double lat2, lng2;

        if (azimuth < CalculateConstants.Epsilon || Math.Abs(azimuth - Math.PI) < CalculateConstants.Epsilon)
        {
            if (azimuth < CalculateConstants.Epsilon)
            {
                lat2 = LatitudeRadians + distance;
            }
            else
            {
                lat2 = LatitudeRadians - distance;
            }

            if (Math.Abs(lat2 - CalculateConstants.HalfPi) < CalculateConstants.Epsilon)
            {
                lat2 = CalculateConstants.HalfPi;
                lng2 = 0.0;
            }
            else if (Math.Abs(lat2 + CalculateConstants.HalfPi) < CalculateConstants.Epsilon)
            {
                lat2 = -CalculateConstants.HalfPi;
                lng2 = 0.0;
            }
            else
            {
                lng2 = ConstrainLng(LongitudeRadians);
            }
        }
        else
        {
            var sinLat = Math.Sin(LatitudeRadians) * Math.Cos(distance) +
                         Math.Cos(LatitudeRadians) * Math.Sin(distance) * Math.Cos(azimuth);

            sinLat = Clamp(sinLat);

            lat2 = Math.Asin(sinLat);

            if (Math.Abs(lat2 - CalculateConstants.HalfPi) < CalculateConstants.Epsilon)
            {
                lat2 = CalculateConstants.HalfPi;
                lng2 = 0.0;
            }
            else if (Math.Abs(lat2 + CalculateConstants.HalfPi) < CalculateConstants.Epsilon)
            {
                lat2 = -CalculateConstants.HalfPi;
                lng2 = 0.0;
            }
            else
            {
                var invCosLat2 = 1.0 / Math.Cos(lat2);

                var sinLng = Math.Sin(azimuth) * Math.Sin(distance) * invCosLat2;
                var cosLng = (Math.Cos(distance) -
                              Math.Sin(LatitudeRadians) * Math.Sin(lat2)) /
                                Math.Cos(LatitudeRadians) * invCosLat2;

                sinLng = Clamp(sinLng);
                cosLng = Clamp(cosLng);

                lng2 = ConstrainLng(
                    LongitudeRadians + Math.Atan2(sinLng, cosLng)
                );
            }
        }

        return new GeoCoordinate(lat2, lng2);
    }

    internal double DistanceTo(GeoCoordinate target)
    {
        const double earthRadiusMeters = 6371007.180918;
    
        var deltaLat = target.LatitudeRadians - LatitudeRadians;
        var deltaLng = target.LongitudeRadians - LongitudeRadians;
    
        var a = Math.Sin(deltaLat / 2) * Math.Sin(deltaLat / 2) +
                Math.Cos(LatitudeRadians) * Math.Cos(target.LatitudeRadians) *
                Math.Sin(deltaLng / 2) * Math.Sin(deltaLng / 2);
    
        var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
    
        return earthRadiusMeters * c;
    }
    
    private static double ConstrainLng(double lng)
    {
        while (lng > Math.PI)
            lng -= 2 * Math.PI;

        while (lng < -Math.PI)
            lng += 2 * Math.PI;

        return lng;
    }
    
    private static double Clamp(double value)
    {
        return value switch
        {
            > 1.0 => 1.0,
            < -1.0 => -1.0,
            _ => value
        };
    }
    
    private static double ToRadians(double degrees)
    {
        return degrees * Math.PI / 180.0;
    }
    
    private static double ToDegrees(double radians)
    {
        return radians * 180.0 / Math.PI;
    }
}