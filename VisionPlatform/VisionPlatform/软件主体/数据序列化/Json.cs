using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Hi.Ltd;

namespace VisionPlatform
{
    public static class Json
    {
        private static readonly ReaderWriterLockSlim JsonLock = new ReaderWriterLockSlim();
        public static T DeserializeJson<T>(this string path)
        {
            if (!File.Exists(path)) return default;
            try
            {
                JsonLock.EnterReadLock();
                return JsonConvert.DeserializeObject<T>(File.ReadAllText(path));
            }
            catch (Exception ex)
            {
                ex.Log(MethodBase.GetCurrentMethod());
                return default;
            }
            finally
            {
                JsonLock.ExitReadLock();
            }
        }

        public static void SerializeJson<T>(this string path, T value)
        {
            try
            {
                JsonLock.EnterWriteLock();
                File.WriteAllText(path, JsonConvert.SerializeObject(value));
            }
            catch (Exception ex)
            {
                ex.Log(MethodBase.GetCurrentMethod());
            }
            finally
            {
                JsonLock.ExitWriteLock();
            }
        }
    }
}
