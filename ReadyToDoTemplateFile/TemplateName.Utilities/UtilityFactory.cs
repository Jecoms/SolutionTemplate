﻿using $ext_projectname$.Common.Contracts;
using $ext_projectname$.Common.Shared;

namespace $safeprojectname$
{
    public class UtilityFactory : FactoryBase
    {
        public UtilityFactory(AmbientContext context) : base(context)
        {
        }

        public T CreateUtility<T>() where T : class
        {
            T result = base.GetInstanceForType<T>();

            // Configure the context if the result is not a mock
            if (result is UtilityBase)
                (result as UtilityBase).Context = Context;

            return result;
        }
    }
}
