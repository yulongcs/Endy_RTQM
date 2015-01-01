using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Lgsoft.RTQM.Application.BaseInfoModule.DTOs;
using Lgsoft.RTQM.Application.BaseInfoModule.Services;
using Lgsoft.RTQM.Application.FileModule.DTOs;
using Lgsoft.RTQM.Application.FileModule.Services;
using Lgsoft.RTQM.Application.RawMaterialQulityModule.DTOs;
using Lgsoft.RTQM.Application.RawMaterialQulityModule.Services;
using Lgsoft.RTQM.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RTQM.Application.Tests
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class MaterialAppServiceTests
    {
        public MaterialAppServiceTests()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void CreateNewMaterialTest()
        {
            var materialAppService =
                Container.Current.Resolve(typeof (IMaterialAppService), null) as IMaterialAppService;

            var materialDTO = new MaterialDTO
                                  {
                                      Id = Guid.NewGuid(),
                                      MaterialNo = "123",
                                      MaterialDescrption = "des 123",
                                  };

            materialDTO = materialAppService.CreateNewMaterial(materialDTO);

            materialDTO.MaterialNo = "345";
            materialAppService.UpdateMaterial(materialDTO);
        }

        [TestMethod]
        public void FindMatchedMaterialsTest()
        {
            var materialAppService =
                Container.Current.Resolve(typeof (IMaterialAppService), null) as IMaterialAppService;

            var result = materialAppService.FindMaterials(0, 5, "123");
        }

        [TestMethod]
        public void Test1()
        {
            var supplierAppService =
                Container.Current.Resolve(typeof (ISupplierAppService), null) as ISupplierAppService;

            var supplierDTO = new SupplierDTO
                                  {
                                      Id = Guid.Empty,
                                      SupplierName = "无锡联广",
                                  };

            supplierDTO = supplierAppService.CreateNewSupplier(supplierDTO);

            supplierDTO.SupplierName = "江苏佰腾";
            supplierAppService.UpdateSupplier(supplierDTO);
        }

        [TestMethod]
        public void Test2()
        {
            var purOrderAppService =
                Container.Current.Resolve(typeof (IPurchaseOrderAppService), null) as IPurchaseOrderAppService;

            var orderDTO = new PurchaseOrderDTO
                               {
                                   Id = Guid.Empty,
                                   OrderNo = "123456",
                                   OrderDate = DateTime.Parse("2012-2-16"),
                                   LineCount = 10,
                               };
            orderDTO = purOrderAppService.CreateNewPurchaseOrder(orderDTO);

            var orderDTO2 = new PurchaseOrderDTO
                                {
                                    Id = Guid.NewGuid(),
                                    OrderNo = "654321",
                                    OrderDate = DateTime.Parse("2012-2-14"),
                                };
            orderDTO2 = purOrderAppService.CreateNewPurchaseOrder(orderDTO2);

            var orders = purOrderAppService.FindPurchaseOrders(0, 1, "3", DateTime.MinValue, DateTime.MaxValue,
                                                               PurchaseOrderListSortFields.None, true);

            orders = purOrderAppService.FindPurchaseOrders(0, 1, "3", DateTime.Parse("2012-2-15"), DateTime.MaxValue,
                                                           PurchaseOrderListSortFields.OrderDate, true);

            orders = purOrderAppService.FindPurchaseOrders(0, 1, string.Empty, DateTime.Parse("2012-2-14"),
                                                           DateTime.Parse("2012-2-16"),
                                                           PurchaseOrderListSortFields.OrderDate, true);

            purOrderAppService.RemovePurchaseOrder(orderDTO.Id);
        }

        [TestMethod]
        public void Test3()
        {
            var purOrderAppService =
                Container.Current.Resolve(typeof (IPurchaseOrderAppService), null) as IPurchaseOrderAppService;
            var materialAppService =
                Container.Current.Resolve(typeof (IMaterialAppService), null) as IMaterialAppService;
            var supplierAppService =
                Container.Current.Resolve(typeof (ISupplierAppService), null) as ISupplierAppService;

            var orderDTO = new PurchaseOrderDTO
                               {
                                   Id = Guid.Empty,
                                   OrderNo = "po1001",
                                   OrderDate = DateTime.Parse("2012-2-16"),
                                   LineCount = 10,
                               };
            orderDTO = purOrderAppService.CreateNewPurchaseOrder(orderDTO);

            var materialDTO = new MaterialDTO
                                  {
                                      MaterialNo = "m1001",
                                      MaterialDescrption = "m1001 des",
                                  };
            materialDTO = materialAppService.CreateNewMaterial(materialDTO);

            var supplierDTO = new SupplierDTO
                                  {
                                      SupplierName = "supplier A",
                                  };
            supplierDTO = supplierAppService.CreateNewSupplier(supplierDTO);

            var orderLineDTO = new OrderLineDTO
                                   {
                                       BatchNo = "a1001",
                                       OrderId = orderDTO.Id,
                                       MaterialId = materialDTO.Id,
                                       SupplierId = supplierDTO.Id,
                                       MaterialType = MaterialType.EPMaterial,
                                       Total = 100,
                                       DefectDescrption = "DEF",
                                       ConcessionCount = 10,
                                       RejectionCount = 5,
                                       ReworkCount = 8,
                                       ScrapCount = 1
                                   };
            orderLineDTO = purOrderAppService.CreateNewOrderLine(orderLineDTO);

            var orderLineDTOs = purOrderAppService.FindOrderLines(0, 10, new OrderLineFindParameters(),
                                                                  OrderLineListSortFields.None, true);
        }

        [TestMethod]
        public void Test4()
        {
            var fileAppService = Container.Current.Resolve(typeof (IFileAppService), null) as IFileAppService;

            using (var fileStream = System.IO.File.OpenRead("TextFile1.txt"))
            {
                var fileDTO = new FileDTO
                                  {
                                      FileFullName = "TextFile1.txt",
                                      FileSize = fileStream.Length,
                                  };

                fileDTO = fileAppService.CreateNewFile(fileDTO, fileStream);

                fileAppService.ConfirmNewFile(fileDTO.Id);
            }
        }

        class MyClass
        {
            public string A { get; set; }

            public string B { get; set; }

            public string C { get; set; }

            public string D { get; set; }
        }

        [TestMethod]
        public void Test5()
        {
            var l = new List<MyClass>();
            l.Add(new MyClass
                      {
                          A = "a1",
                          B = "b1",
                          C = "c1",
                      });
            l.Add(new MyClass
                      {
                          A = "a2",
                          C = "c2",
                          D = "d2",
                      });

            var d = new Dictionary<string, string>();

            var s = ListExportUtility.ListExport(l, d);
            s.Position = 0;
            var strReader = new StreamReader(s);
            var t = strReader.ReadToEnd();
            s.Close();
        }

        [TestMethod]
        public void Test6()
        {
            //RawMaterialQualityReportUtility.SupplierQualityMonthReport(DateTime.MinValue, DateTime.MaxValue, null);
        }
    }
}
