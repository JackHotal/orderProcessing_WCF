using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using opdblib_ado;

namespace OrderProcessingService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "OPService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select OPService.svc or OPService.svc.cs at the Solution Explorer and start debugging.
    public class OPService : IOrder
    {
        private Order mdb;
        public OPService()
        {
            mdb = new Order("ism6236", "ism6236bo");
        }

        /**
         * Web service operation
         */
        public String getCustomer(String cid)
        {
            //TODO write your implementation code here:
            return mdb.getCustomer(cid);
        }

        public int Purchase(String cid, List<String> od)
        {
            return mdb.Purchase(cid, od);
        }

        public List<String> getOrderDetails(String oid)
        {
            return mdb.getOrderDetails(oid);
        }

        public List<String> getCustomerOrders(String id)
        {
            return mdb.getCustomerOrders(id);
        }


        public List<String> getProductIds()
        {
            return mdb.getProductIds();
        }
        public String getProductDetail(String id)
        {
            return mdb.getProductDetail(id);
        }


    }
}
