using Remotion.Mixins;
using WindsorFacility.Specs.Stubs.Controllers;

namespace WindsorFacility.Specs.Stubs.Mixins
{
	[Extends(typeof(DumbController))]
	public class DumbMixin<T> : Mixin<T> where T : DumbController
	{
	}
}