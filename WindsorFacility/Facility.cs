// Copyright (c) 2009 Lee Henson

// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:

// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.

// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

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