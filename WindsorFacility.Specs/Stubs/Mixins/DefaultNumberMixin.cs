using Remotion.Mixins;
using WindsorFacility.Specs.Stubs.Controllers;

namespace WindsorFacility.Specs.Stubs.Mixins
{
	[Extends(typeof(NumberController))]
	public class DefaultNumberMixin<T> : Mixin<T>, INumberMixin where T : NumberController
	{
		public virtual int GetNumber()
		{
			return 1;
		}
	}
}