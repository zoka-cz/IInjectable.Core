using System;
using System.Collections.Generic;
using System.Text;

namespace Zoka.IInjectable
{
	/// <summary>When applied to the IInjectable it allows to change how the implementation class will be registered as service</summary>
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
	public class InjectAsAttribute : Attribute
	{
		/// <summary>Defines, which is the base type, as which the implementation is registered into Service provider</summary>
		public Type											InjectAsType { get; set; }

		/// <summary>Constructor</summary>
		public InjectAsAttribute(Type _inject_as_type)
		{
			InjectAsType = _inject_as_type;
		}
	}
}
