using System.ComponentModel;

namespace HC.Domain.CargoAggregate.ValueObject;

public enum HazMatCodeEnum
{
    [Description("爆炸品")]
    XQY = 100,
    [Description("易燃气体")]
    TQP = 200,
    [Description("易燃液体")]
    XRY = 300,
    [Description("易燃固体")]
    XRG = 400,
    [Description("氧化剂")]
    XYW = 500,
    [Description("医疗废物")]
    XYY = 600,
    [Description("二级放射性物品")]
    XFS = 700,
    [Description("腐蚀品")]
    XFW = 800,
    //一些重金属
    [Description("杂类")]
    XZW = 900
}