using CamSDK;

namespace VisionPlatform
{
    public static class AllCamIO
    {
        private static readonly object readioLock = new object();
        public static int ReadCamIO(string m_cameSer, int io, ref uint bchek)
        {
            bchek = 1;
            int bResult = -1;
            if (io == -1)
            {
                return bResult;
            }
            lock (readioLock)
            {
                CamCommon.GetIOState(m_cameSer, io, ref bchek);
                bResult = 0;
            }
            return bResult;
        }
    }
}
