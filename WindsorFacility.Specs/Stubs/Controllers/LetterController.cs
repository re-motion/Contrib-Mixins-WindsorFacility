using Castle.Components.Binder;
using Castle.MonoRail.Framework;

namespace WindsorFacility.Specs.Stubs.Controllers
{
	public class LetterController : SmartDispatcherController
	{
		public LetterController()
		{
		}

		public LetterController(IDataBinder binder) : base(binder)
		{
		}

		public SomeOtherComponent OptionalComponent { get; set; }
	}
}
