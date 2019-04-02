using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Krummert.Api.Helpers
{
    public static class CachedHelper
    {
        private static Dictionary<uint, DateTime> _BlockedIps;
        private static Dictionary<uint, KeyValuePair<uint, DateTime>> _Cache;
        private static object _BlockedIpsLocker;
        private static object _CacheLocker;

        static CachedHelper()
        {
            _BlockedIps = new Dictionary<uint, DateTime>();
            _Cache = new Dictionary<uint, KeyValuePair<uint, DateTime>>();
            _CacheLocker = new object();
            _BlockedIpsLocker = new object();
        }

        public static void BlockIp(IPAddress iPAddress)
        {
            lock (_BlockedIpsLocker)
            {
                _BlockedIps.Add(IP2Number(iPAddress), DateTime.Now.AddMinutes(10));
            }
        }
        public static bool CanProceed(IPAddress ipAddress)
        {
            var ip = IP2Number(ipAddress);

            if (_BlockedIps.ContainsKey(ip) && ((DateTime.Now - _BlockedIps[ip]) < new TimeSpan(0, 10, 0)))
            {
                return false;
            }
            else if (_BlockedIps.ContainsKey(ip))
            {
                lock (_BlockedIpsLocker)
                {
                    _BlockedIps.Remove(ip);
                }
            }

            return true;
        }
        public static bool IncrimentValueForFailedLogin(IPAddress ipAddress)
        {
            var ip = IP2Number(ipAddress);
            uint failedAttempts = 0;

            lock (_CacheLocker)
            {
                if (!_Cache.ContainsKey(ip))
                {
                    _Cache.Add(ip, new KeyValuePair<uint, DateTime>(0, DateTime.MinValue));
                }

                failedAttempts = _Cache[ip].Key + 1;
                var dateTimeToUse = _Cache[ip].Value;

                if (!((DateTime.Now - _Cache[ip].Value) < new TimeSpan(0, 10, 0))) // Is it a possible brute force attack?
                {
                    dateTimeToUse = DateTime.Now;
                }

                _Cache[ip] = new KeyValuePair<uint, DateTime>(failedAttempts, dateTimeToUse);
            }

            if ((failedAttempts % 5) == 0)
            {
                BlockIp(ipAddress);
                return true;
            }

            return false;
        }
        public static void ResetForSuccess(IPAddress iPAddress)
        {
            var ip = IP2Number(iPAddress);

            if (_BlockedIps.ContainsKey(ip) || _Cache.ContainsKey(ip))
            {
                lock (_CacheLocker)
                {
                    lock (_BlockedIpsLocker)
                    {
                        if (_Cache.ContainsKey(ip)) _Cache.Remove(ip);
                        if (_BlockedIps.ContainsKey(ip)) _BlockedIps.Remove(ip);
                    }
                }
            }
        }

        private static UInt32 IP2Number(IPAddress origin)
        {
            byte[] bytes = origin.GetAddressBytes();
            Array.Reverse(bytes); // flip big-endian(network order) to little-endian
            return BitConverter.ToUInt32(bytes, 0);
        }
    }
}
