using Castle.Components.Binder;
using Castle.MonoRail.Framework;

namespace WindsorFacility.Specs.Stubs.Controllers
{
	public class NumberController : SmartDispatcherController
	{
		public NumberController()
		{
		}

		public NumberController(IDataBinder binder) : base(binder)
		{
		}

		public int GetNumber()
		{
			return 0;
		}
	}
}