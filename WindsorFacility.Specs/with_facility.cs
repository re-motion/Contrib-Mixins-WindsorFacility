using Castle.Windsor;
using Machine.Specifications;
using Remotion.Mixins;
using WindsorFacility.Specs.Stubs.Controllers;

namespace WindsorFacility.Specs
{
	public abstract class with_facility
	{
		protected static MixinConfiguration mixinConfiguration;
		protected static Facility facility;
		protected static IWindsorContainer container;
		
		Establish context = () =>
		{
			facility = new Facility(typeof(DumbController).Assembly);

			container = new WindsorContainer();
			container.AddFacility("remotion.facility", facility);
		};

		Cleanup after_each = () => container.Dispose();
	}
}