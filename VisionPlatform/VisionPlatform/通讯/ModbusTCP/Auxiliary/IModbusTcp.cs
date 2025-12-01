using Hi.Ltd.Windows.Interfaces;
namespace VisionPlatform.Auxiliary
{
    public interface IModbusTcp : IPlc, IModbus
    {
        public int Result { get; set; }
    }
}
