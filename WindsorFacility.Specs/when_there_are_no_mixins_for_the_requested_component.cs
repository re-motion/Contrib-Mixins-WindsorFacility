using Castle.MicroKernel.Registration;
using Machine.Specifications;
using Remotion.Mixins;
using WindsorFacility.Specs.Stubs;

namespace WindsorFacility.Specs
{
	[Subject("Instantiating a component")]
	public class when_there_are_no_mixins_for_the_requested_component : with_facility
	{
		protected static SomeOtherComponent component;
		
		Because of = () =>
		{
			container.Register(Component.For<SomeOtherComponent>().LifeStyle.Transient);
			component = container.Resolve<SomeOtherComponent>();
		};

		It should_instantiate_the_component = () => component.ShouldNotBeNull();

		It should_not_be_a_mixed_component = () => MixinTypeUtility.IsGeneratedByMixinEngine(component.GetType()).ShouldBeFalse();
	}
}