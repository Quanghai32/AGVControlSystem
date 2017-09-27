using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Control_system;
using ControlSystemLibrary;
using System.Collections.Generic;

namespace UnitTestControlSystem
{
    [TestClass]
    public class UnitTestControlSystem
    {
        [TestMethod]
        public void TestRequest2Part()
        {
            //Log5 , Log4 0, Log3 , Log2 , Log1 
            //Pdc5 0, Pdc4 , Pdc3 0, Pdc2 , Pdc1 
            //firstPriority >= secondPriority
            List<CPart> PartList = new List<CPart> {
                new CPart {index=0,Name="Log1",priority=1,Status=true,Enable=true,connecting=true,Text=true,TextSource=1,isRequested=false,AGVSupply="",isRequesting=false },
                new CPart {index=1,Name="Log2",priority=2,Status=true,Enable=true,connecting=true,Text=true,TextSource=1,isRequested=false,AGVSupply="",isRequesting=false },
                new CPart {index=2,Name="Log3",priority=3,Status=true,Enable=true,connecting=true,Text=true,TextSource=1,isRequested=false,AGVSupply="",isRequesting=false },
                new CPart {index=3,Name="Log4",priority=4,Status=false,Enable=true,connecting=true,Text=true,TextSource=1,isRequested=false,AGVSupply="",isRequesting=false },
                new CPart {index=4,Name="Log5",priority=5,Status=true,Enable=true,connecting=true,Text=true,TextSource=1,isRequested=false,AGVSupply="",isRequesting=false },
               
                new CPart {index=5,Name="Pdc1",priority=1,Status=true,Enable=true,connecting=true,Text=true,TextSource=0,isRequested=false,AGVSupply="",isRequesting=false },
                new CPart {index=6,Name="Pdc2",priority=2,Status=true,Enable=true,connecting=true,Text=true,TextSource=0,isRequested=false,AGVSupply="",isRequesting=false },
                new CPart {index=7,Name="Pdc3",priority=3,Status=false,Enable=true,connecting=true,Text=true,TextSource=0,isRequested=false,AGVSupply="",isRequesting=false },
                new CPart {index=8,Name="Pdc4",priority=4,Status=true,Enable=true,connecting=true,Text=true,TextSource=0,isRequested=false,AGVSupply="",isRequesting=false },
                new CPart {index=9,Name="Pdc5",priority=5,Status=false,Enable=true,connecting=true,Text=true,TextSource=0,isRequested=false,AGVSupply="",isRequesting=false },               
            };
            byte firstIndex=0, secondIndex=0;
            ClassToTest r = new ClassToTest();
            r.Find2SupplyPart4AGV(0,ref firstIndex,ref secondIndex, PartList);
            
        }
        [TestMethod]
        public void TestModule()
        {
            ClassTestModule clsModule = new ClassTestModule();
            clsModule.TestModule();
        }
    }
}
