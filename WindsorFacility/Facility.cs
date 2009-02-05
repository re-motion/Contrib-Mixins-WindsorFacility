using System;
using System.Reflection;
using Castle.Core;
using Castle.MicroKernel.Facilities;
using Remotion.Mixins;
using Remotion.Mixins.Context;

namespace WindsorFacility
{
	public class Facility : AbstractFacility
	{
		readonly MixinConfiguration mixinConfiguration;

		public Facility() : this(DeclarativeConfigurationBuilder.BuildDefaultConfiguration())
		{
		}

		public Facility(params Assembly[] assemblies) : this(DeclarativeConfigurationBuilder.BuildConfigurationFromAssemblies(assemblies))
		{
		}

		public Facility(MixinConfiguration mixinConfiguration)
		{
			this.mixinConfiguration = mixinConfiguration;
		}

		protected override void Init()
		{
			Kernel.ComponentModelCreated += Kernel_ComponentModelCreated;
		}

		private void Kernel_ComponentModelCreated(ComponentModel model)
		{
			using (mixinConfiguration.EnterScope())
			{
				if (MixinTypeUtility.IsGeneratedByMixinEngine(model.Service))
					throw new ArgumentException("Do not register already-mixed types.", "model");

				if (MixinTypeUtility.HasMixins(model.Service))
					model.CustomComponentActivator = typeof(ComponentActivator);
			}
		}

		internal MixinConfiguration MixinConfiguration
		{
			get { return mixinConfiguration; }
		}
	}
}