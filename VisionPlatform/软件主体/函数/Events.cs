using System;

namespace VisionPlatform
{
    public delegate void ThdChangedEventHandler(object sender, EventArgs e);
    public delegate void ControlChangedEventHandler(object sender, EventArgs e);
    public delegate void CtrlValueRangeEventHandler(object sender, EventArgs e);
    public delegate void TrackBarValueChangedEventHandler(object sender, EventArgs e);
    public delegate void FormClosedEventHandler(object sender, EventArgs e);
    public delegate void TrackBarValueChangeEventHandler(object sender, EventArgs e);
    public delegate void CtrlThdEventHandler(object sender, EventArgs e);
    public delegate void CtrlRatioRangeEventHandler(object sender, EventArgs e);
    public delegate void CtrlStaticThdEventHandler(object sender, EventArgs e);
    public delegate void CtrlColorSpaceThdEventHandler(object sender, EventArgs e);
    public delegate void CtrlColorTrainEventHandler(object sender, EventArgs e);
    public delegate void CtrlFitLineEventHandler(object sender, EventArgs e);
    public delegate void RectROIMoveEventHandler(object sender, EventArgs e);
    public delegate void LineColorEventHandler(object sender, EventArgs e);
    public delegate void CtrlNccModelEventHandler(object sender, EventArgs e);

    //正面检测
    public delegate void PNCodeEventHandler(object sender, EventArgs e);
    public delegate void CtrlLabelEventHandler(object sender, EventArgs e);
    public delegate void TorsionExistEventHandler(object sender, EventArgs e);
    public delegate void PasterExistEventHandler(object sender, EventArgs e);
    public delegate void PlugInExistEventHandler(object sender, EventArgs e);

    public static class MyEvents
    {
        //public static event ControlChangedEventHandler RubberCountChanged;
        //public static void RubberChanged(this int count) => RubberCountChanged?.Invoke(count);

        //public static event ValueChangedEventHandler ValueChanged;
        //public static void ValueChange() => ValueChanged?.Invoke();
        //插壳检测
        public static event TrackBarValueChangedEventHandler RubberTrackBarValueChanged;
        public static void RubberValueChanged(this object sender, EventArgs e) => RubberTrackBarValueChanged?.Invoke(sender, e);

    }
}
