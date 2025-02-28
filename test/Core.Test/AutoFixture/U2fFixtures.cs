﻿using System;
using AutoFixture;
using AutoFixture.Kernel;
using Bit.Core.Entities;
using Bit.Core.Test.AutoFixture.EntityFrameworkRepositoryFixtures;
using Bit.Core.Test.AutoFixture.Relays;
using Bit.Core.Test.AutoFixture.UserFixtures;
using Bit.Infrastructure.EntityFramework.Repositories;
using Bit.Test.Common.AutoFixture;
using Bit.Test.Common.AutoFixture.Attributes;

namespace Bit.Core.Test.AutoFixture.U2fFixtures
{
    internal class U2fBuilder : ISpecimenBuilder
    {
        public object Create(object request, ISpecimenContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var type = request as Type;
            if (type == null || type != typeof(U2f))
            {
                return new NoSpecimen();
            }

            var fixture = new Fixture();
            fixture.Customizations.Add(new MaxLengthStringRelay());
            var obj = fixture.WithAutoNSubstitutions().Create<U2f>();
            return obj;
        }
    }

    internal class EfU2f : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Customizations.Add(new IgnoreVirtualMembersCustomization());
            fixture.Customizations.Add(new GlobalSettingsBuilder());
            fixture.Customizations.Add(new U2fBuilder());
            fixture.Customizations.Add(new UserBuilder());
            fixture.Customizations.Add(new EfRepositoryListBuilder<U2fRepository>());
            fixture.Customizations.Add(new EfRepositoryListBuilder<UserRepository>());
        }
    }

    internal class EfU2fAutoDataAttribute : CustomAutoDataAttribute
    {
        public EfU2fAutoDataAttribute() : base(new SutProviderCustomization(), new EfU2f())
        { }
    }

    internal class InlineEfU2fAutoDataAttribute : InlineCustomAutoDataAttribute
    {
        public InlineEfU2fAutoDataAttribute(params object[] values) : base(new[] { typeof(SutProviderCustomization),
            typeof(EfU2f) }, values)
        { }
    }
}

