/***********************************************************
* CLR版本：4.0.30319.42000
* 类 名 称：ISerializer
* 机器名称：HLZN
* 命名空间：VisionPlatform.Auxiliary
* 文 件 名：ISerializer
* 创建时间：2023/9/27 14:35:42
* 作    者： Chustange
* 公    司：HaiLan Intelligent
* 说   明：
* 修改时间：
* 修 改 人：
* 修改说明：
* 深圳市海蓝智能科技有限公司 © 2023 保留所有权利.
***********************************************************/

namespace VisionPlatform.Auxiliary
{
    public interface ISerializer
    {
        T Deserialize<T>(string path) where T : class, new();
        void Serialize<T>(string path, T value);
    }
}
