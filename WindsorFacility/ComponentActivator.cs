using System;
using Castle.Core;
using Castle.MicroKernel;
using Castle.MicroKernel.ComponentActivator;
using Remotion.Mixins;
using System.Linq;
using Remotion.Reflection;

namespace WindsorFacility
{
	public class ComponentActivator : DefaultComponentActivator
	{
		public ComponentActivator(ComponentModel model, IKernel kernel, ComponentInstanceDelegate onCreation, ComponentInstanceDelegate onDestruction) : base(model, kernel, onCreation, onDestruction)
		{
		}

		protected override object CreateInstance(CreationContext context, object[] arguments, Type[] signature)
		{
			using (Facility.MixinConfiguration.EnterScope())
			{
				return ObjectFactory.Create(context.Handler.Service, ParamList.CreateDynamic(signature, arguments));
			}
		}

		private Facility Facility
		{
			get
			{
				return Kernel.GetFacilities().Where(f => f is Facility).Cast<Facility>().Single();
			}
		}
	}
}