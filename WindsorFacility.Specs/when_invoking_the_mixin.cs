using Castle.MicroKernel.Registration;
using Machine.Specifications;
using WindsorFacility.Specs.Stubs.Controllers;
using WindsorFacility.Specs.Stubs.Mixins;

namespace WindsorFacility.Specs
{
	[Subject("Invoking mixins on a mixed type")]
	public class when_invoking_the_mixin : with_facility
	{
		protected static NumberController controller;

		Establish context = () => container.Register(Component.For<NumberController>().LifeStyle.Transient);

		Because of = () =>
		{
			controller = container.Resolve<NumberController>();
		};

		It should_get_the_number_provided_by_the_mixin = () => (controller as INumberMixin).GetNumber().ShouldEqual(1);
	}
}