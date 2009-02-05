using Castle.MicroKernel.Registration;
using Machine.Specifications;
using WindsorFacility.Specs.Stubs;
using WindsorFacility.Specs.Stubs.Controllers;

namespace WindsorFacility.Specs
{
	[Subject("Instantiating a component")]
	public class when_there_are_mixins_for_the_request_component_and_the_component_has_optional_dependencies : with_facility
	{
		protected static LetterController controller;

		Because of = () =>
		{
			container.Register(Component.For<LetterController>().LifeStyle.Transient);
			container.Register(Component.For<SomeOtherComponent>().LifeStyle.Transient);
			controller = container.Resolve<LetterController>();
		};

		It should_fulfill_the_optional_dependencies = () => controller.OptionalComponent.ShouldNotBeNull();
	}
}