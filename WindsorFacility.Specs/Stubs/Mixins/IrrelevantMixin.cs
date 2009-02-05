using Castle.MonoRail.Framework.Adapters;
using Remotion.Mixins;

namespace WindsorFacility.Specs.Stubs.Mixins
{
	[Extends(typeof(RequestAdapter))]
	public class IrrelevantMixin<T> : Mixin<T> where T : RequestAdapter
	{
	}
}