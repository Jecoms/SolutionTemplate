﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using $ext_projectname$.Accessors.EntityFramework;
using $ext_projectname$.Common.Contracts;

namespace TemplateName.Tests.IntegrationTests
{
    [TestClass]
    public abstract class IntegrationTestBase
    {
        public IntegrationTestBase()
        {
        }

        [TestInitialize()]
        public void Init()
        {
            CreateGlobalContext();
        }

        [TestCleanup()]
        public void Cleanup()
        {
            CancelGlobalTransaction();
        }

        public static void CreateGlobalContext()
        {
            DatabaseContext.UnitTestContext = DatabaseContext.Create(false);
            DatabaseContext.UnitTestContext.Database.BeginTransaction();
        }

        public static void CancelGlobalTransaction()
        {
            if (DatabaseContext.UnitTestContext != null)
            {
                DatabaseContext.UnitTestContext.Database.RollbackTransaction();
                DatabaseContext.UnitTestContext.AllowDispose = true;
                DatabaseContext.UnitTestContext.Dispose();
                DatabaseContext.UnitTestContext = null;
            }
        }

        private AmbientContext _context = new AmbientContext()
        {
        };
        protected AmbientContext Context
        {
            get
            {
                return _context;
            }
        }
    }
}
