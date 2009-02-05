using Castle.MicroKernel.Registration;
using Machine.Specifications;
using Remotion.Mixins;
using WindsorFacility.Specs.Stubs.Controllers;

namespace WindsorFacility.Specs
{
	[Subject("Instantiating a component")]
	public class when_there_are_mixins_for_the_requested_component : with_facility
	{
		protected static DumbController controller;
		
		Because of = () =>
		{
			container.Register(Component.For<DumbController>().LifeStyle.Transient);
			controller = container.Resolve<DumbController>();
		};

		It should_instantiate_the_component = () => controller.ShouldNotBeNull();

		It should_be_a_mixed_component = () => MixinTypeUtility.IsGeneratedByMixinEngine(controller.GetType()).ShouldBeTrue();
	}
}