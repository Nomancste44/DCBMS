using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DCBillManagementSystemWebApp.DAL;
using DCBillManagementSystemWebApp.Model;

namespace DCBillManagementSystemWebApp.BLL
{
    public class TypeManager
    {
        readonly TypeGateway _aTypeGateway = new TypeGateway();

        public string SaveTestType(string aType)
        {
            if (!_aTypeGateway.IsExistTestType(aType))
            {
                return _aTypeGateway.SaveTypeName(aType) ? "Saved Sucessfully" : "Save Failed";
            }
            return "This TestType Already Exist";
        }

        public List<TestTypes> GetAll()
        {
            return _aTypeGateway.GetAll();
        }

        public List<TestTypes> GetAllTestType()
        {
            return _aTypeGateway.GetAllTestType();
        }

       
    }
}