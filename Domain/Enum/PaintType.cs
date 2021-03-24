using System.ComponentModel;

namespace Domain.Enum
{
    public enum PaintType
	{
		Undefined = 0,

		[Description("Акрил")]
		Acril = 1,

		[Description("Металлик")]
		Metallic = 2
	}
}
